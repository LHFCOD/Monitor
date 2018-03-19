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
using System.Data.OleDb;
using System.Data;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using System.ComponentModel;

namespace Monitor
{
    /// <summary>
    /// Interaction logic for OnLineStatic.xaml
    /// </summary>
    public class Widiget
    {
      public  Label lable;
      public   Ellipse ellipse;
    }
    public partial class OnLineStatic : UserControl
    {
        int display_count = 200;//曲线显示点数
        LineGraph line;//当前曲线对象
        LineGraph line_upper;//当前曲线上限对象
        LineGraph line_lower;//当前曲线下限对象

       
        //数据源
        CompositeDataSource composite;//组合的最终数据源
        EnumerableDataSource<DateTime> x;//x轴数据源
        EnumerableDataSource<double> y;//y轴数据源

        List<DateTime> temp_datelist;//暂时存放时间x轴数据
        List<double> temp_ylist;///暂时存放y轴数据
        //upper数据源
        CompositeDataSource composite_upper;//组合的最终数据源
        EnumerableDataSource<DateTime> x_upper;//x轴数据源
        EnumerableDataSource<double> y_upper;//y轴数据源

        List<DateTime> temp_datelist_upper;//暂时存放时间x轴数据
        List<double> temp_ylist_upper;///暂时存放y轴数据
        //lower数据源
        CompositeDataSource composite_lower;//组合的最终数据源
        EnumerableDataSource<DateTime> x_lower;//x轴数据源
        EnumerableDataSource<double> y_lower;//y轴数据源

        List<DateTime> temp_datelist_lower;//暂时存放时间x轴数据
        List<double> temp_ylist_lower;///暂时存放y轴数据
       
        StartPage wnd;//定义起始页面
        public List<string> list = new List<string>();//下拉列表数据存储链表
        DataTable dt;//参数定义表格
        int nowSelectIndex = 0;//当前下拉列表选择索引
        BackgroundWorker woker;//后台线程管理者

        List<Widiget> list_widiget;
        
        public OnLineStatic()
        {
            InitializeComponent();
            wnd = (StartPage)Application.Current.MainWindow;
          //  line = plotter.AddLineGraph(dataSource1, Colors.Green, 2, "PH");//添加曲线


          string strSelect = "select * from tb_lhf_measure where saveindex is not null";
            OleDbConnection con = wnd.con;
            if (con.State == ConnectionState.Open)
            {
                OleDbCommand cmd = new OleDbCommand(strSelect, con);
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                DataSet set = new DataSet();
                adp.Fill(set);
                dt = set.Tables[0];
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToString(dt.Rows[i].Field<object>("name")));
                }

                preSelectIndex.ItemsSource = list;//设置组合框数据源
                preSelectIndex.SelectedIndex = nowSelectIndex;

                temp_datelist = new List<DateTime>();
                temp_ylist = new List<double>();

                x = new EnumerableDataSource<DateTime>(temp_datelist);
                x.SetXMapping(x => xAxis.ConvertToDouble(x));
                y = new EnumerableDataSource<double>(temp_ylist);
                y.SetYMapping(y => y);
                composite = new CompositeDataSource(x, y);
                line = plotter.AddLineGraph(composite, Colors.Green, 2, list.ElementAt(nowSelectIndex));//添加曲线
                if (dt.Rows[nowSelectIndex].Field<object>("upper") != null)
                {
                    temp_datelist_upper = new List<DateTime>();
                    temp_ylist_upper = new List<double>();

                    x_upper = new EnumerableDataSource<DateTime>(temp_datelist_upper);
                    x_upper.SetXMapping(x_upper => xAxis.ConvertToDouble(x_upper));
                    y_upper = new EnumerableDataSource<double>(temp_ylist_upper);
                    y_upper.SetYMapping(y_upper => y_upper);
                    composite_upper = new CompositeDataSource(x_upper, y_upper);
                    
                    Pen pen = new Pen();
                    pen.Brush = new SolidColorBrush(Colors.Red);
                    pen.DashStyle = new DashStyle(new double[] { 2, 5 },2);
                    pen.Thickness = 2;//新建虚线画笔
                  
                    PenDescription description = new PenDescription("上限");
                    line_upper = plotter.AddLineGraph(composite_upper,pen,description);//添加上曲线
                    
                }
                if (dt.Rows[nowSelectIndex].Field<object>("lower") != null)
                {
                    temp_datelist_lower = new List<DateTime>();
                    temp_ylist_lower = new List<double>();

                    x_lower = new EnumerableDataSource<DateTime>(temp_datelist_lower);
                    x_lower.SetXMapping(x_lower => xAxis.ConvertToDouble(x_lower));
                    y_lower = new EnumerableDataSource<double>(temp_ylist_lower);
                    y_lower.SetYMapping(y_lower => y_lower);
                    composite_lower = new CompositeDataSource(x_lower, y_lower);

                    Pen pen = new Pen();
                    pen.Brush = new SolidColorBrush(Colors.Red);
                    pen.DashStyle = new DashStyle(new double[] { 2, 5 }, 2);
                    pen.Thickness = 2;//新建虚线画笔

                    PenDescription description = new PenDescription("下限");
                    line_upper = plotter.AddLineGraph(composite_lower, pen, description);//添加下限曲线
                }
                list_widiget = new List<Widiget>();//警示灯链表
                for(int i=0;i<dt.Rows.Count-1;i++)
                {
                    Label lable = new Label();
                    lable.Content = dt.Rows[i].Field<object>("name");
                    lable.VerticalContentAlignment = VerticalAlignment.Center;
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 20;
                    ellipse.Height = 20;
                    ellipse.Fill = new SolidColorBrush(Colors.Green);
                    ellipse.Stroke = new SolidColorBrush(Colors.Black);
                    ellipse.StrokeThickness = 2;
                    Widiget widiget = new Widiget();
                    widiget.lable = lable;//设置标签
                    widiget.ellipse = ellipse;//设置警示灯
                    list_widiget.Add(widiget);//添加到窗口部件链表

                    wnd_lower.Children.Add(lable);
                    wnd_lower.Children.Add(ellipse);
                }

            }
            else
            {
                return;
            }
          
            woker = new BackgroundWorker();//后台更新UI线程
            woker.DoWork += DoWork;
        }
        public void BeginThread(object sender,EventArgs e)
        {
            if (!woker.IsBusy)
                woker.RunWorkerAsync();
        }
        public void DoWork(object sender,EventArgs e)
        {
            //////////////////////////////////指标在线监测///////////////////////////////
            //更新时间
            Dispatcher.Invoke(new Action(() => { TimeControl.Content = wnd.mainWnd.nowDate.ToString(); })) ;
            string Tstr ="";
                Dispatcher.Invoke(new Action(() => {Tstr=TControl.Text; }));
            string strSelect= "select * from(select * from tb_lhf_data order by id desc) where rownum  <= " + display_count.ToString() + " and cytime is not null"; ;
          
            string strSelectCorro = "select * from(select * from tb_lhf_corro order by cytime desc) where rownum  <= " + display_count.ToString() + " and cytime is not null and T="+Tstr;
            OleDbConnection con = wnd.con;
            int nowSaveIndex = Convert.ToInt32(dt.Rows[nowSelectIndex].Field<object>("saveindex"));

            if (con.State == ConnectionState.Open)
            {
                
                DataTable temp_dt = GetTable(strSelect,con);//第一数据表
                DataTable temp_dtCorro = GetTable(strSelectCorro, con);//第二数据表
                temp_datelist.Clear();
                temp_ylist.Clear();

                temp_datelist_upper.Clear();
                temp_ylist_upper.Clear();


                temp_datelist_lower.Clear();
                temp_ylist_lower.Clear();
                for (int i = 1; i <= temp_dt.Rows.Count; i++)
                {
                    double temp_data=0;
                    string str = "";
                    if (nowSelectIndex != 2)
                    {
                        temp_data = Convert.ToDouble(temp_dt.Rows[i - 1].Field<object>("v" + nowSaveIndex));
                        str = Convert.ToString(temp_dt.Rows[i - 1].Field<object>("cytime"));
                    }
                    else if (nowSelectIndex == 2)
                    {
                        temp_data = Convert.ToDouble(temp_dtCorro.Rows[i - 1].Field<object>("corro"));
                        str = Convert.ToString(temp_dtCorro.Rows[i - 1].Field<object>("cytime"));
                    }

                    
                    DateTime date = DateTime.Parse(str);
                    temp_datelist.Add(date);
                    temp_ylist.Add(temp_data);

                    if (dt.Rows[nowSelectIndex].Field<object>("upper") != null)
                    {
                        double upper = Convert.ToDouble(dt.Rows[nowSelectIndex].Field<object>("upper"));
                        temp_datelist_upper.Add(date);
                        temp_ylist_upper.Add(upper);
                    }
                    if (dt.Rows[nowSelectIndex].Field<object>("lower") != null)
                    {
                        double lower = Convert.ToDouble(dt.Rows[nowSelectIndex].Field<object>("lower"));
                        temp_datelist_lower.Add(date);
                        temp_ylist_lower.Add(lower);
                    }
                }
               
                Dispatcher.Invoke(new Action(()=> { x.RaiseDataChanged(); }));//更新x轴数据源
                Dispatcher.Invoke(new Action(() => { y.RaiseDataChanged(); }));//更新y轴数据源        
                if (dt.Rows[nowSelectIndex].Field<object>("upper") != null)
                {
                    
                    Dispatcher.Invoke(new Action(() => { x_upper.RaiseDataChanged(); }));//更新x轴数据源
                    Dispatcher.Invoke(new Action(() => { y_upper.RaiseDataChanged(); }));//更新y轴数据源        
                }
                if (dt.Rows[nowSelectIndex].Field<object>("lower") != null)
                {
                    Dispatcher.Invoke(new Action(() => { x_lower.RaiseDataChanged(); }));//更新x轴数据源
                    Dispatcher.Invoke(new Action(() => { x_lower.RaiseDataChanged(); }));//更新y轴数据源        
                }

              

                var re1 = from h in temp_dt.AsEnumerable()
                         orderby h.Field<object>("cytime") descending
                         select h;
                var re2 = from h in temp_dtCorro.AsEnumerable()
                          orderby h.Field<object>("cytime") descending
                          select h;
                for (int i=0;i<list_widiget.Count-1;i++)//更新警示灯
                {
                    int temp_SaveIndex = Convert.ToInt32(dt.Rows[i].Field<object>("saveindex"));
                    double realValue=0;
                    if (i!=2)
                     realValue = Convert.ToDouble(re1.ElementAt(0).Field<object>("v" + temp_SaveIndex));
                    else if(i==2)
                        realValue= Convert.ToDouble(re2.ElementAt(0).Field<object>("corro"));
                    double upperValue = Convert.ToDouble(dt.Rows[i].Field<object>("upper"));
                    double lowerValue = Convert.ToDouble(dt.Rows[i].Field<object>("lower"));
                    if(realValue>upperValue || realValue<lowerValue)
                    {
                      Dispatcher.Invoke(new Action(()=> { list_widiget[i].ellipse.Fill = new SolidColorBrush(Colors.Red); }));
                    }
                    else
                    {
                        Dispatcher.Invoke(new Action(() => { list_widiget[i].ellipse.Fill = new SolidColorBrush(Colors.Green); }));
                    }
                }

            }
            else
            {
                return;
            }

        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nowSelectIndex = preSelectIndex.SelectedIndex;
            string name = preSelectIndex.SelectedValue.ToString();
            if(line!=null)
            line.Description = new PenDescription(name);
        }
        private DataTable GetTable(string strSql,OleDbConnection con)
        {
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            DataSet set = new DataSet();
            OleDbDataAdapter adpCorro = new OleDbDataAdapter(cmd);
            adpCorro.Fill(set);
            DataTable temp_dt = set.Tables[0];//获取参数数据表格
            return temp_dt;
        }
    }
}
