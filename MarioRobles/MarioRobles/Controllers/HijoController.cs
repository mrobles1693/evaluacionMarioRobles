using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness;
using Entity;

namespace MarioRobles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HijoController : ControllerBase
    {
        [HttpGet]
        public eResponse Get()
        {
            return new bHijo().sp_Hijo_select();
        }

        [HttpGet("{id}")]
        public eResponse Get(int id)
        {
            return new bHijo().sp_Hijo_select_by_personal(id);
        }

        [HttpPut]
        public eResponse Put([FromBody] Hijo hijo)
        {
            return new bHijo().sp_Hijo_insert(hijo);
        }

        [HttpPost]
        public eResponse Update([FromBody] Hijo hijo)
        {
            return new bHijo().sp_Hijo_update(hijo);
        }

        [HttpDelete("{id}")]
        public eResponse Delete(int id)
        {
            return new bHijo().sp_Hijo_delete(id);
        }
    }
}
