using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using ObligatoriskOpgaveOpg4.Controllers.Managers;


namespace ObligatoriskOpgaveOpg4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CarsController : Controller
    {

        private CarsManager _manager = new CarsManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]

        public ActionResult<IEnumerable<Cars>> Get([FromQuery] string modelFilter, [FromQuery] int? priceFilter,
        [FromQuery] string licenseplateFilter) 
        {
            IEnumerable<Cars> cars = _manager.GetAll(modelFilter, priceFilter, licenseplateFilter);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Cars cars = _manager.GetById(id);
            if (cars == null) return NotFound("findes ikke, id: " + id);
            return Ok(cars);
        }

        [HttpPost]
        public Cars Post([FromBody] Cars newCars)
        {
            return _manager.AddCars(newCars);
        }

        [HttpDelete("{id}")]
        public Cars Delete(int id)
        {
            Cars cars = _manager.GetById(id);
            return _manager.Delete(id);
        }
    }





    }

