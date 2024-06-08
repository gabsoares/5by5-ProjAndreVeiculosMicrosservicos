using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sale
    {
        public static readonly string INSERT = "INSERT INTO TB_SALE (CAR_ID, SALE_DATE, SALE_VALUE, CLIENT_ID, EMPLOYEE_ID, PAYMENT_ID) VALUES (@CarId, @SaleDate, @SaleValue, @ClientId, @EmpId, @PayId)";
        public int Id { get; set; }
        public Car? Car { get; set; }
        public DateTime SaleDate { get; set; }
        public Decimal SaleValue { get; set; }
        public Customer? Client { get; set; }
        public Employee? Employee { get; set; }
        public Payment? Payment { get; set; }

        public Sale()
        {
            
        }

        public Sale(SaleDTO saleDTO)
        {
            Car car = new Car { CarPlate = saleDTO.CarPlate };
            Customer customer = new Customer { CPF = saleDTO.CustomerCPF };
            Employee employee = new Employee { CPF = saleDTO.EmployeeCPF };
            Payment payment = new Payment { Id = saleDTO.PaymentId };
            this.Car = car;
            this.Client = customer;
            this.Employee = employee;
            this.Payment = payment;
            this.SaleValue = saleDTO.SaleValue;
            this.SaleDate = saleDTO.SaleDate;
        }
    }
}