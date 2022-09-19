using Data;
using Entity;

namespace Bussiness
{
    public class bPersonal
    {
        public eResponse sp_Personal_insert(Personal personal) => new dPersonal().sp_Personal_insert(personal);
        public eResponse sp_Personal_select() => new dPersonal().sp_Personal_select();
        public eResponse sp_Personal_select_by_id(int idPersonal) => new dPersonal().sp_Personal_select_by_id(idPersonal);
        public eResponse sp_Personal_update(Personal personal) => new dPersonal().sp_Personal_update(personal);
        public eResponse sp_Personal_delete(int idPersonal) => new dPersonal().sp_Personal_delete(idPersonal);
    }
}
