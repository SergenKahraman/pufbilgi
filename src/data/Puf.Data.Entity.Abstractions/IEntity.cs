using System;

namespace Puf.Data.Entity.Abstractions
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
    }
}
