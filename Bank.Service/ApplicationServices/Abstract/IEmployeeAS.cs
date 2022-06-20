using Bank.Core.ResponseModel;
using Bank.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.ApplicationServices.Abstract
{
    public interface IEmployeeAS
    {
        Task<IDataResult<EmployeeVM>> AddAsync(EmployeeVM entity);

        Task<IDataResult<IEnumerable<GetEmployeeListVM>>> GetAllAsync();

        Task<IDataResult<NoDataDto>> Remove(int id);

        Task<IDataResult<NoDataDto>> Update(UpdateEmployeeVM entity, int id);
    }
}
