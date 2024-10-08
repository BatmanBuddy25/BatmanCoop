using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoopShared.Interfaces.ManpowerInterface
{
    public interface IMemberInt
    {
        Task InsertMember(MemberM _obj);
        Task UpdateMember(MemberM _obj);
        Task<List<MemberM>> GetMasterList();
        Task<List<MemberM>> GetSortreferal(string refCode);
        Task<int> Getheadcount();
    }
}
