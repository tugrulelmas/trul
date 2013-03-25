﻿using System.Data.Entity;
using Trul.Data.Core;
using Trul.Domain.Core;

namespace Trul.Data.EntityFramework
{
    /// <summary>
    /// The UnitOfWork contract for EF implementation
    /// <remarks>
    /// This contract extend IUnitOfWork for use with EF code
    /// </remarks>
    /// </summary>
    public interface IQueryableUnitOfWork
        : IUnitOfWork, ISql
    {
        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context, 
        /// the ObjectStateManager, and the underlying store. 
        /// </summary>
        /// <typeparam name="TValueObject"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        /// <summary>
        /// Attach this item into "ObjectStateManager"
        /// </summary>
        /// <typeparam name="TValueObject">The type of entity</typeparam>
        /// <param name="item">The item <</param>
        void Attach<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="item"></param>
        TEntity Attach<TEntity, TId>(TEntity item) where TEntity : class, IEntityWithTypedId<TId>;
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="item"></param>
        IEntityWithTypedId<TId> GetContextEntity<TEntity, TId>(TEntity item) where TEntity : class, IEntityWithTypedId<TId>;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="TValueObject">The type of entity</typeparam>
        /// <param name="item">The entity item to set as modifed</param>
        void SetModified<TEntity, TId>(TEntity item) where TEntity : class, IEntityWithTypedId<TId>, new();

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    }
}
