using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomOA.IBLL;
using AtomOA.IDao;
using AtomOA.Model;
using System.IO;
using AtomOA.Common.Sys;

namespace AtomOA.BLL
{
    public class SystemUserServiceImpl : ISystemUserService
    {
        #region 属性

        private ISystemUserDao systemUserDao;

        public ISystemUserDao SystemUserDao
        {
            get { return systemUserDao; }
            set { systemUserDao = value; }
        }

        #endregion

        #region IUserService 成员

        public IList<SystemUser> GetAllList()
        {
            return systemUserDao.GetAllList(); 
        }

        public IList<SystemUser> GetList(string queryString)
        {
            return systemUserDao.GetList(queryString);
        }

        public bool Update(SystemUser model)
        {
            return systemUserDao.Update(model);
        }

        public bool Delete(SystemUser model)
        {
            return systemUserDao.Delete(model);
        }

        public bool Add(SystemUser model)
        {
            return systemUserDao.Add(model);
        }

        public bool UpdateOrAdd(SystemUser model)
        {
            return systemUserDao.AddOrUpdate(model);
        }

        public SystemUser GetModelById(int id)
        {
            return systemUserDao.GetModelById(id);
        }

        public bool CheckLogin(SystemUser model)
        {
            IList<SystemUser> userList = systemUserDao.GetList(" username='"+model.UserName.ToString()+"' and passWord='"+ AtomOA.Common.DEncrypt.DEncrypt.Encrypt(model.PassWord.ToString())+"'");
            if (userList.Count > 0)
            {
                AtomOA.Common.DataSession.SetUserSession(userList[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetUserAvatar()
        {
            string fileUrl = AtomOA.Common.inc.getApplicationPath() + "/Upload/Avatar/" + AtomOA.Common.DataSession.GetUserSession().Id.ToString() + "_avatar.txt";
            string avatarString = "";

            StreamReader sr;
            if (System.IO.File.Exists(SysHelper.GetPath(fileUrl)))
            {
                sr = System.IO.File.OpenText(SysHelper.GetPath(fileUrl));
                avatarString = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }

            return avatarString;
        }

        public string GetUserAvatar(string userId)
        {
            string fileUrl = AtomOA.Common.inc.getApplicationPath() + "/Upload/Avatar/" + userId.Trim() + "_avatar.txt";
            string avatarString = "";

            StreamReader sr;
            if (System.IO.File.Exists(SysHelper.GetPath(fileUrl)))
            {
                sr = System.IO.File.OpenText(SysHelper.GetPath(fileUrl));
                avatarString = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }

            return avatarString;
        }

        #endregion
    }
}
