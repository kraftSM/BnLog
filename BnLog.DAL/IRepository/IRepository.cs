﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BnLog.DAL.IRepository
{
    /// <summary>
    /// Реализация UnitOfWork
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByGuidAsync(Guid guid);
        Task<int> CreateAsync(T item);

        Task<int> UpdateAsync(T item);

        Task<int> DeleteAsync(T item);
    }
}
