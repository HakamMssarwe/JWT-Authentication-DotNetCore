﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Demo
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
