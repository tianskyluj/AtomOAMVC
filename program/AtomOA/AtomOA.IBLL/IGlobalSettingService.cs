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
    }
}
