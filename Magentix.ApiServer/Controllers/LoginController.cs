using System.ComponentModel.Composition;
using System.Net;
using System.Web.Http;
using Magentix.ApiServer.Lib;
using Magentix.ApiServer.Responses;
using Magentix.Persistance;

namespace Magentix.ApiServer.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginController : ApiController
    {
        private readonly IUserDao _userDao;

        [ImportingConstructor]
        public LoginController(IUserDao userDao)
        {
            _userDao = userDao;
        }

        //GET =>  http://localhost:8080/api/getToken/{pin}
        public MagentixApiLoginResponse GetLogin(string pin)
        {
            MagentixApiLoginResponse ret;

            if (!_userDao.GetIsUserExists(pin))
            {
                ret = new MagentixApiLoginResponse(null, null, HttpStatusCode.Unauthorized);
            }
            else
            {
                var user = _userDao.GetUserByPinCode(pin);
                ret = new MagentixApiLoginResponse(new Token(user.Id),
                                                user,
                                                HttpStatusCode.Accepted,
                                                true);
            }

            return ret;
        }
    }
}
