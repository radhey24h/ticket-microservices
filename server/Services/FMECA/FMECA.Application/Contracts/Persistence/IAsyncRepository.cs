﻿using System.Linq.Expressions;
using FMECA.Domain.Common;

namespace FMECA.Application.Contracts.Persistence;
public interface IAsyncRepository<T> where T : Audit
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    string includeString = null,
                                    bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   List<Expression<Func<T, object>>> includes = null,
                                   bool disableTracking = true);
    Task<T> GetByIdAsync(string id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}