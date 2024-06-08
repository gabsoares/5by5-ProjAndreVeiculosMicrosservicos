﻿using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Adress
    {
        public readonly static string INSERT = "INSERT INTO TB_ADRESS (PUBLIC_PLACE, ZIP_CODE, DISTRICT, PUBLIC_PLACE_TYPE, COMPLEMENT, NUMBER_ADRESS, UF, CITY) VALUES (@PublicPlace, @ZipCode, @District, @PPType, @Complement, @Number, @UF, @City)";
        public int Id { get; set; }

        [JsonProperty("logradouro")]
        public string? PublicPlace { get; set; }

        public string ZipCode { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        public string? PublicPlateType { get; set; }
        public string? Complement { get; set; }
        public int Number { get; set; }

        [JsonProperty("uf")]
        public string? UF { get; set; }

        [JsonProperty("localidade")]
        public string? City { get; set; }

        public Adress()
        {

        }

        public Adress(AdressDTO adressDTO, int type)
        {
            this.Id = adressDTO.Id;
            this.ZipCode = adressDTO.ZipCode;
            this.Complement = adressDTO.Complement;
            this.Number = adressDTO.Number;
        }
    }
}