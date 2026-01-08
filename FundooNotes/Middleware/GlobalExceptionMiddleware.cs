using BusinessLayer.Exceptions;
using System.Net;
using System.Text.Json;

namespace FundooNotes.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await Write(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (NotFoundException ex)
            {
                await Write(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                await Write(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception)
            {
                await Write(context, HttpStatusCode.InternalServerError, "Server error");
            }
        }

        private static async Task Write(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(new { success = false, message }));
        }
    }
}
