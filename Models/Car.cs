using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        public readonly static string INSERT = "INSERT INTO TB_CAR (CAR_PLATE, CAR_NAME, CAR_COLOR, MODEL_YEAR, FABRICATION_YEAR, IS_SOLD) VALUES (@Plate, @Name, @Color, @ModelYear, @FabricationYear, @IsSold)";

        [Key]
        public string CarPlate { get; set; }

        public string? CarName { get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string? CarColor { get; set; }
        public bool IsSold { get; set; }
    }
}