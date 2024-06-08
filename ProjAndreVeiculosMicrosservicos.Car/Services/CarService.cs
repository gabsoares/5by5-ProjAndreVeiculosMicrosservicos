namespace APIAndreVeiculosMicrosservicos.Car.CarService
{
    public class CarService
    {
        public string GenerateCarPlate()
        {
            Random random = new();
            string plateLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


            string carPlateLetters = "";
            for (int y = 0; y < 3; y++)
            {
                carPlateLetters += plateLetters[random.Next(0, plateLetters.Length)];
            }

            string carPlateNumbers = "";
            for (int j = 0; j < 4; j++)
            {
                carPlateNumbers += random.Next(0, 9);
            }

            string carPlate = carPlateLetters + carPlateNumbers;

            return carPlate;
        }
    }
}