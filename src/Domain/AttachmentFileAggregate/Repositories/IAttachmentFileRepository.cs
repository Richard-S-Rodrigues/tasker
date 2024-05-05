using Tasker.Domain.AttachmentFileAggregate;
using Tasker.Domain.AttachmentFileAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;

namespace Tasker.Domain.AttachmentFileAggregate.Repositories;

public interface IAttachmentFileRepository : IRepository<AttachmentFile, AttachmentFileId>
{

}