
﻿using BnLog.VAL.Request.Security;

namespace BnLog.VAL.Request

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
