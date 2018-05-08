using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantReviews.Library.Models
{
    public interface IDbContext 
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : IEntity;
        void SetModified(object entity);
        int SaveChanges();
    }
}
