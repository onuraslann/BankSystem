using Bank.Core.ResponseModel;
using Bank.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.ApplicationServices.Abstract
{
    public interface ICustomerAS
    {
        Task<IDataResult<CustomerVM>> AddAsync(CustomerVM entity);

        Task<IDataResult<IEnumerable<GetListCustomerVM>>> GetAllAsync();

        Task<IDataResult<NoDataDto>> Remove(int id);

        Task<IDataResult<NoDataDto>> Update(CustomerVM entity, int id);

    }
}
