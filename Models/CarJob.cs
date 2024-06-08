﻿using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarJob
    {
        public readonly static string INSERT = "INSERT INTO TB_CAR_JOB (CAR_ID, JOB_ID, STATUS_SERVICE) VALUES (@CarId, @ServiceId, @StatusService)";

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