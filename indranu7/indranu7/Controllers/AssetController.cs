﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using indranu7.models;
using indranu7.buisinessLogic;

namespace indranu7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        [HttpGet]
        public ActionResult<AssetModel[]> GetAssetFields()
        {
            return formatMetadata.GetAssets();
        }
    }
}