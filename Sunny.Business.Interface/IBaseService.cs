using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Business.Interface
{
    /// <summary>
    /// 提供通用的基础增删改查
    /// </summary>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// 根据Id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(int id);

        /// <summary>
        /// 一次性查出全部数据
        /// </summary>
        /// <returns></returns>
        List<T> FindAll();

        /// <summary>
        /// 提供对单表的查询
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Set();

        /// <summary>
        /// 新增数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        T Insert(T t);

        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Update(T t);

        /// <summary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Delete(T t);

        /// <summary>
        /// 根据主键删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Delete(int Id);

        /// <summary>
        /// 立即保存全部修改
        /// </summary>
        void Commit();

        /// <summary>
        /// 执行sql 返回集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> ExcuteQuery(string sql, SqlParameter[] parameters);

        /// <summary>
        /// 执行sql，无返回
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        int Excute(string sql, SqlParameter[] parameters);
    }
}
