using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI_Airline.Models;
using WebAPI_Airline.Services;

namespace WebAPI_Airline.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase {

        private readonly AirlineServices _airlineService;

        public AirlineController(AirlineServices airlineServices) {
            _airlineService = airlineServices; 
        }

        [HttpGet]
        public ActionResult<List<Airline>> Get() => _airlineService.Get();

        [HttpGet("Cnpj", Name = "GetAirline")]
        public ActionResult<Airline> Get(string cnpj) {
            var airline = _airlineService.Get(cnpj);
            if (airline == null) {
                return NotFound();
            } else {
                return Ok(airline);
            }
        }

        [HttpPost]
        public ActionResult<Airline> Create(Airline airline) {
            _airlineService.Create(airline);
            return CreatedAtRoute("GetAirline", new { cnpj = airline.Cnpj.ToString() }, airline);
        }

        [HttpPut]
        public ActionResult<Airline>Update(string cnpj, Airline airlineIn) {
            var airline = _airlineService.Get(cnpj);
            if (airline == null) {

                return NotFound();
            } else {
                _airlineService.Update(cnpj, airline);
            }

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string cnpj) {

            var airline=_airlineService.Get(cnpj);
            if (airline == null) {
                return NotFound();
            } else{
                _airlineService.Remove(airline);
            }

            return NoContent();
        }













    }
}
