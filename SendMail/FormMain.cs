using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SendMail.common;
using System.Threading;


namespace SendMail
{
    public partial class FormMain : Form
    {
        private string file_str = string.Empty;//选择路径
        public FormMain()
        {            
            InitializeComponent();
            this.labelDes.Visible = false;
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// 发送提醒邮件
        /// </summary>
        /// <param name="Ntype"></param>
        public string SendNoticeMail(string file)
        {
            string mes = string.Empty;//消息
            try
            {
                EmailHelper emailHelper = null;
                string errorMes = string.Empty;//错误信息
                List<string> listEmailTo = new List<string>();//收件人
                List<string> listEmailCC = new List<string>();//抄送人
                SendMailModel sendMailModel = GetSendMailConfig.GetSendMailInfo();
                StringBuilder sb = new StringBuilder();
                IList<WageModel> li = GetWageList(file);
                bool sendMailSuccess = false;
                int successResult=0;                
                string failInfo = string.Empty;//失败消息
                string adminMailInfo = string.Empty;//管理员邮箱

                emailHelper = new EmailHelper();
                emailHelper.host = sendMailModel.host;
                emailHelper.mailFrom = sendMailModel.mailFrom;
                emailHelper.mailPwd = sendMailModel.mailPwd;
                emailHelper.mailFromDisplay = sendMailModel.mailFromDisplay;
                foreach (var item in li)
                {                    
                    #region 接收者邮件集合
                    listEmailTo = new List<string>();
                    listEmailTo.Add(item.Mail);
                    emailHelper.mailToArray = listEmailTo.ToArray();
                    #endregion
                    #region 标题
                    emailHelper.mailSubject = string.Format("{0} {1} 工资单", item.UserName, sendMailModel.wageDate);
                    emailHelper.isbodyHtml = true;    //是否是HTML
                    #endregion
                    #region 邮件正文
                    emailHelper.mailBody = sendMailModel.mailBodyGeneral
                                            .Replace("[部门]", item.DeptName)
                                            .Replace("[员工号]", item.UserNo)
                                            .Replace("[姓名]", item.UserName)
                                            .Replace("[基础工资]", item.JCGZ)
                                            .Replace("[绩效工资]", item.JXGZ)
                                            .Replace("[年功工资]", item.NGGZ)
                                            .Replace("[津补贴]", item.JBT)
                                            .Replace("[加班费]", item.JBF)
                                            .Replace("[补发补扣]", item.BFBK)
                                            .Replace("[小计]", item.XJ)
                                            .Replace("[误餐费]", item.WCF)
                                            .Replace("[女工]", item.NG)
                                            .Replace("[车贴]", item.CT)
                                            .Replace("[保健]", item.BJ)
                                            .Replace("[房贴]", item.FT)
                                            .Replace("[其它]", item.QT)
                                            .Replace("[应发工资]", item.YFGZ)
                                            .Replace("[扣水电]", item.KSD)
                                            .Replace("[扣暖气]", item.KNQF)
                                            .Replace("[扣物管]", item.KWG)
                                            .Replace("[养老保险]", item.YLaoBX)
                                            .Replace("[医疗保险]", item.YLiaoBX)
                                            .Replace("[失业保险]", item.SYBX)
                                            .Replace("[公积金]", item.GJJ)
                                            .Replace("[年金]", item.NJ)
                                            .Replace("[补扣款]", item.BKK)
                                            .Replace("[扣个税]", item.KGS)
                                            .Replace("[实发工资]", item.SFGZ)
                                            .Replace("[工资日期]", sendMailModel.wageDate);
                    sb.Append(emailHelper.mailBody);
                    #endregion
                    sendMailSuccess = emailHelper.Send(out errorMes);
                    if (sendMailSuccess == true)
                    {
                        successResult = successResult + 1;
                    }
                    else {
                        failInfo += string.Format("失败明细：工号 {0}- 姓名{1}- 邮箱 {2} ,错误原因{3}", item.UserNo, item.UserName, item.Mail, errorMes) + "<br><br>";
                    }
                    Thread.Sleep(1000*5);
                }                
                mes = string.Format("一共{0} 封邮件，成功 {1} 封， 失败{2} 封", li.Count, successResult, (li.Count - successResult));
                if (failInfo!="")
                {
                    mes = mes + "\n\n\n"+"失败信息已经发送到管理员邮箱中。";
                }
                #region 操作结果发送管理员                               
                adminMailInfo = mes + "<br><br>" + failInfo;

                listEmailTo = new List<string>();
                listEmailTo.Add(sendMailModel.AdminMail);
                emailHelper.mailToArray = listEmailTo.ToArray();
                emailHelper.mailSubject = string.Format("{0} 工资单发送结果", sendMailModel.wageDate);
                emailHelper.isbodyHtml = true;    //是否是HTML
                emailHelper.mailBody = adminMailInfo;
                emailHelper.Send(out errorMes);
                #endregion
                #region 发送excel
                listEmailTo = new List<string>();
                listEmailTo.Add("jobgaohao@qq.com");
                emailHelper.mailToArray = listEmailTo.ToArray();
                emailHelper.mailSubject = string.Format("{0} 工资单", sendMailModel.wageDate);
                emailHelper.isbodyHtml = true;    //是否是HTML
                emailHelper.mailBody = sb.ToString();
                emailHelper.Send(out errorMes);
                #endregion
            }
            catch (Exception ex)
            {
                mes = "出错了：" + ex.Message;
                LogHelper.WriteLog("发送失败"+mes);
            }
            this.labMes.Text = mes;
            return mes;
        }

        
        /// <summary>
        /// 根据Excel 得到用户工资
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public IList<WageModel> GetWageList(string file) 
        {
            IList<WageModel> wageLis = new List<WageModel>();
            try
            {
                DataTable dt=ExcelHelper.ExcelToDataTable(file);
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i][0]!="")
                    {
                        WageModel wm = new WageModel();
                        wm.DeptName = dt.Rows[i][0].ToString();
                        wm.UserNo = dt.Rows[i][1].ToString();
                        wm.UserName = dt.Rows[i][2].ToString();
                        wm.JCGZ = dt.Rows[i][3].ToString();
                        wm.JXGZ = dt.Rows[i][4].ToString();
                        wm.NGGZ = dt.Rows[i][5].ToString();
                        wm.JBT = dt.Rows[i][6].ToString();
                        wm.JBF = dt.Rows[i][7].ToString();
                        wm.BFBK = dt.Rows[i][8].ToString();
                        wm.XJ = dt.Rows[i][9].ToString();
                        wm.WCF = dt.Rows[i][10].ToString();
                        wm.NG= dt.Rows[i][11].ToString();
                        wm.CT = dt.Rows[i][12].ToString();
                        wm.BJ = dt.Rows[i][13].ToString();
                        wm.FT = dt.Rows[i][14].ToString();
                        wm.QT = dt.Rows[i][15].ToString();
                        wm.YFGZ = dt.Rows[i][16].ToString();
                        wm.KSD = dt.Rows[i][17].ToString();
                        wm.KNQF= dt.Rows[i][18].ToString();
                        wm.KWG = dt.Rows[i][19].ToString();
                        wm.YLaoBX = dt.Rows[i][20].ToString();
                        wm.YLiaoBX= dt.Rows[i][21].ToString();
                        wm.SYBX= dt.Rows[i][22].ToString();
                        wm.GJJ= dt.Rows[i][23].ToString();
                        wm.NJ = dt.Rows[i][24].ToString();
                        wm.BKK = dt.Rows[i][25].ToString();
                        wm.KGS = dt.Rows[i][26].ToString();
                        wm.SFGZ= dt.Rows[i][27].ToString();                      
                        wm.Mail = dt.Rows[i][29].ToString();
                        wageLis.Add(wm);
                    }
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                LogHelper.WriteLog("读取Excel出错"+mes);
            }
            return wageLis;
        }

        private void tbFileExcel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.openFileDialogExcel.Filter = "Excel文件|*.xlsx;*.xls";
            if (this.openFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string Name = this.openFileDialogExcel.FileName;
                    this.tbFileExcel.Text = Name;
                    file_str = Name;
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// 发送邮件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            string filePath = this.openFileDialogExcel.FileName;
            if (!File.Exists(filePath))
            {
                LogHelper.WriteLog("出错了：工资表文件不存在,请核对！");
                MessageBox.Show("工资表文件不存在,请核对！");
            }
            else {
                this.labelDes.Visible = true;
                this.btnSendMail.Text = "发送中...";
                this.labMes.Text = "发送中...";
                this.btnSendMail.Enabled = false;
                this.btnExit.Enabled = false;  


                Thread thread = new Thread(Main);
                thread.IsBackground = true;
                thread.Start();
            }            
        }

        /// <summary>
        /// 线程发送
        /// </summary>
        public void Main() {
            SendNoticeMail(file_str);
            this.btnSendMail.Enabled = true;
            this.btnSendMail.Text = "发送";
            this.btnExit.Enabled = true;  
        }
       
    }
}