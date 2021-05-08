using System;

namespace Puf.Common.Contracts
{
    public class Settings
    {
        public DatabaseConfiguration Database { get; set; }
        public AuthenticationConfiguration Authentication { get; set; }

        public class DatabaseConfiguration
        {
            public string Default { get; set; }
        }
        public class AuthenticationConfiguration
        {
            public string Secret { get; set; }
        }
    }
}
