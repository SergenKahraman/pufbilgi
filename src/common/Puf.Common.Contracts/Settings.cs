using System;

namespace Puf.Common.Contracts
{
    public class Settings
    {
        public DatabaseConfiguration Database { get; set; }

        public class DatabaseConfiguration
        {
            public string Default { get; set; }
        }

    }
}
