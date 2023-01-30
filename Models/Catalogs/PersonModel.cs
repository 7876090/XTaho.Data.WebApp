using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_Persons")]
    public class PersonModel : CatalogModel
    {
        [DataTableColumn("FirstName", WellknownDataTypes.VARCHAR_50)]
        public string? FirstName { get; set; }

        [DataTableColumn("LastName", WellknownDataTypes.VARCHAR_50)]
        public string? LastName { get; set; }

        [DataTableColumn("Patronymic", WellknownDataTypes.VARCHAR_50)]
        public string? Patronymic { get; set; }

        [DataTableColumn("PhoneNumber", WellknownDataTypes.VARCHAR_15)]
        public string? PhoneNumber { get; set; }

        [DataTableColumn("BirthDate", WellknownDataTypes.DATE)]
        public DateTime? BirthDate { get; set; }

        [DataTableColumn("DriverLicenceNumber", WellknownDataTypes.INTEGER)]
        public int DriverLicenceNumber { get; set; }

        [DataTableColumn("MemberId", WellknownDataTypes.INTEGER)]
        public int MemberId { get; set; }
        
        public string? MemberName { get; set; }


        public PersonModel()
        {
            CreatedDate= DateTime.MinValue;
        }

    }
}
