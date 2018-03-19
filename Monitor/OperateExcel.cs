using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data;
namespace Monitor
{
    class OperateExcel
    {
        public string filename;
        Excel.Application excelApp;
        static int max_column = 30;
        static int max_row = 20000;
        public OperateExcel(string _filename)
        {
            filename = _filename;
            excelApp = new Excel.Application();
            excelApp.Application.Workbooks.Add(true);

            object misValue = System.Reflection.Missing.Value;

            if(File.Exists(filename))
            {
                File.Delete(filename);
                excelApp.ActiveWorkbook.SaveAs(filename, misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            else
            {
                excelApp.ActiveWorkbook.SaveAs(filename, misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
        }
        public static DataTable ReadExcel(string _filename)
        {
            DataTable temp_dt = new DataTable();
            try
            {
                //启动Excel应用程序
                Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                //    _Workbook book = xls.Workbooks.Add(Missing.Value); //创建一张表，一张表可以包含多个sheet

                //如果表已经存在，可以用下面的命令打开
                Microsoft.Office.Interop.Excel._Workbook book = xls.Workbooks.Open(System.Environment.CurrentDirectory + @"\" + _filename);

                Microsoft.Office.Interop.Excel._Worksheet sheet;//定义sheet变量
                xls.Visible = false;//设置Excel后台运行
                xls.DisplayAlerts = false;//设置不显示确认修改提示
                sheet = (Microsoft.Office.Interop.Excel._Worksheet)book.Worksheets.get_Item(1);//获得第i个sheet，准备写入
                //构建datatable,列数不超过30
                for (int index = 0; index < max_column; index++)
                {
                    Microsoft.Office.Interop.Excel.Range temp_range = sheet.Cells[1, index + 1];
                    if (temp_range.Value == null)
                        break;
                    else
                    {
                        string column_name = Convert.ToString(temp_range.Value);
                        temp_dt.Columns.Add(new DataColumn(column_name, typeof(double)));
                    }
                }
                if (temp_dt.Columns.Count > 0)//如果构建表格成功,添加记录不超过2000行
                {
                    for (int index = 2; index < max_row+2; index++)
                    {
                        DataRow row = temp_dt.NewRow();
                        Microsoft.Office.Interop.Excel.Range result = sheet.Cells[index, 1];
                        if (result.Value == null)
                            break;
                        for (int j = 0; j < temp_dt.Columns.Count; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range temp_range = sheet.Cells[index, j + 1];
                            if (temp_range.Value == null)
                                break;
                            else
                            {
                                double value = Convert.ToDouble(temp_range.Value);
                                row[j] = value;
                            }
                        }
                        temp_dt.Rows.Add(row);
                    }
                }
                xls.Quit();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            return temp_dt;
        }
        public bool AddToSheet(DataTable dt)
        {
            Excel._Workbook workbook = excelApp.Workbooks.Open(filename);
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;
            workbook.Worksheets.Add();
            int count = workbook.Worksheets.Count;
            Excel._Worksheet sheet = workbook.Worksheets.get_Item(1);
            for(int i=0;i<dt.Columns.Count;i++)
            {
                sheet.Cells[1, i + 1] = dt.Columns[i].Caption;
            }
            for(int i=0;i<dt.Columns.Count;i++)
                for(int j=0;j<dt.Rows.Count;j++)
                {
                    sheet.Cells[j + 2, i + 1] = dt.Rows[j].Field<object>(i);
                }
            workbook.Save();
            workbook.Close();
            return true;
        }
         ~OperateExcel()
        {
            excelApp.Quit();
        }
    }
}
