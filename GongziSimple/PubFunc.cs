using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GongziSimple
{
    class PubFunc
    {
        static public void DataGridView2Excel(DataGridView dv, string sheetName, ToolStripProgressBar pb)
        {
            //建立Excel对象
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(System.Reflection.Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                if (sheetName != "")
                    objsheet.Name = sheetName;
            }
            catch
            {
                MessageBox.Show("您的机器上没有安装Excel，请安装后再使用此功能。");
                return;
            }

            int rowscount = dv.Rows.Count;
            int colscount = dv.Columns.Count;

            int displayColumnsCount = 1;
            for (int i = 0; i <= dv.ColumnCount - 1; i++)
            {
                if (dv.Columns[i].Visible == true)
                {
                    objExcel.Cells[1, displayColumnsCount] = dv.Columns[i].HeaderText.Trim();
                    displayColumnsCount++;
                }
            }

            if (pb != null)
            {
                pb.Minimum = 0;
                pb.Maximum = dv.RowCount;
            }
            //向Excel中逐行逐列写入表格中的数据
            for (int row = 0; row <= dv.RowCount - 1; row++)
            {
                displayColumnsCount = 1;
                for (int col = 0; col < colscount; col++)
                {
                    if (dv.Columns[col].Visible == true)
                    {
                        try
                        {
                            string s = dv.Rows[row].Cells[col].Value.ToString().Trim();
                            //非数字设置为文本格式
                            if (!IsNum(s))
                                objExcel.Cells[row + 2, displayColumnsCount].NumberFormatLocal = "@";

                            objExcel.Cells[row + 2, displayColumnsCount] = s;

                            displayColumnsCount++;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                if (pb != null)
                    pb.Value = row + 1;
            }
            objExcel.Visible = true;
        }

        public static bool IsNum(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsNumber(str, i) && str[i] != '.' && str[i] != '+' && str[i] != '-')
                    return false;

                if (i > 0 && (str[i] == '+' || str[i] == '-'))
                    return false;
            }
            return true;
        }
    }
}
