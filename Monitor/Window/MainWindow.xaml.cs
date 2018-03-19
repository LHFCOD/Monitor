using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;
using System.Windows.Threading;

namespace Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        
      public  DateTime nowDate;
        StartPage wnd;//主窗口
        string nowT = "";
        public MainWindow()
        {
            InitializeComponent();
            wnd = (StartPage)Application.Current.MainWindow;
            try
            {
              
                if(wnd.con.State==ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("select * from tb_lhf_measure", wnd.con);
                    DataSet set = new DataSet();
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                    adp.Fill(set);

                    nowT = TControl.Text;
                    //dataGrid.Items.Clear();
                    //dataGrid.ItemsSource = set.Tables[0].DefaultView;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       public void DoWork(object sender,EventArgs e)
        {
            string strSelct = "select " + wnd.strInsert + " from (select * from tb_lhf_data order by cytime desc) where rownum=1 and cytime is not null";
            OleDbCommand cmd = new OleDbCommand(strSelct, wnd.con);
            DataSet set = new DataSet();
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            adp.Fill(set);
            DataTable temp_dt = set.Tables[0];//获取参数数据表格

          
            string nowDateString = Convert.ToString(temp_dt.Rows[0].Field<object>("cytime"));
            bool isSuccess = DateTime.TryParse(nowDateString, out nowDate);//从结果集中获取日期
            if (isSuccess)//如果转化日期成功
            {
                TimeControl.Content = nowDate.ToString();
            }
            else
            {
                //return;
            }

            string strSelctCorro = "select * from (select * from tb_lhf_corro order by cytime desc) where T=" + nowT + " and rownum=1";
            OleDbCommand cmdCorro = new OleDbCommand(strSelctCorro, wnd.con);
            DataSet setCorro = new DataSet();
            OleDbDataAdapter adpCorro = new OleDbDataAdapter(cmdCorro);
            adpCorro.Fill(setCorro);
            DataTable temp_dtCorro = setCorro.Tables[0];//获取参数数据表格
            double corro = Convert.ToDouble(temp_dtCorro.Rows[0].Field<object>("corro"));
            //////////////////////////////////主页面///////////////////////////////                                            
            DataTable dt = new DataTable();//主界面显示表
            //构建主页面表格结构
            dt.Columns.Add("位置", typeof(String));
            dt.Columns.Add("pH值", typeof(string));
            dt.Columns.Add("温度", typeof(string));
            dt.Columns.Add("压力", typeof(string));
            dt.Columns.Add("流速", typeof(string));
            dt.Columns.Add("溶解氧", typeof(string));
            dt.Columns.Add("颗粒态腐蚀产物直径", typeof(string));
            dt.Columns.Add("运行时间", typeof(string));
            foreach (DataRow row in wnd.dt_measure.Rows)
            {
                int i = Convert.ToInt32(row.Field<object>("saveindex"));
                if (i < 1)
                    continue;
                int location = Convert.ToInt32(row.Field<object>("location"));
                double pH = Convert.ToDouble(row.Field<object>("pH"));
                double Tem = Convert.ToDouble(row.Field<object>("Tem"));
                double Press = Convert.ToDouble(row.Field<object>("Press"));
                double V = Convert.ToDouble(row.Field<object>("V"));
                double Oxygen = Convert.ToDouble(row.Field<object>("Oxygen"));
                double D = Convert.ToDouble(row.Field<object>("D"));
                double realValue = 0;
                if (temp_dt.Rows.Count == 1)
                    realValue = Convert.ToDouble(temp_dt.Rows[0].Field<object>("v" + i.ToString()));
                else
                    realValue = -9999;
                if (i == 3)
                {
                    realValue = corro * Math.Pow(10, wnd.magnitude);//如果是腐蚀速率的话
                }

                DataRow temp_row = dt.NewRow();
                temp_row["位置"] = Convert.ToString(location);
                temp_row["pH值"] = Convert.ToString(pH);
                temp_row["温度"] = Convert.ToString(Tem);
                temp_row["压力"] = Convert.ToString(Press);
                temp_row["流速"] = Convert.ToString(V);
                temp_row["溶解氧"] = Convert.ToString(Oxygen);
                temp_row["颗粒态腐蚀产物直径"] = Convert.ToString(D);
                
                dt.Rows.Add(temp_row);
            }
            //mainWnd.dataGrid.Items.Clear();
            dataGrid.ItemsSource = dt.DefaultView;//设置主页面表格的数据源
           
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnTextLostFocus(object sender, RoutedEventArgs e)
        {

            nowT = TControl.Text;
        }
    }
}
