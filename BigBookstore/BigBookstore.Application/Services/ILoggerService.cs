﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Services
{
    public interface ILoggerService 
    {
        Task Log(string message, string stackTrace);
    }
}
