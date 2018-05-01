using Sunny.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Business.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public DbContext Context { get; set; }
        private DbSet<T> TDbSet;
        public BaseService(DbContext context)
        {
            this.Context = context;
            this.TDbSet = this.Context.Set<T>();
        }


        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Delete(T t)
        {
            if (t == null) throw new Exception("t is null");
            TDbSet.Remove(t);
            Context.SaveChanges();
        }

        public void Delete(int Id)
        {
            T t = this.Find(Id);
            if (t == null) throw new Exception("t is null");
            this.TDbSet.Remove(t);
            this.Commit();
        }

        public List<T> FindAll()
        {
            return this.TDbSet == null ? null : TDbSet.ToList();
        }

        public T Find(int id)
        {
            return this.TDbSet.Find(id);
        }

        public T Insert(T t)
        {
            TDbSet.Add(t);
            Context.SaveChanges();
            return t;
        }

        public IQueryable<T> Set()
        {
            return this.TDbSet;
        }

        public void Update(T t)
        {
            if (t == null) throw new Exception("t is null");
            this.Commit();
        }

        public int Excute(string sql, SqlParameter[] parameters)
        {
            //DbContextTransaction trans = null;
            //try
            //{
            //    trans = this.Context.Database.BeginTransaction();
            //    Context.Database.ExecuteSqlCommand(sql, parameters);
            //    trans.Commit();
            //}
            //catch (Exception ex)
            //{
            //    if (trans != null)
            //        trans.Rollback();
            //    throw ex;
            //}

            return Context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public IQueryable<T> ExcuteQuery(string sql, SqlParameter[] parameters)
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
        }
    }
}
