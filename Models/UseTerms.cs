using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class UseTerms
    {
        [BsonId]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Version { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
    }
}
