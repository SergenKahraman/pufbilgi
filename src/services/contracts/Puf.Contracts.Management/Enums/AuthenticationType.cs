using System;
using System.Collections.Generic;
using System.Text;

namespace Puf.Contracts.Management.Enums
{
    public enum AuthenticationType
    {
        Success,
        Passive,
        WaitsVerification,
        PasswordExpired
    }
}
