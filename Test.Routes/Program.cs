﻿using System.Threading.Tasks;
using WatsonWebserver; 

namespace Test.Routes
{
    class Program
    {
        static async Task Main()
        {
            // Create server and load all routes with the Route attribute in current assembly
            using (var server = new Server("127.0.0.1", 8080, false, DefaultRoute))
            {
                server.LoadRoutes();
                server.Start();

                await Task.Delay(-1);
            }
            
            // Load all methods with Route attribute from custom assembly
            // server.LoadRoutes(Assembly.GetExecutingAssembly());
        }

        static async Task DefaultRoute(HttpContext context)
        {
            await context.Response.Send("Welcome to the default route!");
        }
        
        [RouteAttribute("hello")]
        public async Task HelloRoute(HttpContext context)
        {
            await context.Response.Send("Welcome to the hello route!");
        }
        
        [RouteAttribute("post", HttpMethod.POST)]
        public async Task PostRoute(HttpContext context)
        {
            await context.Response.Send("Welcome to the post route!");
        }
    }
}