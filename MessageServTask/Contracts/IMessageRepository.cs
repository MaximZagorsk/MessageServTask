using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask2.Contracts
{
    public interface IMessageRepository
    {
        Task<bool> AddMessage(MessageSK message);
        Task<bool> RemoveMessageFrom(Guid boardId, Guid userId);
        Task<MessageSK> GetAllMessage(Guid messageId);
    }
}
