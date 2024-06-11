using Models.DTO;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class AcceptUseTerms
    {
        [BsonId]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public UseTerms UseTerms { get; set; }
        public DateTime AgreeDate { get; set; }

        public AcceptUseTerms()
        {
            
        }

        public AcceptUseTerms(AcceptUseTermsDTO dto, Customer customer, UseTerms useTerm)
        {
            this.Id = dto.Id;
            this.Customer = customer;
            this.UseTerms = useTerm;
            this.AgreeDate = dto.AgreeDate;
        }
    }
}