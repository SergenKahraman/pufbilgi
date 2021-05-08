using Puf.Contracts.Management.Enums;

namespace Puf.Contracts.Management
{
    public class AuthenticationResultDto
    {
        public UserInfoDto Info { get; set; }
        public AuthenticationType Result { get; set; }
    }

    
}