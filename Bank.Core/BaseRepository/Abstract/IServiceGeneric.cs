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
        Task<IDataResult<TViewModel>> GetByIdAsync(int id);
        Task<IDataResult<IEnumerable<TViewModel>>> GetAllAsync();

        Task<IDataResult<IQueryable<TViewModel>>> Where(Expression<Func<TEntity, bool>> expression);

        Task<IDataResult<TViewModel>> AddAsync(TViewModel entity);

        Task<IDataResult<NoDataDto>> Remove(int id);

        Task<IDataResult<NoDataDto>> Update(TViewModel entity, int id);
    }
}
