<<<<<<< HEAD:DAL/Request/MainRequest.cs
﻿using BnLog.DAL.Request.Security;

namespace BnLog.DAL.Request
=======
﻿using BnLog.VAL.Request.Security;

namespace BnLog.VAL.Request
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/MainRequest.cs
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
