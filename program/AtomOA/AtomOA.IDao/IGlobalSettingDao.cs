﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace AtomOA.IDao
{
    public interface IGlobalSettingDao
    {
        #region  成员方法
        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        IList<AtomOA.Model.GlobalSetting> GetAllList();

        /// <summary>
        /// 根据id来获取用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        AtomOA.Model.GlobalSetting GetModelById(int Id);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Add(AtomOA.Model.GlobalSetting model);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Update(AtomOA.Model.GlobalSetting model);

        /// <summary>
        /// 更新或者添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddOrUpdate(AtomOA.Model.GlobalSetting model);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Delete(AtomOA.Model.GlobalSetting model);
        #endregion  成员方法
    }
}
