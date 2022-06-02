using Bank.Core.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.BaseRepository.Abstract
{
    public interface IServiceGeneric<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        Task<Response<TViewModel>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TViewModel>>> GetAllAsync();

        Task<Response<IQueryable<TViewModel>>> Where(Expression<Func<TEntity, bool>> expression);

        Task<Response<TViewModel>> AddAsync(TViewModel entity);

        Task<Response<NoDataDto>> Remove(int id);

        Task<Response<NoDataDto>> Update(TViewModel entity, int id);
    }
}
