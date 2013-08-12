using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomOA.Model;

namespace AtomOA.IBLL
{
    public interface IGlobalSettingService
    {
        /// <summary>
        /// 获取 所有用户信息列表
        /// </summary>
        /// <returns></returns>
        IList<GlobalSetting> GetAllList();

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Update(GlobalSetting model);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Delete(GlobalSetting model);

        /// <summary>
        /// 添加一个用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Add(GlobalSetting model);

        /// <summary>
        /// 添加或者更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool UpdateOrAdd(GlobalSetting model);

        /// <summary>
        /// 根据id来获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GlobalSetting GetModelById(int id);

        /// <summary>
        /// 获取全局设置的值
        /// </summary>
        /// <param name="Type">设置类型</param>
        /// <returns>设置的值</returns>
        string GetGlobalSettingValue(string type);

        /// <summary>
        /// 更新全局设置的值
        /// </summary>
        /// <param name="type">设置类型</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        bool UpdateGlobalSettingValue(string type,string value);
    }
}
