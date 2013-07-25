using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomOA.Model
{
    /// <summary>
    /// SystemUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GlobalSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set;
            get;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int state
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int createUser
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string createIp
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createTime
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int updateUser
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string updateIp
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime updateTime
        {
            set;
            get;
        }
    }
}
