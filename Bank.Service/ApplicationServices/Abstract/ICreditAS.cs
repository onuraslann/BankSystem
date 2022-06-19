using Bank.Core.ResponseModel;
using Bank.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.ApplicationServices.Abstract
{
    public interface ICreditAS
    {
        Task<IDataResult<IEnumerable<GetListCreditVM>>> GetAllAsync();
        Task<IDataResult<CreditVM>> AddAsync(CreditVM creditVM);

        Task<IDataResult<GetListCreditVM>>GetAsync(int id);
        Task<IDataResult<NoDataDto>> DeleteAsync(int id);

        Task<IDataResult<NoDataDto>> UpdateAsync(UpdateCreditVM updateCreditVM,int id);
    }
}
