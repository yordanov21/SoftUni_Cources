using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
	public class DbSet<TEntity> :ICollection<TEntity>
        where TEntity :class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }
    }
}