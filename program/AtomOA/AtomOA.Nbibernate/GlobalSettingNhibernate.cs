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
    public class GlobalSettingNhibernate : HibernateDaoSupport, IGlobalSettingDao
    {
        #region IUserDao 成员

        public IList<AtomOA.Model.GlobalSetting> GetAllList()
        {
            return HibernateTemplate.LoadAll<AtomOA.Model.GlobalSetting>();
        }

        public AtomOA.Model.GlobalSetting GetModelById(int Id)
        {
            return (AtomOA.Model.GlobalSetting)HibernateTemplate.Execute(new HibernateDelegate<AtomOA.Model.GlobalSetting>(delegate(NHibernate.ISession session)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("from SystemUser c  where c.Id=?");
                IQuery query = session.CreateQuery(sb.ToString());
                query.SetParameter(0, Id);
                return query.UniqueResult() as AtomOA.Model.GlobalSetting;
            }), true);
        }

        public bool Add(AtomOA.Model.GlobalSetting model)
        {
            if (HibernateTemplate.Save(model) != null)
            {
                return true;
            }
            return false;
        }

        public bool Update(AtomOA.Model.GlobalSetting model)
        {
            HibernateTemplate.Update(model);
            return true;
        }

        public bool AddOrUpdate(AtomOA.Model.GlobalSetting model)
        {
            HibernateTemplate.SaveOrUpdate(model);
            return true;
        }

        public bool Delete(AtomOA.Model.GlobalSetting model)
        {
            HibernateTemplate.Delete(model);
            return true;
        }

        #endregion
    }
}
