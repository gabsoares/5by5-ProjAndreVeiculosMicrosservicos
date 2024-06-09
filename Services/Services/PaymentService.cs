using Models;
using Repositories.Repositories;

namespace Services.Services
{
    public class PaymentService
    {
        private PaymentRepository _paymentRepository;

        public PaymentService()
        {
            _paymentRepository = new PaymentRepository();
        }

        public async Task<List<Payment>> GetAllPayments(byte type)
        { 
            return await _paymentRepository.GetAllPayments(type);
        }
    }
}