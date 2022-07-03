using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Task.core.Entities;
using Task.service.Dtos;
using Task.service.InterFaces;

namespace Task.app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersenService _persenService;

        public PersonsController(IPersenService persenService)
        {
            _persenService = persenService;
        }
        /// <summary>
        /// Creates an Person.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Save
        ///  "{FirstName: ‘Ivan’,LastName: ‘Petrov’,Adress:{City:'Kiev',AddressLine:prospect “Peremogy” 28/7}}"
        /// </remarks>
        /// <param name="json"></param>    
        /// <returns>Person id</returns>
        [HttpPost("")]
        public async Task<long> Save([FromBody] string json)
        {

           return await  _persenService.Save(json);
        }

        /// <summary>
        /// Gets the list of all Persons.
        /// </summary>
        /// <returns>The list of Persons.</returns>
        // GET: api/Get
        [HttpGet("")]
        public IActionResult Get()
        {
            List<string> persons = new List<string>();
            persons = _persenService.GetAll();
            return StatusCode(200,persons);
        }
    }
}
