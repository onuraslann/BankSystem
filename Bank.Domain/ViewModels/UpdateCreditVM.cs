using Bank.Core.BaseRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.ViewModels
{
    public class UpdateCreditVM:IViewModel
    {
        public string CreditType { get; set; }
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public short MinLoanterm { get; set; }
    }
}
