using Bank.Core.BaseRepository.Abstract;
using Bank.Core.ResponseModel;
using Bank.DataAccess.UnitOfWork;
using Bank.Service.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.BaseService
{
    public class ServiceGeneric<TEntity, TViewModel> : IServiceGeneric<TEntity, TViewModel>
      where TEntity : class where TViewModel : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }
        
        public async Task<IDataResult<TViewModel>> AddAsync(TViewModel entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TViewModel>(newEntity);
            return new SuccessDataResult<TViewModel>(newDto, 200);
        }

        public async Task<IDataResult<IEnumerable<TViewModel>>> GetAllAsync()
        {
            var entity = ObjectMapper.Mapper.Map<List<TViewModel>>(await _genericRepository.GetListAsync());
            return new SuccessDataResult<IEnumerable<TViewModel>>(entity, 200);
        }

        public async Task<IDataResult<TViewModel>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<TViewModel>(404);
            }
            return new SuccessDataResult<TViewModel>(ObjectMapper.Mapper.Map<TViewModel>(entity), 200);
        }

        public async Task<IDataResult<NoDataDto>> Remove(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return new ErrorDataResult<NoDataDto>(404);
            }
            _genericRepository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204);
        }

        public async Task<IDataResult<NoDataDto>> Update(TViewModel entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return new ErrorDataResult<NoDataDto>(404);
            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204);

        }

        public async Task<IDataResult<IQueryable<TViewModel>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var entityList = _genericRepository.Where(expression);
            return new SuccessDataResult<IQueryable<TViewModel>>(ObjectMapper.Mapper.Map<IQueryable<TViewModel>>(await entityList.ToListAsync()), 200);
        }
    }
}
