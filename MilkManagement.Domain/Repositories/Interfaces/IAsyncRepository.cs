using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity, new()
    {
        Task<TViewModel> GetByIdAsync<TViewModel>(int id);
        Task<TViewModel> GetSingleAsync<TViewModel>(ISpecification<T> spec);
        Task<List<TViewModel>> ListAllAsync<TViewModel>();
        Task<List<TViewModel>> ListAsync<TViewModel>(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task PartialUpdate<TModel>(TModel viewModel, Action<T> callback);
        //Task<bool> CompleteAsync();
    }
}
