using InventoryService.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repository
{
   
        public class InventoryConsumer : IConsumer<Airline>
        {
            public async Task Consume(ConsumeContext<Airline> context)
            {
                await Console.Out.WriteLineAsync($"Notification sent: todo id {context.Message}");
            }
        }
    }
