using BnLog.DLL.Request;
using BnLog.DLL.Request.Security;

namespace BnLog.DLL.Request
{
    public class MainRequest
    {
        public UserRegisterRequest RegisterView { get; set; }

        public UserLoginRequest LoginView { get; set; }

        public MainRequest()
        {
            RegisterView = new UserRegisterRequest();
            LoginView = new UserLoginRequest();
        }
    }
}
