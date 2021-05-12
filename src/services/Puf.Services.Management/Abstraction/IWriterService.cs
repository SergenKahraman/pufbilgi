using Puf.Contracts.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puf.Services.Management.Abstraction
{
    public interface IWriterService
    {
        IEnumerable<WriterDto> GetListOfWriter(int count);
        WriterDto GetWriter(Guid Id);
        UserInfoDto Authenticate(string username, string password);
        (bool isSuccess, Guid writerId, string code) Register(NewWriterDto newUser);
        bool CheckIfCodeAndUserExists(string code, Guid writerId);
        bool UpdateWriter(WriterDto writerDto);
    }
}
