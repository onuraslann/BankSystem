using Bank.Core.BaseRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.ViewModels
{
    public class UpdateEmployeeVM:IViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Nullable<Double> Wage { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
