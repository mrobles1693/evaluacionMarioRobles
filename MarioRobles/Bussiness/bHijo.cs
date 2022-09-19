using Data;
using Entity;

namespace Bussiness
{
    public class bHijo
    {
        public eResponse sp_Hijo_insert(Hijo hijo) => new dHijo().sp_Hijo_insert(hijo);
        public eResponse sp_Hijo_select() => new dHijo().sp_Hijo_select();
        public eResponse sp_Hijo_select_by_id(int idHijo) => new dHijo().sp_Hijo_select_by_id(idHijo);
        public eResponse sp_Hijo_select_by_personal(int idPersonal) => new dHijo().sp_Hijo_select_by_personal(idPersonal);
        public eResponse sp_Hijo_update(Hijo hijo) => new dHijo().sp_Hijo_update(hijo);
        public eResponse sp_Hijo_delete(int idHijo) => new dHijo().sp_Hijo_delete(idHijo);

    }
}
