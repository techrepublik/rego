using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace GenDataLayer.repo
{
    public interface IDataRepository<TEntity> : IDisposable where TEntity : EntityObject
    {
        IQueryable<TEntity> Fetch();
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity Single(Func<TEntity, bool> predicate);
        TEntity First(Func<TEntity, bool> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Attach(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
        void SaveChanges(SaveOptions options);
        bool LazyLoadingEnabled { get; set; }
    }

}
