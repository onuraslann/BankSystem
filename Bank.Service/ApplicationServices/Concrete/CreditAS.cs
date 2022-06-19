using Bank.Core.BaseRepository.Abstract;
using Bank.Core.ResponseModel;
using Bank.DataAccess.UnitOfWork;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using Bank.Service.ApplicationServices.Abstract;
using Bank.Service.Constants;
using Bank.Service.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.ApplicationServices.Concrete
{
    public class CreditAS : ICreditAS
    {
        private readonly IGenericRepository<Credit> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreditAS(IGenericRepository<Credit> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CreditVM>> AddAsync(CreditVM creditVM)
        {
            var newEntity = ObjectMapper.Mapper.Map<Credit>(creditVM);
          await  _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<CreditVM>(newEntity);
            return new SuccessDataResult<CreditVM>(newDto, 200, Messages.CreditAdded);
        }

        public async Task<IDataResult<IEnumerable<GetListCreditVM>>> GetAllAsync()
        {
            var listModel = ObjectMapper.Mapper.Map<List<GetListCreditVM>>(await _genericRepository.GetListAsync());
            return new SuccessDataResult<IEnumerable<GetListCreditVM>>(listModel,200,Messages.CreditList);
        }

        public async Task<IDataResult<GetListCreditVM>> GetAsync(int id )
        {
            var crediexist = await _genericRepository.GetByIdAsync(id);
            if (crediexist == null)
            {
                return new ErrorDataResult<GetListCreditVM>(404);
            }
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<GetListCreditVM>(ObjectMapper.Mapper.Map<GetListCreditVM>(crediexist), 200);
            
            
        }

        public  async Task<IDataResult<NoDataDto>> DeleteAsync(int id)
        {
            var deletedCredit = await _genericRepository.GetByIdAsync(id);
            if (deletedCredit == null)
            {
                return new ErrorDataResult<NoDataDto>(404);
            }
            _genericRepository.Remove(deletedCredit);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204);
        }
    }
}
