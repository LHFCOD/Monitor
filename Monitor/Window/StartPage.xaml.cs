using OfficeCore = Microsoft.Office.Core;
using ExcelCore = Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data;
using System.Data.OleDb;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace Monitor
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>

    public partial class StartPage : Window
    {
        DispatcherTimer timer;//定时器
        public OleDbConnection con;
        public DataTable dt_measure;
        public string strInsert;
        private ExtractData extractData = new ExtractData();//提取数据对象
                                                            //定义更新UI委托
        public delegate void UpdateUIHandler(object sender, EventArgs e);
        public event UpdateUIHandler UpdateUI;

        int pH_saveindex = 0;
        int DDL_saveindex = 0;
        DataTable dt_property;

        public int magnitude = -24;

        BackgroundWorker woker;//后台线程管理者

        public StartPage()
        {

            string conStr = (string)Application.Current.FindResource("PrivateConnString");
            con = new OleDbConnection(conStr);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("select * from tb_lhf_measure where saveindex is not null", con);
                    DataSet set = new DataSet();
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                    adp.Fill(set);
                    dt_measure = set.Tables[0];//获取参数配置表格
                    strInsert = ConstructString();//构建插入字符串

                    var re1 = from h in dt_measure.AsEnumerable()
                              where h.Field<string>("name") == "pH"
                              select Convert.ToInt32(h.Field<object>("saveindex"));
                    foreach (int d in re1)
                    {
                        pH_saveindex = d;
                    }

                    var re2 = from h in dt_measure.AsEnumerable()
                              where h.Field<string>("name") == "电导率"
                              select Convert.ToInt32(h.Field<object>("saveindex"));
                    foreach (int d in re2)
                    {
                        DDL_saveindex = d;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //读取电子表格
            dt_property = OperateExcel.ReadExcel("系统用溶解度表.xlsx");
            InitializeComponent();//初始化组建
                                  /// 订阅事件
            UpdateUI += new UpdateUIHandler(mainWnd.DoWork);
            UpdateUI += new UpdateUIHandler(onLineStatic.BeginThread);
            //定时器设置
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(ProvideData);
             timer.Tick += new EventHandler(DoWork);


            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            woker = new BackgroundWorker();//后台更新UI线程

            woker.DoWork += ComputeData;

        }
        private void DoWork(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
            if (!woker.IsBusy)
                woker.RunWorkerAsync();
            UpdateUI(this, new EventArgs());//触发事件


        }

        private void ProvideData(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //  ConstructString();
            string temp_str = "'" + DateTime.Now.ToString() + "',";
            foreach (DataRow row in dt_measure.Rows)
            {
                int i = Convert.ToInt32(row.Field<object>("saveindex"));
                if (i < 1)
                    continue;
                temp_str = temp_str + extractData.GetData(Convert.ToDouble(row.Field<object>("lower")), Convert.ToDouble(row.Field<object>("upper"))).ToString() + ",";
            }
            temp_str = temp_str.Remove(temp_str.Length - 1, 1);//构建插入的数据字符串
            temp_str = "insert into tb_lhf_data(" + strInsert + ") values(" + temp_str + ")";
            OleDbCommand cmd = new OleDbCommand(temp_str, con);
            cmd.ExecuteNonQuery();
        }
        private void OnClosed(object sender, EventArgs e)
        {
            con.Close();
        }
        private string ConstructString()//构建插入字符串（select字符串也可以用）
        {
            string str = "cytime,";
            foreach (DataRow row in dt_measure.Rows)
            {
                int i = Convert.ToInt32(row.Field<object>("saveindex"));
                if (i < 1)
                    continue;
                str = str + "v" + i.ToString() + ",";
            }
            str = str.Remove(str.Length - 1, 1);
            return str;//结果形如  cytime,v1,v2  存储索引为空的不要
        }
        private void ComputeData(object sender, EventArgs e)
        {
            string strSelct = "select " + strInsert + " from (select * from tb_lhf_data order by cytime desc) where rownum=1 and cytime is not null";
            OleDbCommand cmd = new OleDbCommand(strSelct, con);
            DataSet set = new DataSet();
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            adp.Fill(set);
            DataTable temp_dt = set.Tables[0];//获取参数数据表格
            double pHval = Convert.ToDouble(temp_dt.Rows[0].Field<object>("v" + pH_saveindex));//得到pH值
                                                                                               // double TVal = Convert.ToDouble(onLineStatic.TControl.Text);
            string strCytime = Convert.ToString(temp_dt.Rows[0].Field<object>("cytime"));
            var re = from h in dt_property.AsEnumerable()
                     where h.Field<double>("pH") == Math.Round(pHval, 1)
                     select h;//获取相同pH，不同温度下的属性表
            using (OleDbCommand temp_cmd = con.CreateCommand())
            {
                using (OleDbDataAdapter temp_adp = new OleDbDataAdapter(temp_cmd))
                {
                    DataTable inner_dt = new DataTable();
                    inner_dt.Columns.Add("cytime", typeof(string));
                    inner_dt.Columns.Add("pH", typeof(decimal));
                    inner_dt.Columns.Add("T", typeof(decimal));
                    inner_dt.Columns.Add("corro", typeof(decimal));
                    OleDbCommandBuilder build = new OleDbCommandBuilder(temp_adp);
                    temp_adp.SelectCommand.CommandText = "select * from tb_lhf_corro where rownum=0";
                    temp_adp.InsertCommand = build.GetInsertCommand();

                    foreach (var row in re)
                    {
                        double TVal = Convert.ToDouble(row["温度K"]);//得到温度值
                        double F = 1.5;
                        double Ceq = Convert.ToDouble(row["溶解度"]);
                        double h = 0.96;
                        double Kdp = Math.Exp(-1.6796 - 2900.8 / TVal);
                        double F_ = Math.Sqrt(3);
                        double Cb = 1e-2 * Ceq;
                        double Fai = 6e-4;
                        double DFe = 1e-12;
                        double Pox = 5.2;
                        double Di = 5;
                        double tao = 1;

                        double Denominator = 0.476 * (1.101 + Fai) * (1 / (h + Kdp * F) + Di * tao / (DFe * Pox * Fai * (1 - Fai)));//计算分母
                        double Moleculor = F * Ceq - 1 / (h + Kdp * F_) * (Kdp * F * Ceq + h * Cb);//计算分子
                        double corro = Moleculor / Denominator;//计算腐蚀速率

                        DataRow temp_row = inner_dt.NewRow();
                        temp_row["cytime"] = strCytime;
                        temp_row["pH"] = pHval;
                        temp_row["T"] = TVal;
                        temp_row["corro"] = corro*Math.Pow(10,-magnitude);
                        inner_dt.Rows.Add(temp_row);
                    }
                    int count = temp_adp.Update(inner_dt);
                }
            }
        }
    }
}
