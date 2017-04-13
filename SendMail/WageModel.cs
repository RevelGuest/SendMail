using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendMail
{
    public  class WageModel
    {
        /// <summary>
        /// 部门名字
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 基础工资
        /// </summary>
        public string JCGZ { get; set; }

        /// <summary>
        /// 绩效工资
        /// </summary>
        public string JXGZ { get; set; }

        /// <summary>
        /// 年工工资
        /// </summary>
        public string NGGZ { get; set; }

        /// <summary>
        /// 津补贴
        /// </summary>
        public string JBT { get; set; }

        /// <summary>
        /// 加班费
        /// </summary>
        public string JBF { get; set; }

        /// <summary>
        /// 补发补扣
        /// </summary>
        public string BFBK { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        public string XJ { get; set; }

        /// <summary>
        /// 午餐费
        /// </summary>
        public string WCF { get; set;}

        /// <summary>
        /// 女工
        /// </summary>
        public string NG { get; set; }

        /// <summary>
        /// 车贴
        /// </summary>
        public string CT { get; set; }

        /// <summary>
        /// 保健
        /// </summary>
        public string BJ { get; set; }

        /// <summary>
        /// 房帖
        /// </summary>
        public string FT { get; set; }

        /// <summary>
        /// 其它
        /// </summary>
        public string QT { get; set; }

        /// <summary>
        /// 应发工资
        /// </summary>
        public string YFGZ { get; set; }

        /// <summary>
        /// 扣水电
        /// </summary>
        public string KSD { get; set; }

        /// <summary>
        /// 扣暖气费
        /// </summary>
        public string KNQF { get; set; }

        /// <summary>
        /// 扣物管
        /// </summary>
        public string KWG { get; set; }

        /// <summary>
        /// 养老保险
        /// </summary>
        public string YLaoBX { get; set; }

        /// <summary>
        /// 医疗保险
        /// </summary>
        public string YLiaoBX { get; set; }

        /// <summary>
        /// 失业保险
        /// </summary>
        public string SYBX { get; set; }

        /// <summary>
        /// 公积金
        /// </summary>
        public string GJJ { get; set; }

        /// <summary>
        /// 年金
        /// </summary>
        public string NJ { get; set; }

        /// <summary>
        /// 补扣款
        /// </summary>
        public string BKK { get; set; }

        /// <summary>
        /// 扣个税
        /// </summary>
        public string KGS { get; set; }

        /// <summary>
        /// 实发工资
        /// </summary>
        public string SFGZ { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }
    }
}
