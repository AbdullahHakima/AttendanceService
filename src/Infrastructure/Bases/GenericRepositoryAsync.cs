﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Infrastructure.Bases;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    #region Fields

    protected readonly ExamServiceDbContext _context;

    #endregion

    #region Constructor
    public GenericRepositoryAsync(ExamServiceDbContext dbContext)
    {
        _context = dbContext;
    }

    #endregion



    #region Actions
    public virtual async Task<T> GetByIdAsync(Guid id)
    {

        return await _context.Set<T>().FindAsync(id);
    }


    public IQueryable<T> GetTableNoTracking()
    {
        return _context.Set<T>().AsNoTracking().AsQueryable();
    }


    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();

    }
    public virtual async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

    }

    public virtual async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async Task DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }



    public IDbContextTransaction BeginTransaction()
    {


        return _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _context.Database.CommitTransaction();

    }

    public void RollBack()
    {
        _context.Database.RollbackTransaction();

    }

    public IQueryable<T> GetTableAsTracking()
    {
        return _context.Set<T>().AsQueryable();

    }

    public virtual async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.Where(expression).ToListAsync();
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.SingleOrDefaultAsync(expression);
    }
    #endregion
}
