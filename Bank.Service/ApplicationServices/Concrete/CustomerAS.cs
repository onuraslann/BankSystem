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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Service.ApplicationServices.Concrete
{
    public class CustomerAS : ICustomerAS
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAS(IGenericRepository<Customer> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        private readonly IGenericRepository<Customer> _genericRepository;
        public async Task<Response<CustomerVM>> AddAsync(CustomerVM entity)
        {
            ValidateData(entity);
            var newEntity = ObjectMapper.Mapper.Map<Customer>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<CustomerVM>(newEntity);
            return Response<CustomerVM>.SuccessResponse(newDto, 200);
        }

        public async Task<Response<IEnumerable<CustomerVM>>> GetAllAsync()
        {
            var entity = ObjectMapper.Mapper.Map<List<CustomerVM>>(await _genericRepository.GetListAsync());
            return Response<IEnumerable<CustomerVM>>.SuccessResponse(entity, 200);
        }

        private void ValidateData(CustomerVM customerVM)
        {
            if (!customerVM.PhoneNumber.StartsWith("5"))
            {
                throw new ExceptionMessage("Telefon numarası 5 ile başlamalı.");
            }
            if (!ValidateTckn(customerVM.Tckn))
            {
                throw new ExceptionMessage("Tc kimlik numarası 11 karakter olmalı.");
            }
            if (!IsValidTCKN(customerVM.Tckn))
            {
                throw new ExceptionMessage("Tc kimlik sadece nümeric değer içermeli.");
            }

            if (!IsValidFirstName(customerVM.FirstName))
            {
                throw new ExceptionMessage("Girilen isim sayısal değer içermemeli.");
            }
            if (!IsValidFirstName(customerVM.LastName))
            {
                throw new ExceptionMessage("Girilen soyisim sayısal değer içermemeli.");
            }
        }
        private bool ValidateTckn(string tckn)
        {
            if(tckn.Length==11)
            {
                return true;
            }
            return false;

        }

        private bool IsValidTCKN(string tckn)
        {
            return Regex.Match(tckn, "^[0-9]+$").Success;
        }
        private bool IsValidFirstName(string firstName)
        {
            return Regex.IsMatch(firstName, @"^[a-zA-Z]+$");
        }
        private bool IsValidLastName(string lastName)
        {
            return Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
        }
    }
}
