using DataContainer.Interfaces;

namespace WebApp.Models
{
    public class ErrorMessageResponse(string errorMessage) : IAPIResponse
    {
        public string ErrorMessage { get; private set; } = errorMessage;

        public bool Ok { get; } = false;
    }
}
