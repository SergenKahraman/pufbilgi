using System;

namespace Puf.Services.Management.Abstraction
{
    public interface IMailService
    {
        void SendVerificationMail(Guid writerId, string content);

    }
}
