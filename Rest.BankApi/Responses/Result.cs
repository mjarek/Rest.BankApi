using Rest.BankApi.Services.Enums;

namespace Rest.BankApi.Responses
{
    public class Result
    {
        public StatusProduct StatusProduct { get; set; }
        public decimal Balance { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}