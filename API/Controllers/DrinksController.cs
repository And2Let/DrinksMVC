using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.DTO;

namespace API.Controllers
{
    public class DrinksController : Controller
    {
        //[Route("api/[controller]")]
        protected readonly IDrinkService drinkService;
        public DrinksController(IDrinkService drinkService)
        {
            this.drinkService = drinkService;
        }
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            IList<DrinkDto> drinks = drinkService.GetAll();
            return Ok(drinks);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
