using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MDT.MongoDb.Entities
{
    public class EmpleadoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("codigo")]
        public string Codigo { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }
        
        [BsonElement("apellido")]
        public string Apellido { get; set; }
    }
}