using angular_server; // Import the namespace of the Category class
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace angular_server
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return Data.Categories;
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = Data.Categories.FirstOrDefault(c => c.Code == id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            Data.Categories.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Code }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var existingCategory = Data.Categories.FirstOrDefault(c => c.Code == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Name = category.Name;
            existingCategory.IconRouting = category.IconRouting;

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = Data.Categories.FirstOrDefault(c => c.Code == id);
            if (category == null)
            {
                return NotFound();
            }
            Data.Categories.Remove(category);
            return NoContent();
        }
    }
}
