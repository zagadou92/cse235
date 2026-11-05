using ContosoPizza.Models;
using ContosoPizza.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    // GET: api/pizza
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Ok(PizzaService.GetAll());
    }

    // GET: api/pizza/1
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
        {
            return NotFound($"Pizza with ID {id} was not found.");
        }

        return Ok(pizza);
    }

    // POST: api/pizza
    [HttpPost]
    public ActionResult<Pizza> Create(Pizza pizza)
    {
        if (pizza is null)
        {
            return BadRequest("Pizza data is required.");
        }

        if (string.IsNullOrWhiteSpace(pizza.Name))
        {
            return BadRequest("Pizza name is required.");
        }

        PizzaService.Add(pizza);

        return CreatedAtAction(
            nameof(Get),
            new { id = pizza.Id },
            pizza
        );
    }

    // PUT: api/pizza/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (pizza is null)
        {
            return BadRequest("Pizza data is required.");
        }

        if (id != pizza.Id)
        {
            return BadRequest("The route ID does not match the pizza ID.");
        }

        var existingPizza = PizzaService.Get(id);

        if (existingPizza is null)
        {
            return NotFound($"Pizza with ID {id} was not found.");
        }

        PizzaService.Update(pizza);

        return NoContent();
    }

    // DELETE: api/pizza/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
        {
            return NotFound($"Pizza with ID {id} was not found.");
        }

        PizzaService.Delete(id);

        return NoContent();
    }
}