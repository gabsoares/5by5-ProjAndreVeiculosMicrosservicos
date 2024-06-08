using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarJob
    {
        public readonly static string GETALL = "SELECT [c].[Id], [c].[CarPlate], [c].[JobId], [c].[Status], [c0].[CarPlate] AS CarPlate, [c0].[CarColor], [c0].[CarName], [c0].[FabricationYear], [c0].[IsSold], [c0].[ModelYear], [j].[Id] AS Id, [j].[Description] FROM [CarJob] AS [c] LEFT JOIN [Car] AS [c0] ON [c].[CarPlate] = [c0].[CarPlate] INNER JOIN [Job] AS [j] ON [c].[JobId] = [j].[Id]";

        public int Id { get; set; }
        public Car Car { get; set; }
        public Job Job { get; set; }
        public bool Status { get; set; }

        public CarJob()
        {
            
        }

        public CarJob(CarJobDTO carJobDTO)
        {
            Car car = new Car { CarPlate = carJobDTO.CarPlate};
            Job job = new Job { Id = carJobDTO.JobId};
            this.Car = car;
            this.Job = job;
            this.Status = carJobDTO.Status;
        }
    }
}