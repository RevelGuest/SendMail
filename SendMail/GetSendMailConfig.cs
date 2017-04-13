using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SendMail
{
    /// <summary>
    /// 获取邮件发送人
    /// </summary>
    public class GetSendMailConfig
    {
        /// <summary>
        /// 获取发送对象
        /// </summary>
        /// <returns></returns>
        public static SendMailModel GetSendMailInfo()
        {
            SendMailModel sendMailModel = new SendMailModel();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "config\\SendMail.config";
            XDocument xDoc = XDocument.Load(path);           

            var mailModelGeneral = from e1 in xDoc.Descendants("MailModelGeneral") select e1;
            foreach (XElement xe in mailModelGeneral)
            {
                sendMailModel.mailBodyGeneral = xe.ToString();
            }

            var host = from e1 in xDoc.Descendants("host") select e1;
            foreach (XElement xe in host)
            {
                sendMailModel.host = xe.Value.Trim();
            }

            var mailFrom = from e1 in xDoc.Descendants("mailFrom") select e1;
            foreach (XElement xe in mailFrom)
            {
                sendMailModel.mailFrom = xe.Value.Trim();
            }

            var mailPwd = from e1 in xDoc.Descendants("mailPwd") select e1;
            foreach (XElement xe in mailPwd)
            {
                sendMailModel.mailPwd = xe.Value.Trim();
            }

            var mailFromDisplay = from e1 in xDoc.Descendants("mailFromDisplay") select e1;
            foreach (XElement xe in mailFromDisplay)
            {
                sendMailModel.mailFromDisplay = xe.Value.Trim();
            }


            var wageDate = from e1 in xDoc.Descendants("wageDate") select e1;
            foreach (XElement xe in wageDate)
            {
                sendMailModel.wageDate = xe.Value.Trim();
            }


            var AdminMail = from e1 in xDoc.Descendants("AdminMail") select e1;
            foreach (XElement xe in AdminMail)
            {
                sendMailModel.AdminMail = xe.Value.Trim();
            }


            return sendMailModel;
        }
    }

    /// <summary>
    /// 发送邮件config对象
    /// </summary>
    public class SendMailModel
    {        
        /// <summary>
        /// 一般消息模板
        /// </summary>
        public string mailBodyGeneral { get; set; }

        /// <summary>
        /// 邮箱HOST
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// 发件箱
        /// </summary>
        public string mailFrom { get; set; }

        /// <summary>
        /// 发件箱密码
        /// </summary>
        public string mailPwd { get; set; }

        /// <summary>
        /// 发件箱展示名字
        /// </summary>
        public string mailFromDisplay { get; set; }

        /// <summary>
        /// 工资时间
        /// </summary>
        public string wageDate { get; set; }

        /// <summary>
        /// 管理员邮箱
        /// </summary>
        public string AdminMail { get; set; }
    }
}
