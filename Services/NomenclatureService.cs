using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Catalogs;

namespace XTaho.Data.WebApp.Services
{
    public class NomenclatureService
    {
        public async Task<QueryResult<NomenclatureModel>> GetNomenclatureListAsync()
        {
            string qText = "SELECT price, vendorcode, \"name\", description, id, createddate, isdeleted " +
                "FROM public.nsi_nomenclature;";

            return await Connector.GetRecordsAsync<NomenclatureModel>(qText);
        }
        public async Task<ExecuteResult> AddNomenclatureAsync(NomenclatureModel nomenclature)
        {
            string qText = nomenclature.AddRecordQueryText<NomenclatureModel>();
            return await Connector.AddRecordAsync(qText, nomenclature);
        }
        public async Task<ExecuteResult> UpdateNomenclatureAsync(NomenclatureModel nomenclature)
        {
            string qText = nomenclature.UpdateRecordQueryText<NomenclatureModel>();
            return await Connector.UpdateRecordAsync(qText, nomenclature);
        }
    }
}
