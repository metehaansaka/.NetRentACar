using Business.Concrete;
using DataAccess.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArabaController : Controller
    {
        ArabaManager ab = new ArabaManager(new ArabaDal());
        [HttpGet("getall")]
        public List<Araba> GetAll()
        {
            return ab.GetAll();
        }

        [HttpGet("getaraba")]
        public ArabaDTO GetAraba(int id)
        {
            return ab.GetAraba(id);
        }

        [HttpPost("add")]
        public IActionResult Add(Araba araba)
        {
            ab.Add(araba);

            return Ok();
        }

        [HttpPut("update")]
        public void Update(Araba araba)
        {
            ab.Update(araba);
        }

        [HttpGet("delete")]
        public void Delete(int id)
        {
            ab.Delete(id);
        }

        [HttpGet("get")]
        public Araba Get(int id)
        {
            return ab.Get(id);
        }
    }
}
