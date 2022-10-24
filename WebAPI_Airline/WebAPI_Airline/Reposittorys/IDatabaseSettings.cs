namespace WebAPI_Airline.Reposittorys {
    public interface IDatabaseSettings {

        string AirlineCollectionname { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}

