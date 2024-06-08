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

        public List<Payment> GetAllPayments(byte type)
        { 
            return _paymentRepository.GetAllPayments(type);
        }
    }
}