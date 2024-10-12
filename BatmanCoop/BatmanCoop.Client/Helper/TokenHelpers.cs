using BatmanCoopShared.Interfaces.LendInterface;
using BatmanCoopShared.Interfaces.TransactionInterface;
using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoop.Client.Helper
{
    public class TokenHelpers(ITransactionInt translogService)
    {
        private readonly ITransactionInt _translogService = translogService;
    
        private string MemberCode = string.Empty;

        public  void Set_MemberCode(string _paramCode)
        {
            MemberCode = _paramCode;
        }
        public string Get_MemberCode()
        {
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

        public async Task<string> OnGetmasterno()
        {
            string _returnString = string.Empty;
            int _headcount = await _translogService.Getheadcount() + 1;
            var _memNo = _headcount.ToString().PadLeft(2, '0');
            _returnString = $"TN{_memNo}";
            return _returnString ;
        }

        public MemberM GetModel()
        {
            MemberM _obj = new()
            {
                Id = 1,
                MemberNo = "MN000000",
                LastName = "Admin",
                FirstName = "Coop",
                MiddleName = "B",
                BirthDate = DateTime.Now,
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
