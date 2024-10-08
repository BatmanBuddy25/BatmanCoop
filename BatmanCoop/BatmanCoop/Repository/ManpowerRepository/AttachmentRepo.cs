using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Model.ManpowerModel;

namespace BatmanCoop.Repository.ManpowerRepository
{
    public class AttachmentRepo(DataBaseConfiguration context, IWebHostEnvironment webhost) : IAttachmentInt
    {
        private readonly DataBaseConfiguration _context = context;
        private readonly IWebHostEnvironment _webhost = webhost ?? throw new ArgumentNullException(nameof(webhost));
        public async Task<string> InsertAttachment(MemberAttachM _obj)
        {
            if (_obj is null) return "NoAttachment";

            var _filepath = Path.Combine(_webhost.ContentRootPath, "AttachmentFile", _obj.Member_No + "_" + _obj.LastName);
            if (!Directory.Exists(_filepath))
                Directory.CreateDirectory(_filepath);

            using (var memoryStream = new MemoryStream())
            {
                System.IO.File.WriteAllBytes(Path.Combine(_filepath, _obj.Img_Filename), _obj.Img_Data!);
            }

            MemberAttachM _attachObj = new()
            {
                Img_Filename = _obj.Img_Filename,
                Img_Contenttype = _obj.Img_Contenttype,
                Img_URL = _filepath,
                LastName = _obj.LastName,
                Img_Data = null,
                Img_Date = DateTime.Now.Date,
                Member_No = _obj.Member_No,
            };

            _context.MemAttachTable.Add(_attachObj);
            await _context.SaveChangesAsync();

            return "Success";
        }
    }
}
