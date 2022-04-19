using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TestTask2.Contracts;

namespace TestTask2.Infrastructure.Persistence
{
    //Незаверщено т.к. не удалось подключить базу redis

    public class MessageRepository: IMessageRepository
    {
        private readonly IDatabase database;

        public MessageRepository(ConnectionMultiplexer redis)
        {
            database = redis.GetDatabase();
        }

        public async Task<bool> AddMessage(MessageSK message)
        {

            var isDone = await database.StringSetAsync(message.id.ToString(), JsonSerializer.Serialize(message));

            return isDone;
        }

        public async Task<bool> RemoveMessageFrom(Guid boardId, Guid userId)
        {
            var data = await database.StringGetAsync(boardId.ToString());

            if (data.IsNullOrEmpty)
            {
                return false;
            }

            var board = JsonSerializer.Deserialize<MessageSK>(data);
            //board.Users = board.Users.Where(u => u.Id != userId).ToList();
            //board.Body.RemoveAll(u => u.UserId == userId)
            return true;
        }

        public async Task<MessageSK> GetAllMessage(Guid messageId)
        {
            var data = await database.StringGetAsync(messageId.ToString());

            if (data.IsNullOrEmpty)
            {
                return new MessageSK();
            }

            var board = JsonSerializer.Deserialize<MessageSK>(data);

            return board;
        }
    }
}
