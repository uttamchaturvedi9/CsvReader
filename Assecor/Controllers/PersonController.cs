using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

namespace Assecor.Controllers
{
    
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        
        public PersonController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/Persons")]
        public List<Person> Persons()
        {
            return _dataAccessProvider.ReadCSV();
        }

        [HttpGet]
        [Route("api/Persons/{Id}")]
        public List<Person> Persons(int Id)
        {
            return _dataAccessProvider.ReadCSVById(Id);
        }

        [HttpGet]
        [Route("api/Persons/color/{color}")]
        public List<Person> Persons(string color)
        {
            return _dataAccessProvider.ReadCSVByColour(color);
        }

    }
}