using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Access
{
    [DataTable("NSI_CRUD")]
    public class CRUD : BaseModel
    {
        [DataTableColumn("RoleId", WellknownDataTypes.TEXT)]
        public string RoleId { get; set; }

        [DataTableColumn("ModelName", WellknownDataTypes.TEXT)]
        public string ModelName { get; set; }

        [DataTableColumn("CanCreate", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanCreate { get; set; }

        [DataTableColumn("CanRead", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanRead { get; set; }

        [DataTableColumn("CanUpdate", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanUpdate { get; set; }

        [DataTableColumn("CanDelete", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanDelete { get; set; }


        public CRUD() { }

        public static string RecordsQueryText(string roleId)
        {
            string qText = "SELECT smodels.name as modelname, crud.cancreate is not null as cancreate," +
                " crud.canread is not null as canread, crud.canupdate is not null as canupdate, crud.candelete is not null as candelete\r\n" +
                "FROM nsi_systemmodels as smodels\r\n" +
                $"left join (select roleId, modelname, cancreate, canread, canupdate, candelete from nsi_crud where roleId ='{roleId}')" +
                " as crud on smodels.name = crud.modelname\r\nwhere smodels.isdeleted != true;";

            return qText;
        }
        public static string RecordsQueryText(string roleId, string modelName)
        {
            string qText = "SELECT smodels.name as modelname, crud.cancreate is not null as cancreate," +
                " crud.canread is not null as canread, crud.canupdate is not null as canupdate, crud.candelete is not null as candelete\r\n" +
                "FROM nsi_systemmodels as smodels\r\n" +
                $"left join (select roleId, modelname, cancreate, canread, canupdate, candelete from nsi_crud where roleId ='{roleId}')" +
                $" as crud on smodels.name = crud.modelname\r\nwhere smodels.isdeleted != true and smodels.name='{modelName}';";

            return qText;
        }

    }
}
