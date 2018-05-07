using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using RestaurantReviews.Library.Models;

namespace RestaurantReviews.DataAccessLayer.Repositories
{
    public class RestaurantCrud<T> : ICrud<T> where T : IEntity
    {
        public IQueryable<T> Table => throw new NotImplementedException();

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
