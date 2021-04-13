using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/Hotel/{hotelId}/Room")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoomRepository hotelRoomRepository;

        public HotelRoomController(IHotelRoomRepository hotelRoomRepository)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }

        // GET: api/<HotelRoomController>
        [HttpGet]
        public IEnumerable<string> Get(int hotelId)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HotelRoomController>/5
        [HttpGet("{id}")]
        public string Get(int hotelId, int id)
        {
            return "value";
        }

        // POST api/<HotelRoomController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HotelRoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HotelRoomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
