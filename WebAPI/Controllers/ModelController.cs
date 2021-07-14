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
    public class ModelController : Controller
    {
        ModelManager mm = new ModelManager(new ModelDal());
        [HttpGet("getall")]
        public List<Model> GetAll()
        {
            return mm.GetAll();
        }

        [HttpGet("get")]
        public Model Get(int id)
        {
            return mm.Get(id);
        }
    }
}
