using BatmanCoopShared.Interfaces.AccountInterface;
using BatmanCoopShared.Model.AccountModel;
using Microsoft.AspNetCore.Mvc;

namespace BatmanCoop.Controllers.AccountController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController(IUserAccountInt useraccountint) : ControllerBase
    {
        private readonly IUserAccountInt _useraccountint = useraccountint;


        [HttpGet("Getmasterlist")]
        public async Task<ActionResult<IEnumerable<UserAccountM>>> Getmasterlist()
        {
            var _masterList = await _useraccountint.GetMasterList();
            return Ok(_masterList);
        }

        [HttpGet("Getheadcount")]
        public async Task<ActionResult<int>> Getheadcount()
        {
            var _masterCount = await _useraccountint.Getheadcount();
            return Ok(_masterCount);
        }

        [HttpPost("Postobj")]
        public async Task<ActionResult> Postobj(UserAccountM _obj)
        {
            await _useraccountint.AddAccount(_obj);
            return Ok();
        }

        [HttpPut("Putuseraccount")]
        public async Task<ActionResult> Buysharecap(UserAccountM _obj)
        {
            await _useraccountint.UpdateAccount(_obj);
            return Ok();
        }
    }
}
