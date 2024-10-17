using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BatmanCoop.Client.Helper
{
    public class TokenService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public TokenService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
            OnLoadAuth();
        }

        private int _accid;
        public int AccId
        {
            get => _accid;
            set
            {
                _accid = value;
            }
        }
        private int _memid;
        public int MemId
        {
            get => _memid;
            set
            {
                _memid = value;
            }
        }
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
            }
        }
        private string _userrole;
        public string UserRole
        {
            get => _userrole;
            set
            {
                _userrole = value;
            }
        }

        private async void OnLoadAuth()
        {
            var _authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = _authState.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                var empidstring = user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Sid)?.Value;
                MemId = empidstring != null ? Convert.ToInt32(empidstring) : 0;
                Username = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty;
                UserRole = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
                var userid = user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.PrimarySid)?.Value;
                AccId = userid != null ? Convert.ToInt32(userid) : 0;
            }
        }
    }
}
