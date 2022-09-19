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
    public class PersonalController : ControllerBase
    {
        [HttpGet]
        public eResponse Get()
        {
            return new bPersonal().sp_Personal_select();
        }

        [HttpGet("{id}")]
        public eResponse Get(int id)
        {
            return new bPersonal().sp_Personal_select_by_id(id);
        }

        [HttpPut]
        public eResponse Put([FromBody] Personal personal)
        {
            return new bPersonal().sp_Personal_insert(personal);
        }

        [HttpPost]
        public eResponse Update([FromBody] Personal personal)
        {
            return new bPersonal().sp_Personal_update(personal);
        }

        [HttpDelete("{id}")]
        public eResponse Delete(int id)
        {
            return new bPersonal().sp_Personal_delete(id);
        }
    }
}
