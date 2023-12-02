
﻿using BnLog.VAL.Request.Security;

namespace BnLog.VAL.Request

{
    public class MainRequest1
    {
        public UserRegisterRequest RegisterView { get; set; }

        public UserLoginRequest LoginView { get; set; }

        public MainRequest1()
        {
            RegisterView = new UserRegisterRequest();
            LoginView = new UserLoginRequest();
        }
    }
}
