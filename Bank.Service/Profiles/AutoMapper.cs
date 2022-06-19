using AutoMapper;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Profiles
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<CustomerVM, Customer>().ReverseMap();
            CreateMap<CreditVM, Credit>().ReverseMap(); 
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<GetListCreditVM, Credit>().ReverseMap();

            CreateMap<GetListCustomerVM, Customer>().ReverseMap();

            CreateMap<GetEmployeeListVM, Employee>().ReverseMap();
            CreateMap<UpdateCreditVM, Credit>().ReverseMap();
        }
    }
}
