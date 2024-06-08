using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Purchase
    {
        public static readonly string INSERT = "INSERT INTO TB_PURCHASE (CAR_ID, PURCHASE_VALUE, PURCHASE_DATE) VALUES (@CarId, @PurcValue, @PurcDate)";
        public int Id { get; set; }
        public Car Car { get; set; }
        public Decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Purchase()
        {
            
        }

        public Purchase(PurchaseDTO purchaseDTO)
        {
            Car car = new Car() { CarPlate = purchaseDTO.CarPlate };
            this.Car = car;
            this.Price = purchaseDTO.Price;
            this.PurchaseDate = purchaseDTO.PurchaseDate;
        }
    }
}