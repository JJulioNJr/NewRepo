using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAPI_Airline.Models;
using WebAPI_Airline.Reposittorys;

namespace WebAPI_Airline.Services {
    public class AirlineServices {

        private readonly IMongoCollection<Airline> _airline;

        public AirlineServices(IDatabaseSettings settings) {
            var airline = new MongoClient(settings.ConnectionString);
            var database =airline.GetDatabase(settings.DatabaseName);
            _airline = database.GetCollection<Airline>(settings.AirlineCollectionname);
        }

        public Airline Create(Airline airline) {
            _airline.InsertOne(airline);
            return airline;
        }

        public List<Airline> Get() => _airline.Find<Airline>(Airline => true).ToList();
        public Airline Get(string cnpj) => _airline.Find<Airline>(airline => airline.Cnpj == cnpj).FirstOrDefault();
        public void Update(string cnpj,Airline airlineIn) {

            _airline.ReplaceOne(airline=>airline.Cnpj==cnpj, airlineIn);

        }

        public void Remove(Airline airlineIn) => _airline.DeleteOne(airline => airline.Cnpj == airlineIn.Cnpj);








    }
}
