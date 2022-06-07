using Bank.Core.BaseRepository.Abstract;
using Bank.Core.ResponseModel;
using Bank.DataAccess.UnitOfWork;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using Bank.Service.ApplicationServices.Abstract;
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

        public Task<IDataResult<EmployeeVM>> AddAsync(EmployeeVM entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<EmployeeVM>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
