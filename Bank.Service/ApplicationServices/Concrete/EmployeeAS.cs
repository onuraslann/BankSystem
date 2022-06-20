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
            var addedEmployee = _genericRepository.Where(x => x.FirstName==entity.FirstName).SingleOrDefault();
            if (addedEmployee == null)
            {
                addedEmployee = new Employee();
                addedEmployee.FirstName = entity.FirstName;
                addedEmployee.LastName = entity.LastName;
                addedEmployee.Gender = entity.Gender;
                addedEmployee.Age = entity.Age;
                addedEmployee.Wage = entity.Wage;

            }
         
      
            await _genericRepository.AddAsync(addedEmployee);
            await _uow.CommitAsync();
            return new SuccessDataResult<EmployeeVM>( 200, Messages.EmployeeAdded);

      
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

        public  async Task<IDataResult<NoDataDto>> Update(UpdateEmployeeVM entity, int id)
        {
            var employeExist =  _genericRepository.Where(x => x.Id == id).SingleOrDefault();
            if(employeExist == null)
            {
                return new ErrorDataResult<NoDataDto>(404);
            }
            employeExist.FirstName=string.IsNullOrEmpty(entity.FirstName.Trim()) ?  employeExist.FirstName:entity.FirstName;
            employeExist.LastName = string.IsNullOrEmpty(entity.LastName.Trim()) ? employeExist.LastName : entity.LastName;
            employeExist.Age = entity.Age;
            employeExist.Wage = entity.Wage;
            employeExist.IsActive = entity.IsActive;
             _genericRepository.Update(employeExist);
            await _uow.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204);

        }
    }
}
