using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoopShared.Interfaces.ManpowerInterface
{
    public interface IMemberInt
    {
        Task InsertMember(MemberM _obj);
        Task<List<MemberM>> GetMasterList();
        Task<int> Getheadcount();
    }
}
