﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;
using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;
using static Humanizer.In;

namespace XTaho.Data.WebApp.Models.Access
{
    [DataTable("NSI_CRUD")]
    public class CRUD : BaseModel
    {
        [DataTableColumn("RoleId", WellknownDataTypes.TEXT)]
        public string? RoleId { get; set; }

        [DataTableColumn("ModelName", WellknownDataTypes.TEXT)]
        public string? ModelName { get; set; }

        [DataTableColumn("CanCreate", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanCreate { get; set; }

        [DataTableColumn("CanRead", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanRead { get; set; }

        [DataTableColumn("CanUpdate", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanUpdate { get; set; }

        [DataTableColumn("CanDelete", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool CanDelete { get; set; }

        public static string RecordsQueryText(string roleId)
        {
            string qText = "SELECT roleid, smodels.name as modelname, case when crud.cancreate is null then false else crud.cancreate end as cancreate, " +
                "case when crud.canread is null then false else crud.canread end as canread, case when crud.canupdate is null then false else crud.canupdate end as canupdate, " +
                "case when crud.candelete is null then false else crud.candelete end as candelete " +
                "FROM nsi_systemmodels as smodels left join(select roleId, modelname, cancreate, canread, canupdate, candelete from nsi_crud " +
                $"where roleId = '{roleId}') as crud on smodels.name = crud.modelname where smodels.isdeleted != true;";

            return qText;
        }
        public static string RecordsQueryText(string roleId, string modelName)
        {
            string qText = "SELECT roleid, smodels.name as modelname, case when crud.cancreate is null then false else crud.cancreate end as cancreate, " +
                "case when crud.canread is null then false else crud.canread end as canread, case when crud.canupdate is null then false else crud.canupdate end as canupdate, " +
                "case when crud.candelete is null then false else crud.candelete end as candelete " +
                "FROM nsi_systemmodels as smodels left join(select roleId, modelname, cancreate, canread, canupdate, candelete from nsi_crud " +
                $"where roleId = '{roleId}') as crud on smodels.name = crud.modelname where smodels.isdeleted != true and smodels.name='{modelName};";
 
            return qText;
        }
        public static string RecordsQueryTextByUserId(string userId)
        {
            string qText = "select modelname, bool_or(cancreate) as cancreate, bool_or(canread) as canread, bool_or(canupdate) as canupdate, bool_or(candelete) as candelete " +
                "from public.nsi_crud " +
                $"where roleid in (select \"RoleId\" from \"AspNetUserRoles\" where \"UserId\" = '{userId}') " +
                "group by modelname;";

            return qText;
        }

        public static string RecordsQueryTextForOperator()
        {
            string qText = "SELECT \"name\" as modelname, true as cancreate, true as canread, true as canupdate, true as candelete " +
                "FROM public.nsi_systemmodels;";

            return qText;
        }
    }
}
