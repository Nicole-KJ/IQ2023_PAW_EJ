using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private IShipperDAL shipperDAL;

        public ShipperController()
        { 
            shipperDAL = new ShipperDALImpl(new NorthWindContext());        
        }

        #region Get
        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shipperDAL.GetAll();
            return new JsonResult (shippers);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);
            return new JsonResult(shipper);
        }

        #endregion

        #region Add

        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] Shipper shipper)
        {
            shipperDAL.Add(shipper);
            return new JsonResult(shipper);
        }

        #endregion

        #region Update

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Shipper shipper)
        {
            shipperDAL.Add(shipper);
            return new JsonResult(shipper);
        }

        #endregion

        #region Delete
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Shipper shipper = new Shipper { ShipperId=id };
            shipperDAL.Remove(shipper); 
        }
        #endregion
    }
}
