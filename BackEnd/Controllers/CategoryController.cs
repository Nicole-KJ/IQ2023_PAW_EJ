using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryDAL categoryDAL;

        public CategoryController()
        {
            categoryDAL = new CategoryDALImpl(new NorthWindContext());
        }

        #region Get
        // GET: api/<CategoryController> 
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = categoryDAL.GetAll();
            return new JsonResult(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category = categoryDAL.Get(id);
            return new JsonResult(category);
        }
        #endregion

        #region Add
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] Category category)
        {
            categoryDAL.Add(category);
            return new JsonResult(category); 
        }
        #endregion

        #region Update
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Category category)
        {
            categoryDAL.Add(category);
            return new JsonResult(category);
        }
        #endregion

        #region Delete
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Category category = new Category { CategoryId= id };
            categoryDAL.Remove(category);
        }
        #endregion
    }
}
