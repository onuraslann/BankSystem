using Bank.Core.BaseRepository.Abstract;
using Bank.Core.ResponseModel;
using Bank.DataAccess.UnitOfWork;
using Bank.Domain.General;
using Bank.Domain.ViewModels;
using Bank.Service.ApplicationServices.Abstract;
using Bank.Service.Constants;
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
        private readonly IGenericRepository<Customer> _genericRepository;
        public CustomerAS(IGenericRepository<Customer> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

      
        public async Task<IDataResult<CustomerVM>> AddAsync(CustomerVM entity)
        {
            ValidateData(entity);
           var addedEntity = ObjectMapper.Mapper.Map<Customer>(entity);
            await _genericRepository.AddAsync(addedEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<CustomerVM>(addedEntity);
            return new SuccessDataResult<CustomerVM>(newDto, 200, Messages.CustomerAdded);
        }

        public async Task<IDataResult<IEnumerable<GetListCustomerVM>>> GetAllAsync()
        {
            var entity = ObjectMapper.Mapper.Map<List<GetListCustomerVM>>(await _genericRepository.GetListAsync());
            return new  SuccessDataResult<IEnumerable<GetListCustomerVM>>(entity,200);
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

        public async Task<IDataResult<NoDataDto>> Remove(int id)
        {
            var deletedEntity = await _genericRepository.GetByIdAsync(id);
            if (deletedEntity == null)
            {
                return new ErrorDataResult<NoDataDto>(400,Messages.IdNotFound);
            }
            _genericRepository.Remove(deletedEntity);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204, Messages.CustomerDeleted);
        }

        public async Task<IDataResult<NoDataDto>> Update(CustomerVM entity, int id)
        {
            ValidateData(entity);
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return new ErrorDataResult<NoDataDto>(400, Messages.IdNotFound);
            }
            var updatedEntity = ObjectMapper.Mapper.Map<Customer>(entity);
            _genericRepository.Update(updatedEntity);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoDataDto>(204, Messages.CustomerUpdated);
        }
    }
}
