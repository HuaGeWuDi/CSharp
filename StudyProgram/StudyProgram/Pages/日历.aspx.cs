using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudyProgram.Pages
{
    public partial class 日历 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgBind();
                repBind();
            }
        }

        void repBind()
        {
            DataTable dt = new DataTable();

            DataColumn[] dcArr = new DataColumn[]
            {
              new DataColumn("xh"),
              new DataColumn("xm"),
              new DataColumn("nl"),
              new DataColumn("xb"),
            };
            dt.Columns.AddRange(dcArr);

            DataRow _row;          
            for (int i = 1; i <= 1000; i++)
            {    
                _row = dt.NewRow();
                _row[0] = "xh" + i;
                _row[1] = "xm" + i;
                _row[2] = "nl" + i;
                _row[3] = "xb" + i;
                dt.Rows.Add(_row);
            }
            rept.DataSource = dt;
            rept.DataBind();
        }

        void dgBind()
        {
            //10周
            int weeks = 10;
            var begindate = Convert.ToDateTime("2018-1-25");

            DataTable dt = new DataTable();

            //首先赋值列
            for (var i = 0; i <= 10; i++)
                dt.Columns.Add("col" + i, typeof(string));

            //加载行
            for (var i = 0; i <= 8; i++)
                dt.Rows.Add(dt.NewRow());

            //赋值所有行的第一列的值
            dt.Rows[0][0] = "周 次";
            dt.Rows[1][0] = "月 份";
            dt.Rows[2][0] = "星期一";
            dt.Rows[3][0] = "星期二";
            dt.Rows[4][0] = "星期三";
            dt.Rows[5][0] = "星期四";
            dt.Rows[6][0] = "星期五";
            dt.Rows[7][0] = "星期六";
            dt.Rows[8][0] = "星期日";

            //赋值第第一行的值
            for (var i = 1; i < weeks + 1; i++)
                dt.Rows[0][dt.Columns[i]] = i;

            //赋值第二列的值
            var week = GetWeekNum(begindate);//开始日期--周几
            for (var i = week + 1; i < dt.Rows.Count; i++)
            {
                dt.Rows[1][1] = IntToChinse(begindate.Month);
                dt.Rows[i][1] = begindate.Day;
                begindate = begindate.AddDays(1);
            }

            //赋值其他行和列的值
            for (var i = 2; i < dt.Columns.Count; i++)
            {
                for (var j = 1; j < dt.Rows.Count; j++)
                {
                    if (j == 1) //第一行中的列，月份
                    {
                        if (begindate.Day > 28)
                            dt.Rows[j][i] = IntToChinse(begindate.Month + 1);
                        else
                            dt.Rows[j][i] = IntToChinse(begindate.Month);
                    }
                    else
                    {
                        dt.Rows[j][i] = begindate.Day;
                        begindate = begindate.AddDays(1);
                    }
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ResetGV(GridView1, 1);
        }

        int GetWeekNum(DateTime date)
        {
            int res = 0;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    res = 1;
                    break;
                case DayOfWeek.Tuesday:
                    res = 2;
                    break;
                case DayOfWeek.Wednesday:
                    res = 3;
                    break;
                case DayOfWeek.Thursday:
                    res = 4;
                    break;
                case DayOfWeek.Friday:
                    res = 5;
                    break;
                case DayOfWeek.Saturday:
                    res = 6;
                    break;
                case DayOfWeek.Sunday:
                    res = 7;
                    break;
            }
            return res;
        }

        string IntToChinse(int i)
        {
            string revalue = "";
            switch (i)
            {
                case 1:
                    revalue = "一";
                    break;
                case 2:
                    revalue = "二";
                    break;
                case 3:
                    revalue = "三";
                    break;
                case 4:
                    revalue = "四";
                    break;
                case 5:
                    revalue = "五";
                    break;
                case 6:
                    revalue = "六";
                    break;
                case 7:
                    revalue = "七";
                    break;
                case 8:
                    revalue = "八";
                    break;
                case 9:
                    revalue = "九";
                    break;
                case 10:
                    revalue = "十";
                    break;
                case 11:
                    revalue = "十一";
                    break;
                case 12:
                    revalue = "十二";
                    break;
            }
            return revalue;
        }

        //合并相同的单元格
        void ResetGV(GridView gv, int row)
        {
            TableCell oldCell = gv.Rows[row].Cells[0];//第一列
            for (var i = 1; i < gv.Rows[row].Cells.Count; i++)
            {
                TableCell cell = gv.Rows[row].Cells[i];
                if (oldCell.Text == cell.Text)
                {
                    cell.Visible = false;
                    if (oldCell.ColumnSpan == 0)
                    {
                        oldCell.ColumnSpan = 1;
                    }
                    oldCell.ColumnSpan++;
                }
                else
                    oldCell = cell;
            }
        }
    }
}