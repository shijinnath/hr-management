using APIGateway.Models;

namespace APIGateway.Services
{
    public interface IRouteHandler
    {
        Task<ApiResponse> HandleRoute(string serviceName, string action);
    }
}
