namespace WebAPI_Airline.Reposittorys {
    public class DatabaseSettings : IDatabaseSettings {

        public string AirlineCollectionname { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
