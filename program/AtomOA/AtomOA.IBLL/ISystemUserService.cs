using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomOA.Model;

namespace AtomOA.IBLL
{
    public interface ISystemUserService
    {
        /// <summary>
        /// 获取 所有用户信息列表
        /// </summary>
        /// <returns></returns>
        IList<SystemUser> GetAllList();

        /// <summary>
        /// 根据条件获取用户信息
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        IList<SystemUser> GetList(string queryString);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Update(SystemUser model);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Delete(SystemUser model);

        /// <summary>
        /// 添加一个用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Add(SystemUser model);

        /// <summary>
        /// 添加或者更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool UpdateOrAdd(SystemUser model);

        /// <summary>
        /// 根据id来获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SystemUser GetModelById(int id);

        /// <summary>
        /// 检测用户能否登录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool CheckLogin(SystemUser model);

        /// <summary>
        /// 获取当前用户头像
        /// </summary>
        /// <returns></returns>
        string GetUserAvatar();

        /// <summary>
        /// 获取指定用户头像
        /// </summary>
        /// <returns></returns>
        string GetUserAvatar(string userId);
    }
}
