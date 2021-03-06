using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Solucao_Base.Dominio.Excecoes;
using System;
using System.Collections.Generic;
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
                    DadosInvalidosException => (int)HttpStatusCode.BadRequest,
                    RecursoNaoEncontradoException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var erros = ExtrairErros(e.Message);

                var json = JsonConvert.SerializeObject(new
                {
                    Errors = erros
                });
                await response.WriteAsync(json);
            }
        }

        private static IList<string> ExtrairErros(string mensagemOriginal)
        {
            string[] erros = default;

            if (mensagemOriginal.Contains("Erros:"))
            {
                var content = mensagemOriginal.Split("Erros:");
                erros = content[1].Trim().Split('|');

                return erros;
            }
            else
                return erros;
        }
    }
}
