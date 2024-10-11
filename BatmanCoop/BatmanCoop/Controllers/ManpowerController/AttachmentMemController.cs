using BatmanCoop.DatabaseContext;
using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BatmanCoop.Controllers.ManpowerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentMemController(IWebHostEnvironment webhost, IAttachmentInt attachInt, DataBaseConfiguration context) : ControllerBase
    {
        private readonly DataBaseConfiguration _context = context;
        private readonly IWebHostEnvironment _webhost = webhost ?? throw new ArgumentNullException(nameof(webhost));
        private readonly IAttachmentInt _attachInt = attachInt;

        [HttpGet("Getheadcount")]
        public async Task<ActionResult<int>> Getheadcount()
        {
            return await _context.MemberTable.CountAsync();
        }

        [HttpPost("Postattachment")]
        public async Task<ActionResult<string>> CreateEmpImage(MemberAttachM _obj)
        {
            var filePath = Path.Combine(_webhost.ContentRootPath, "AttachmentFile", _obj.Member_No + "_" + _obj.LastName);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            using (var memoryStream = new MemoryStream())
            {
                System.IO.File.WriteAllBytes(Path.Combine(filePath, _obj.Img_Filename), _obj.Img_Data!);
            }

            MemberAttachM _attachObj = new()
            {
                Img_Code = _obj.Img_Code,
                Img_Filename = _obj.Img_Filename,
                Img_Contenttype = _obj.Img_Contenttype,
                Img_URL = filePath,
                LastName = _obj.LastName,
                Img_Data = null,
                Img_Date = DateTime.Now.Date,
                Member_No = _obj.Member_No,
            };
            var obj = await _attachInt.InsertAttachment(_attachObj);
            return Ok(obj);
        }
    }
}
