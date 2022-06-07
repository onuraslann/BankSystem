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
        Task<Response<CustomerVM>> AddAsync(CustomerVM entity);

        Task<Response<IEnumerable<CustomerVM>>> GetAllAsync();

    }
}
