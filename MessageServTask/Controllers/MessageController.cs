using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask2.Contracts;
using TestTask2.Infrastructure.Persistence;

namespace TestTask2.Controllers
{

    [Route("api")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        //Чтобы не создавать целую базу на компьютере, для тестового задания была создана статик переменная со списком сообщений
        // В планах было сделать базу на redis с MessageRepository, но это заняло бы много времени
        static List<MessageSK> messageSKS = new List<MessageSK>() {
            new MessageSK()
            {
                id = Guid.NewGuid(),
                Body = "Секретное сообщение",
                FromUser = "Maks"
            },
             new MessageSK()
            {
                id = Guid.NewGuid(),
                Body = "Как дела",
                FromUser = "Maks"
            },
              new MessageSK()
            {
                id = Guid.NewGuid(),
                Body = "Привет",
                FromUser = "Maks"
            },
        };
        //public MessageController()
        //{

        //    this.messageSKS = new List<MessageSK>();
        //}


        //Создание сообщений для теста
        [HttpGet("messageCreate")]
        public IActionResult GetTemplateMessage()
        {
            var newmes = new MessageSK();
            var id = Guid.NewGuid();
            newmes.Body = "TestTestTest";
            newmes.FromUser = "maks";
            newmes.id = id;

            messageSKS.Add(newmes);

            return Ok(messageSKS);
        }

        //Получение списка сообщений
        [HttpGet("messages")]
        public async Task<IActionResult> GetMessage()
        {
            return Ok(messageSKS);
        }

        //Пост запрос для удаления сообщений
        [HttpPost("delete_message")]
        public async Task<IActionResult> DeleteMessages([FromBody] MyPostModel gr)
        {
            foreach (MessageSK message in gr.MessagesToDelete)
            {
                var itemToRemove = messageSKS.Single(x => x.id == message.id);
                messageSKS.Remove(itemToRemove);
            };
            return Ok(messageSKS);
        }

    }
}
