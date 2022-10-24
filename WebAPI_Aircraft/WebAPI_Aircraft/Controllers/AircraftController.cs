using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using System.Collections.Generic;
using WebAPI_Aircraft.Models;
using WebAPI_Aircraft.Services;
using WebAPI_Airline.Controllers;
using WebAPI_Airline.Models;
using WebAPI_Airline.Services;

namespace WebAPI_Aircraft.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase {

        private readonly AircraftServices _aircraftService;
        private readonly AirlineServices _airlineService;

        public AircraftController(AircraftServices aircraftServices,AirlineServices airlineServices) {
            _aircraftService = aircraftServices;
            _airlineService = airlineServices;
        }

        [HttpGet]
        public ActionResult<List<Aircraft>> Get() => _aircraftService.Get();

        [HttpGet("{id}", Name = "GetAircraft")]
        public ActionResult<Aircraft>Get(string id) {
            var aircraft = _aircraftService.Get(id);
            if(aircraft == null) {
                return NotFound();
            } else {
                return Ok(aircraft);
            }
        }

        [HttpPost]
        public ActionResult<Aircraft> Create(Aircraft aircraft,string cnpj) {

            var airline = _airlineService.Get(cnpj);
            if (airline==null) {
                return NotFound();
            } else {
                _aircraftService.Create(aircraft);
                return CreatedAtRoute("GetAircraft", new { id = aircraft.Enrollment.ToString() }, aircraft);
            }
            
        }
        

        [HttpPut]
        public ActionResult<Aircraft> Update(string id, Aircraft aircraftIn) {
            var aircraft=_aircraftService.Get(id);
            if (aircraft == null) {
                return NotFound();
            } else {
                _aircraftService.Update(id, aircraftIn);
                aircraft = _aircraftService.Get(id);
            }
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string id) {

            var aircraft=_aircraftService.Get(id);
            if (aircraft == null) {
                return NotFound();
            } else {
                _aircraftService.Remove(aircraft);
            }
            return NoContent();
        }













    }
}
