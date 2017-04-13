using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace SendMail.common
{
    public static class ExcelHelper
    {
        /// <summary>
        /// 将Excel数据读到DataTable中
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string fileFullName)
        {
            DataTable dt = null;

            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\";", fileFullName);
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter da = null;
            string strExcel = "select * from [{0}]";

            try
            {
                conn.Open();
                DataTable schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                //下面取得第一个表名   
                string strTableName = string.Empty;

                for (int i = 0; i < schema.Rows.Count; i++)
                {
                    strTableName = ConvertToString(schema.Rows[i]["TABLE_NAME"]);

                    if (!string.IsNullOrEmpty(strTableName) && strTableName.Contains("$"))
                    {
                        break;
                    }
                }

                DataSet ds = new DataSet();
                da = new OleDbDataAdapter(string.Format(strExcel, strTableName), strConn);
                da.Fill(ds);

                if (ds != null && ds.Tables.Count >= 1)
                    dt = ds.Tables[0];

                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误!:" + ex.Message.ToString());
                LogHelper.WriteLog("读取excel失败---》"+ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        public static string ConvertToString(object obj)
        {
            string val = string.Empty;

            if (obj != null)
            {
                val = obj.ToString().Trim();
            }

            return val;
        }



        /// <summary>
        /// EXCEL数据转换DataSet
        /// </summary>
        /// <param name="filePath">文件全路径</param>        
        /// <returns></returns>       
        public static DataSet ExcelToDataSet(string fileName)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";
            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            DataSet ds = new DataSet();
            List<string> List = new List<string> { };
            DataTable dtSheetName = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow dr in dtSheetName.Rows)
            {
                if (dr["Table_Name"].ToString().Contains("$") && !dr[2].ToString().EndsWith("$"))
                {
                    continue;
                }
                string s = dr["Table_Name"].ToString();
                List.Add(s);
            }
            try
            {
                for (int i = 0; i < List.Count; i++)
                {
                    ds.Tables.Add(List[i]);
                    string SheetName = List[i];
                    string strSql = "select * from [" + SheetName + "]";
                    OleDbDataAdapter odbcCSVDataAdapter = new OleDbDataAdapter(strSql, objConn);
                    DataTable dt = ds.Tables[i];
                    odbcCSVDataAdapter.Fill(dt);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
        }




    }
}
