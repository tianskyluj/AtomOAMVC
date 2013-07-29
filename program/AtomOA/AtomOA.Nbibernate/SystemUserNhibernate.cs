using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic.Support;
using Spring.Data.NHibernate.Generic;
using SpringHiberate.dao.model;
using NHibernate;
using AtomOA.IDao;

namespace AtomOA.Nbibernate
{
    public class SystemUserNhibernate : HibernateDaoSupport, ISystemUserDao
    {
        #region IUserDao 成员

        public IList<AtomOA.Model.SystemUser> GetAllList()
        {
            return HibernateTemplate.LoadAll<AtomOA.Model.SystemUser>();
        }

        public IList<AtomOA.Model.SystemUser> GetList(string queryString)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" from SystemUser where 1=1 and ");
            if(queryString.Trim() == string.Empty)
                queryString = " 1=1 ";
            sb.Append(queryString);
            return HibernateTemplate.Find<AtomOA.Model.SystemUser>(sb.ToString());
        }

        public AtomOA.Model.SystemUser GetModelById(int Id)
        {
            return (AtomOA.Model.SystemUser)HibernateTemplate.Execute(new HibernateDelegate<AtomOA.Model.SystemUser>(delegate(NHibernate.ISession session)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("from SystemUser c  where c.Id=?");
                IQuery query = session.CreateQuery(sb.ToString());
                query.SetParameter(0, Id);
                return query.UniqueResult() as AtomOA.Model.SystemUser;
            }), true);
        }

        public bool Add(AtomOA.Model.SystemUser model)
        {
            if (HibernateTemplate.Save(model) != null)
            {
                return true;
            }
            return false;
        }

        public bool Update(AtomOA.Model.SystemUser model)
        {
            HibernateTemplate.Update(model);
            return true;
        }

        public bool AddOrUpdate(AtomOA.Model.SystemUser model)
        {
            HibernateTemplate.SaveOrUpdate(model);
            return true;
        }

        public bool Delete(AtomOA.Model.SystemUser model)
        {
            HibernateTemplate.Delete(model);
            return true;
        }

        #endregion
    }
}
