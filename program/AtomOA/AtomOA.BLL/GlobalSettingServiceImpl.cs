using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomOA.IBLL;
using AtomOA.IDao;
using AtomOA.Model;

namespace AtomOA.BLL
{
    public class GlobalSettingServiceImpl:IGlobalSettingService
    {
        #region 属性

        private IGlobalSettingDao globalSettingDao;

        public IGlobalSettingDao GlobalSettingDao
        {
            get { return globalSettingDao; }
            set { globalSettingDao = value; }
        }

        private string globalSettingXmlUrl = "~/configs/GlobalSetting.xml";

        #endregion

        #region IUserService 成员

        public IList<GlobalSetting> GetAllList()
        {
            return globalSettingDao.GetAllList();
        }

        public bool Update(GlobalSetting model)
        {
            return globalSettingDao.Update(model);
        }

        public bool Delete(GlobalSetting model)
        {
            return globalSettingDao.Delete(model);
        }

        public bool Add(GlobalSetting model)
        {
            return globalSettingDao.Add(model);
        }

        public bool UpdateOrAdd(GlobalSetting model)
        {
            return globalSettingDao.AddOrUpdate(model);
        }

        public GlobalSetting GetModelById(int id)
        {
            return globalSettingDao.GetModelById(id);
        }

        public string GetGlobalSettingValue(string type)
        {
            AtomOA.Common.XML.XmlHelper helper = new Common.XML.XmlHelper(globalSettingXmlUrl);
            return helper.GetValue("companyName").Trim();
        }

        public bool UpdateGlobalSettingValue(string node, string value)
        {
            AtomOA.Common.XML.XMLProcess processHelper = new Common.XML.XMLProcess(globalSettingXmlUrl);
            return processHelper.Update(node, value);
        }
        #endregion
    }
}
