using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Data.Middleware
{
    public class AllowedCorsMiddleware
    {
        private readonly RequestDelegate _next;
        public AllowedCorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //function which get requst from client
        public async Task Invoke(HttpContext context)
        {
            //which address allowed connect to this server
            //(solution for the CORS problam)
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //if i want to show my headers
            //if i want block particular header then i'm not write him in this array
            context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });
            //which methods allowed call from this server
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "*" });

            //before server
            await _next(context);
            //after server
        }
    }
}
