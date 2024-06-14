using Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        public readonly static string GETALL = "SELECT CarPlate, CarName, CarColor, ModelYear, FabricationYear, IsSold FROM dbo.Car";

        [Key]
        public string CarPlate { get; set; }

        public string? CarName { get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string? CarColor { get; set; }
        public bool IsSold { get; set; }

        public Car()
        {
            
        }

        //Receber apenas as infos necessarias
        public Car(CarDTO carDTO)
        {
            this.CarName = carDTO.CarName;
            this.ModelYear = carDTO.ModelYear;
            this.FabricationYear = carDTO.FabricationYear;
            this.CarColor = carDTO.CarColor;
        }
    }
}