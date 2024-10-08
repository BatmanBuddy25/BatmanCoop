using BatmanCoopShared.Interfaces.ManpowerInterface;
using BatmanCoopShared.Model.ManpowerModel;
using Microsoft.AspNetCore.Mvc;

namespace BatmanCoop.Controllers.ManpowerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentMemController(IWebHostEnvironment webhost, IAttachmentInt attachInt) : ControllerBase
    {
        private readonly IWebHostEnvironment _webhost = webhost ?? throw new ArgumentNullException(nameof(webhost));
        private readonly IAttachmentInt _attachInt = attachInt;


        //private async Task<List<AttachmentMem>> ReturnObj()
        //{
        //    return await _context.MemAttachTable.ToListAsync();
        //}

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
