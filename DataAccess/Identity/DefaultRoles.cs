using Microsoft.AspNetCore.Identity;
using XTaho.Data.WebApp.Models.Access;

namespace XTaho.Data.WebApp.DataAccess.Identity
{
    public class DefaultRoles
    {
        // operator roles
        public static readonly IdentityRole Operator = new () { Name = "Operator", NormalizedName = "Оператор", Id = "D0CFE0E8-D083-4569-A9B9-15125832CAAC".ToLower() };
        //public static readonly Role OperatorManager = new () { Name = "OperatorManager", NormalizedName = "Менеджер оператора", Id = "13095F33-95EC-416B-B8B2-E738FC0BAFD6" };

        //// carrier roles
        //public static readonly Role Carrier = new () { Name = "Carrier", NormalizedName = "Перевозчик", Id = "CD9E5F57-D34E-4BAD-BBDB-0BD596954C28" };
        //public static readonly Role CarrierManager = new () { Name = "CarrierManager", NormalizedName = "Менеджер перевозчика", Id = "B470B71F-C3E3-4675-A939-A905CDA356F8" };
        //public static readonly Role Driver = new () { Name = "Driver", NormalizedName = "Водитель", Id = "2BDDAA8E-AC5F-4865-A187-421C8C4CCA68" };

        //// workshop roles
        //public static readonly Role Workshop = new() { Name = "Workshop", NormalizedName = "Мастерская", Id = "C92AD053-4F8C-4474-B59E-86D49FBD8595" };
        //public static readonly Role WorkshopManager = new() { Name = "WorkshopManager", NormalizedName = "Менеджер мастерской", Id = "840043F5-D610-45E5-AE66-2BB18B49B917" };

        //// other roles
        //public static readonly Role VehicleManufacturer = new () { Name = "VehicleManufacturer", NormalizedName = "Автопроизводитель", Id = "AA9C0D88-1444-472A-B147-621B1DFF32C2" };
        //public static readonly Role Advertising = new () { Name = "Advertising", NormalizedName = "Рекламодатель", Id = "96452B08-4E90-468D-A1DF-A2E51428650B" };
        //public static IEnumerable<RoleModel> GetRoles()
        //{
        //    yield return Operator;
        //    yield return OperatorManager;
        //    yield return Carrier;
        //    yield return CarrierManager;
        //    yield return Driver;
        //    yield return Workshop;
        //    yield return WorkshopManager;
        //    yield return VehicleManufacturer;
        //    yield return Advertising;
        //}
    }
}
