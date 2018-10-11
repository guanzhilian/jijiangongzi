using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace GongziSimple
{


    public partial class gongziDataSet
    {
        public DataTable QueryData(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(global::GongziSimple.Properties.Settings.Default.gongziConnectionString))
            {
                DataTable dt = new DataTable();
                dt.TableName = "result";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
        }

        public int ExecSQL(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(global::GongziSimple.Properties.Settings.Default.gongziConnectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int I = cmd.ExecuteNonQuery();
                conn.Close();
                return I;
            }
        }


        public decimal GetProdStepPrice(string ProdSpec, int step_seq, out string memo)
        {
            string sql = string.Format("select * from ProductStep where Prod_Spec='{0}'", ProdSpec);
            DataTable dt = QueryData(sql);
            if (dt.Rows.Count > 0)
            {
                string colName = "step" + (step_seq + 1);
                decimal price = 0;
                decimal.TryParse(dt.Rows[0][colName] + "", out price);
                memo = dt.Rows[0]["memo"] + "";
                return price;
            }
            else
            {
                memo = "";
                return 0;
            }
        }

        public int GetNewId(string table)
        {
            string sql = string.Format("select max_id from id_tbl where table ='{0}'", table);
            DataTable dt = QueryData(sql);
            int newId = (int)dt.Rows[0][0];
            sql = string.Format("update id_tbl set max_id="+(newId+1)+" where table ='{0}'", table);
            ExecSQL(sql);
            return newId;
        }

        public long NewId()
        {
            DateTime t1 = DateTime.Parse("2014-01-01");
            DateTime t2 = DateTime.UtcNow;
            TimeSpan t22 = t2 - t1;
            long time2 = Convert.ToInt64(t22.TotalMilliseconds);
            return time2;
        }
    }
}

namespace GongziSimple.gongziDataSetTableAdapters
{
    partial class ProductStepTableAdapter
    {
        public void InitAptCmd()
        {
            this.Adapter.DeleteCommand.CommandText = @"DELETE FROM `ProductStep` WHERE ((`ID` = ?))";
            this.Adapter.UpdateCommand.CommandText = @"UPDATE `ProductStep` SET `Prod_name` = ?, `Prod_Spec` = ?, `memo` = ?, `step1` = ?, `step2` = ?, `step3` = ?, `step4` = ?, `step5` = ?, `step6` = ?, `step7` = ?, `step8` = ?, `step9` = ?, `step10` = ? WHERE ((`ID` = ?))";
        }
    }

    partial class LoginLogTableAdapter
    {
    }

    partial class work_sheet_lineTableAdapter
    {
        public void InitAptCmd()
        {
            this.Adapter.DeleteCommand.CommandText = @"DELETE FROM `work_sheet_line` WHERE ((`ID` = ?))";
            this.Adapter.UpdateCommand.CommandText = @"UPDATE `work_sheet_line` SET `ID` = ?, `head_id` = ?, `prod_spec` = ?, `batch_code` = ?, `amount` = ?, `price` = ?, `sum` = ?, `memo` = ? WHERE ((`ID` = ?))";
        }
    }


    public partial class work_sheet_headTableAdapter
    {

        public virtual int Fill(gongziDataSet.work_sheet_headDataTable dataTable, OleDbCommand cmd)
        {
            this.Adapter.SelectCommand = cmd;
            if ((this.ClearBeforeFill == true))
            {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        public void InitAptCmd()
        {
            this.Adapter.DeleteCommand.CommandText = @"DELETE FROM `work_sheet_head` WHERE ((`ID` = ?))";
            this.Adapter.UpdateCommand.CommandText = @"UPDATE `work_sheet_head` SET `ID` = ?, `worker` = ?, `Prod_Step` = ?, `dept` = ?, `work_date` = ?, `modify_date` = ? WHERE ((`ID` = ?))";
        }
    }
}
