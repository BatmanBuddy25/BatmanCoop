using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoopShared.Interfaces.ManpowerInterface
{
    public interface IAttachmentInt
    {
        Task<string> InsertAttachment(MemberAttachM _obj);
    }
}
