using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AcceptUseTermsDTO
    {
        [BsonId]
        public int Id { get; set; }
        public string CustomerCPF { get; set; }
        public int UseTermId { get; set; }
        public DateTime AgreeDate { get; set; }
    }
}
