using MercatorAPI.Modules;
using MercatorAPI.Modules.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MercatorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarHolderController(ICarHolder carHolder) : ControllerBase
    {
        private readonly ICarHolder _carHolder = carHolder;

        [HttpPost] // Create Car
        public CarHolder Create(CarHolder model)
        {

            return _carHolder.Create(model);
        }

        [HttpPost] // Update Car
        public CarHolder Update(CarHolder model)
        {
            return _carHolder.Update(model);
        }


        [HttpGet("{id}")] // Get Car by Id
        public CarHolder GetCar(int id)
        {
            try
            {
                return _carHolder.GetCar(id);
            } catch (Exception)
            {
                throw;
            }
        }

        [HttpGet] // Get whole list of cars
        public object GetCar()
        {
            return _carHolder.GetCar();
        }

        [HttpDelete("{id}")] // Delete by Id
        public IActionResult Delete(int id)
        {
            try
            {
                _carHolder.Delete(id);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

