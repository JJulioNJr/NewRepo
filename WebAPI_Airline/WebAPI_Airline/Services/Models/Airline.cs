using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebAPI_Airline.Models {
    public class Airline {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Cnpj { get; set; }
        public string ReasonSocial { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime LastFlight { get; set; }
        public string Situation { get; set; }
    }
}
