namespace Users.Aplication.Contracts.Persistence ;
using System.Linq.Expressions;
using Dominio.Common;

    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        #region Queries

        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Solo get con where
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get con ordenamiento
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeString"></param>
        /// <param name="disabledTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null
            , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , string includeString = null
            , bool disabledTracking = true
            );

        /// <summary>
        /// Este lo  usuare si hay tablas en el inner join
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <param name="disabledTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null
            , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , List<Expression<Func<T, object>>> includes = null
            , bool disabledTracking = true
            );

        /// <summary>
        /// Consulta por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(Guid id);

        #endregion

        #region manage insert and  delete

        Task<T> AddAsync(T entity);


        Task<T> UpdateAsync(T entity);


        Task DeleteAsync(T entity);

        #endregion

        #region "Metodos for IUnitOfWork"

        void AddEntity(T entity);
        void UpdateEntity(T entity);

        void DeleteEntity(T entity);

        #endregion
    }
