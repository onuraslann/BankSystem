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
    public class EmployeeAS : IEmployeeAS
    {
        private readonly IGenericRepository<Employee> _genericRepository;
        private readonly IUnitOfWork _uow;
        public EmployeeAS(IGenericRepository<Employee> genericRepository, IUnitOfWork uow)
        {
            _genericRepository = genericRepository;
            _uow = uow;
        }

        public async Task<IDataResult<EmployeeVM>> AddAsync(EmployeeVM entity)
        {
            var adddedEntity = ObjectMapper.Mapper.Map<Employee>(entity);
            await _genericRepository.AddAsync(adddedEntity);
            await _uow.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<EmployeeVM>(entity);
            return new SuccessDataResult<EmployeeVM>(newDto, 200,Messages.EmployeeAdded);
        }

        public async Task<IDataResult<IEnumerable<GetEmployeeListVM>>> GetAllAsync()
        {
            var listEntity = ObjectMapper.Mapper.Map<List<GetEmployeeListVM>>(await _genericRepository.GetListAsync());
            return new SuccessDataResult<IEnumerable<GetEmployeeListVM>>(listEntity, 200);

        }

        public async  Task<IDataResult<NoDataDto>> Remove(int id)
        {
            var employeeExist = await _genericRepository.GetByIdAsync(id);
            if (employeeExist == null)
            {
                return new ErrorDataResult<NoDataDto>(400, Messages.IdNotFound);
            }
            _genericRepository.Remove(employeeExist);
            await _uow.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204, Messages.EmployeeDelete);
        }

        public  async Task<IDataResult<NoDataDto>> Update(EmployeeVM entity, int id)
        {
            var employeeExist = await _genericRepository.GetByIdAsync(id);
            if (employeeExist == null)
            {
                return new ErrorDataResult<NoDataDto>(404, Messages.IdNotFound);
            }
            var updateEntity = ObjectMapper.Mapper.Map<Employee>(entity);
            _genericRepository.Update(updateEntity);
            await _uow.CommitAsync();
            return new SuccessDataResult<NoDataDto>( 204, Messages.EmployeeUpdate);
        }
    }
}
