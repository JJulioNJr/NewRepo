﻿namespace WebAPI_Aircraft.Reposittorys {
    public interface IDatabaseSettings {
       
       public string AircraftCollectionName { get; set; }
       public string ConnectionString { get; set; }
       public string DatabaseName { get; set; }
    }
}
