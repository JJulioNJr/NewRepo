using MongoDB.Bson.Serialization.Attributes;
using System;
using WebAPI_Airline.Models;

namespace WebAPI_Aircraft.Models {
    public class Aircraft {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
       // public string CNPJ { get; set; }

        public string Enrollment { get; set; }
        public string Capacity { get; set; }
       
        public DateTime LastSale { get; set; }
        public DateTime DateRegister { get; set; }
        public string Situation { get; set; }

        public Airline Airline { get; set; }

    }
}
