using Business.Concrete;
using DataAccess.Concrete;
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

    public class MarkaController : Controller
    {

        MarkaManager mm = new MarkaManager(new MarkaDal());
        [HttpGet("getall")]
        public List<Marka> GetAll()
        {
            return mm.GetAll();
        }

        [HttpGet("get")]
        public Marka Get(int id)
        {
            return mm.Get(id);
        }
    }
}
