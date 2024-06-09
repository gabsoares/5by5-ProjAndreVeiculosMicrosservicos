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
        public static readonly string GETALL = "SELECT [p].[Id], [p].[CarPlate], [p].[Price], [p].[PurchaseDate], [c].[CarPlate], [c].[CarColor], [c].[CarName], [c].[FabricationYear], [c].[IsSold], [c].[ModelYear] FROM [Purchase] AS [p] LEFT JOIN [Car] AS [c] ON [p].[CarPlate] = [c].[CarPlate]";

        public static readonly string GETALLDapper = "SELECT [p].[Id], [p].[CarPlate], [p].[Price], [p].[PurchaseDate], [c].[CarPlate] AS CarPlate, [c].[CarColor], [c].[CarName], [c].[FabricationYear], [c].[IsSold], [c].[ModelYear] FROM [Purchase] AS [p] LEFT JOIN [Car] AS [c] ON [p].[CarPlate] = [c].[CarPlate]";
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