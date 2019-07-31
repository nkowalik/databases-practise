using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CitiesApi.Model
{
    public class City
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.String)]
        public ObjectId id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Population")]
        public long Population { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }
    }
}
