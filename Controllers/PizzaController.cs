using WebApp_test.Services;
using WebApp_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        [HttpPost]
        public ActionResult<Pizza> Create(Pizza pizza){
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpDelete("{id}")]
        public ActionResult<Pizza> Delete(int id){
            var pizza = PizzaService.Get(id);
            if(pizza == null)
            {
                return NotFound();
            }

            PizzaService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<Pizza> Update(int id, Pizza pizza){
            if(id != pizza.Id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
            {
                return NotFound();
            }

            PizzaService.Update(pizza);
            return NoContent();
        }
    }
}