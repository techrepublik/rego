using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace GenDataLayer.repo
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : EntityObject
    {
        public bool LazyLoadingEnabled { get; set; }

        private readonly ObjectContext _context;

        private readonly IObjectSet<TEntity> _objectSet;

        public DataRepository()
            : this(new ESEntities())
        {
        }

        private DataRepository(ObjectContext context)
        {
            context.ContextOptions.LazyLoadingEnabled = LazyLoadingEnabled;
            _context = context;
            _objectSet = _context.CreateObjectSet<TEntity>();
        }

        public IQueryable<TEntity> Fetch()
        {
            return _objectSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Fetch().AsEnumerable();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _objectSet.Where(predicate);
        }

        public TEntity Single(Func<TEntity, bool> predicate)
        {
            return _objectSet.SingleOrDefault(predicate);    
        }

        public TEntity First(Func<TEntity, bool> predicate)
        {
            return _objectSet.First(predicate);
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _objectSet.Attach(entity);
            _objectSet.DeleteObject(entity);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            IEnumerable<TEntity> records = from x in _objectSet.Where(predicate) select x;

            foreach (TEntity record in records)
            {
                _objectSet.DeleteObject(record);
            }
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            _objectSet.AddObject(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            _objectSet.Attach(entity);
            _context.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
        }

        public void Attach(TEntity entity)
        {
            _objectSet.Attach(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChanges(SaveOptions options)
        {
            _context.SaveChanges(options);
        }

        private bool _disposedValue;

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state here if required
                }
                // dispose unmanaged objects and set large fields to null
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Cached ObjectSets so changes persist
        private readonly Dictionary<string, object> _cachedObjects = new Dictionary<string, object>();

        private ObjectSet<T> GetObjectSet<T>() where T : EntityObject
        {
            var fulltypename = typeof(T).AssemblyQualifiedName;
            if (fulltypename == null)
                throw new ArgumentException("Invalid Type passed to GetObjectSet!");
            if (!_cachedObjects.ContainsKey(fulltypename))
            {
                var objectset = _context.CreateObjectSet<T>();
                _cachedObjects.Add(fulltypename, objectset);
            }
            return _cachedObjects[fulltypename] as ObjectSet<T>;
        }

        public IQueryable<T> Fetch<T>() where T : EntityObject
        {
            return GetObjectSet<T>();
        }
    }
}
