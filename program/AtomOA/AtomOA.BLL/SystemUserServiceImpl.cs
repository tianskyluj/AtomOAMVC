using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomOA.IBLL;
using AtomOA.IDao;
using AtomOA.Model;

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

        #endregion
    }
}
