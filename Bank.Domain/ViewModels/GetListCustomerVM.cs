using Bank.Core.BaseRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.ViewModels
{
    public class GetListCustomerVM:IViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tckn { get; set; }
        public int Age { get; set; }
        public string CustomerType { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
