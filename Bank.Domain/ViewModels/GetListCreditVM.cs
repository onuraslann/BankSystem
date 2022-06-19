using Bank.Core.BaseRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.ViewModels
{
    public class GetListCreditVM:IViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CreditType { get; set; }
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public short MinLoanterm { get; set; }
        public short MaxLoanterm { get; set; }
        public Nullable<double> InterestRate { get; set; }
    }
}
