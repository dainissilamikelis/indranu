using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using indranu7.Models;

namespace indranu7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentDataController : ControllerBase
    {
        // GET api/apartments
        [HttpGet]
        public ActionResult<IEnumerable<ApartmenDataModel>> Get()
        {
            var apartmentData = new ApartmenDataModel[15];
            var apartment = new ApartmenDataModel();
            apartment.ApartmenNo = 1;
            apartment.Debt = 1.5M;
            apartment.DebtInfo = "test";
            apartment.ExtraInfo = "test 1";
            apartment.TenantAmount = 1.4M;
            apartmentData[0] = apartment;
            return apartmentData;
        }
    }
}