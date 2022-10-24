using MongoDB.Driver;
using System.Collections.Generic;
using WebAPI_Aircraft.Models;
using WebAPI_Aircraft.Reposittorys;

namespace WebAPI_Aircraft.Services {
    public class AircraftServices {

        private readonly IMongoCollection<Aircraft> _aircraft;
        //private readonly IMongoCollection<Airline> _airline;
        public AircraftServices(IDatabaseSettings settings) {
            var aircraft=new MongoClient(settings.ConnectionString);
            var database=aircraft.GetDatabase(settings.DatabaseName);
            _aircraft = database.GetCollection<Aircraft>(settings.AircraftCollectionName);
        }

        public Aircraft Create(Aircraft aircraft) {
            _aircraft.InsertOne(aircraft);
            return aircraft;
        }

        public List<Aircraft> Get() => _aircraft.Find<Aircraft>(aircraft => true).ToList();

        public Aircraft Get(string id) => _aircraft.Find<Aircraft>(aircraft => aircraft.Id == id).FirstOrDefault();

        public void Update(string id, Aircraft aircraftIn) {
            _aircraft.ReplaceOne(aircraft => aircraft.Id == id, aircraftIn);
        }

        public void Remove(Aircraft aircraftIn) => _aircraft.DeleteOne(aircraft => aircraft.Id == aircraft.Id);














    }
}
