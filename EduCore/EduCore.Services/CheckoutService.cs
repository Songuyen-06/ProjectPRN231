
using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CheckoutService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddCheckout(CheckoutDTO checkoutDTO)
        {
            if (checkoutDTO == null)
            {
                throw new ArgumentNullException(nameof(checkoutDTO), "CheckoutDTO cannot be null");
            }

            var checkout = new StudentCheckout
            {
                StudentId = checkoutDTO.StudentId, 
                CourseId = checkoutDTO.CourseId, 
                PaymentDate = checkoutDTO.PaymentDate ?? DateTime.UtcNow, 
                Amount = checkoutDTO.Amount,
                PaymentStatus = checkoutDTO.PaymentStatus,
                TransactionId = checkoutDTO.TransactionId,
                PaymentMethod = checkoutDTO.PaymentMethod,
            };

            try
            {
                 unitOfWork.CheckoutRepository.Add(checkout);
                 unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding checkout: {ex.Message}");
                throw;
            }
        }



        public List<CheckoutDTO> GetCheckoutList()
        {
            return mapper.Map<List<CheckoutDTO>>(unitOfWork.CheckoutRepository.GetListCheckoutByInclude().ToList());
        }
    }
}
