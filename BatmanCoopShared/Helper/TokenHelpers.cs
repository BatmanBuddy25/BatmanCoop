using BatmanCoopShared.Model.ManpowerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatmanCoopShared.Helper
{
    public class TokenHelpers
    {
        private static string MemberCode = string.Empty;

        public static void Set_MemberCode(string _paramCode)
        {
            MemberCode = _paramCode;
        }
        public static string Get_MemberCode() { 
        return MemberCode;
        }
        public static void ConvertStringsToUpperCase<T>(T obj)
        {
            if (obj == null) return;

            var stringProperties = typeof(T).GetProperties()
                                            .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

            foreach (var property in stringProperties)
            {
                var value = (string)property.GetValue(obj)!;
                if (value != null)
                {
                    property.SetValue(obj, value.ToUpper());
                }
            }
        }



        public static MemberM GetModel()
        {
            MemberM _obj = new()
            {
                Id = 1,
                MemberNo = "MN000000",
                LastName = "Admin",
                FirstName = "Coop",
                MiddleName = "B",
                BirthDate =  DateTime.Now,
                Age = 1,
                FullAddress = "Davao City",
                CivilStatus = "Single",
                Contact = "09111111111",
                EmailAdd = "loreto.lomocso@sonicsales.net",
                Bank_Number = "09222222222",
                MemStatus = "Active",
                ReferralId = string.Empty,
                ReferralName = string.Empty,
                RegisterDate = DateTime.Now
            };

            return _obj;
        }
    }
}
