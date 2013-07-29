using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomOA.Common
{
    public class DataSession
    {
        public DataSession()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        // 销毁session 数据
        public static void destroySession()
        {
            HttpContext.Current.Session.Clear();
        }

        //取得Session中的变量值
        public static string getSessionValue(string Sessinname)
        {
            string _str = "";
            try
            {
                _str = HttpContext.Current.Session[Sessinname].ToString();
            }
            catch
            {

            }
            return _str;
        }

        //设置Session变量及值
        public static void setSession(string Sessionname, object Sessionvalue)
        {
            HttpContext.Current.Session[Sessionname] = Sessionvalue;
        }

        /// <summary>
        /// 获取全局设置
        /// </summary>
        /// <returns></returns>
        public static AtomOA.Model.GlobalSetting GetGlobalSession()
        {
            AtomOA.Model.GlobalSetting globalObj = new Model.GlobalSetting();
            globalObj.CompanyName = getSessionValue("globalCompanyName");

            return globalObj;
        }

        /// <summary>
        /// 设置全局设置
        /// </summary>
        /// <param name="value"></param>
        public static void SetGlobaSession(AtomOA.Model.GlobalSetting globalObj)
        {
            setSession("globalCompanyName", globalObj.CompanyName);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public static AtomOA.Model.SystemUser GetUserSession()
        {
            AtomOA.Model.SystemUser userObj = new Model.SystemUser();
            userObj.Id = getSessionValue("currentUserId").ToInt();
            userObj.UserName = getSessionValue("currentUserName");
            userObj.Name = getSessionValue("currentName");
            userObj.IfAdmin = getSessionValue("currentIfAdmin").ToInt();

            return userObj;
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="value"></param>
        public static void SetUserSession(AtomOA.Model.SystemUser userObj)
        {
            setSession("currentUserId", userObj.Id);
            setSession("currentUserName", userObj.UserName);
            setSession("currentName", userObj.Name);
            setSession("currentIfAdmin", userObj.IfAdmin);
        }
    }
}
