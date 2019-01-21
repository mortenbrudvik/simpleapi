using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiServerConsole.Models;

namespace WebApiServerConsole.Controllers
{
    public class AnimalsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var animals = new List<Animal> {new Animal("cat"), new Animal("dog")};
            return Ok(animals);
        }
    }
}