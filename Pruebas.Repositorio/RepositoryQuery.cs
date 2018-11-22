using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pruebas.Repositorio
{
    public sealed class RepositoryQuery<TEntity> where TEntity : class
    {
        private readonly List<Expression<Func<TEntity, object>>> includeProperties;
        private readonly Repository<TEntity> repository;
        private IList<Expression<Func<TEntity, bool>>> filters;
        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByQueryable;
        private int? page;
        private int? pageSize;

        public RepositoryQuery(Repository<TEntity> repository)
        {
            this.repository = repository;
            includeProperties = new List<Expression<Func<TEntity, object>>>();
        }

        public RepositoryQuery<TEntity> Filter(Expression<Func<TEntity, bool>> filter)
        {
            if (filters == null)
                filters = new List<Expression<Func<TEntity, bool>>>();
            filters.Add(filter);
            return this;
        }

        public RepositoryQuery<TEntity> Filter(IList<Expression<Func<TEntity, bool>>> filter)
        {
            filters = filter;
            return this;
        }

        public RepositoryQuery<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            orderByQueryable = orderBy;
            return this;
        }

        public RepositoryQuery<TEntity> Include(Expression<Func<TEntity, object>> expression)
        {
            includeProperties.Add(expression);
            return this;
        }

        public IEnumerable<TEntity> GetPage(int page, int pageSize, out int totalCount)
        {
            this.page = page;
            this.pageSize = pageSize;
            var filter = GetFilter();
            totalCount = repository.Get(filter).Count();

            return repository.Get(filter, orderByQueryable, includeProperties, page, pageSize);
        }

        public IEnumerable<TEntity> Get()
        {
            var filter = GetFilter();
            return repository.Get(filter, orderByQueryable, includeProperties, page, pageSize);
        }

        private Expression<Func<TEntity, bool>> GetFilter()
        {
            if (filters == null || filters.Count == 0)
                return null;
            //var predicate = PredicateBuilder.True<TEntity>(); //Deprecated
            Expression<Func<TEntity, bool>> predicate = PredicateBuilder.New<TEntity>(true);
            filters.ToList().ForEach(fi => predicate = predicate.And(fi));

            return predicate.Expand();
        }
    }
}
