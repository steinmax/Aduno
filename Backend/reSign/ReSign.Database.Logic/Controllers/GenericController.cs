namespace ReSign.Database.Logic.Controllers
{
    public abstract partial class GenericController<E> : ControllerObject where E : Entities.Base.IdentityEntity, new()
    {
        private DbSet<E>? dbSet = null;
        public GenericController()
            : base(new DataContext.ReSignDbContext())
        {
        }
        public GenericController(ControllerObject other)
            : base(other)
        {
        }

        internal DbSet<E> EntitySet
        {
            get
            {
                if (dbSet == null)
                {
                    if (Context != null)
                    {
                        dbSet = Context.GetDbSet<E>();
                    }
                    else
                    {
                        using var ctx = new DataContext.ReSignDbContext();

                        dbSet = ctx.GetDbSet<E>();

                    }
                }
                return dbSet;
            }
        }

        #region Queries
        public virtual Task<E[]> GetAllAsync()
        {
            return EntitySet.AsNoTracking().ToArrayAsync();
        }
        public virtual ValueTask<E?> GetByIdAsync(int id)
        {
            return EntitySet.FindAsync(id); 
        }
        #endregion Queries

        #region Insert
        public virtual async Task<E> InsertAsync(E entity)
        {
            await EntitySet.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }
        public virtual async Task<IEnumerable<E>> InsertAsync(IEnumerable<E> entities)
        {
            await EntitySet.AddRangeAsync(entities).ConfigureAwait(false);
            return entities;
        }
        #endregion Insert

        #region Update
        public virtual Task<E> UpdateAsync(E entity)
        {
            return Task.Run(() =>
            {
                EntitySet.Update(entity);
                return entity;
            });
        }
        public virtual Task<IEnumerable<E>> UpdateAsync(IEnumerable<E> entities)
        {
            return Task.Run(() =>
            {
                EntitySet.UpdateRange(entities);
                return entities;
            });
        }
        #endregion Update

        #region Delete
        public virtual Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                E? result = EntitySet.Find(id);

                if (result != null)
                {
                    EntitySet.Remove(result);
                }
            });
        }
        #endregion Delete

        #region SaveChanges
        public async Task<int> SaveChangesAsync()
        {
            var result = 0;

            if (Context != null)
            {
                result = await Context.SaveChangesAsync().ConfigureAwait(false);
            }
            return result;
        }
        #endregion SaveChanges
    }
}