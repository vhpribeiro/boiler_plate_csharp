using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Solucao_Base.Apresentacao.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = e switch
                {
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var json = JsonConvert.SerializeObject(new { e.Message });
                await response.WriteAsync(json);
            }
        }
    }
}
