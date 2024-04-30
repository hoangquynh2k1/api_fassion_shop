namespace API_FashionShop.Entities
{
    public class Respone
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public dynamic? data { get; set; }

        public Respone(bool success, int status, string message = "", object? data = null)
        {
            this.Success = success;
            this.StatusCode = status;
            switch(status)
            {
                case 400:
                    this.StatusMessage = "Your request is not valid";
                    break;
                case 403:
                    this.StatusMessage = "You do not have access";
                    break;
                case 404:
                    this.StatusMessage = "Could not find what you requested";
                    break;
                case 500:
                    this.StatusMessage = "Server error";
                    break;
                default:
                    this.StatusMessage = string.Empty;
                    break;
            }
            if(message != "")
                this.StatusMessage = message;
            this.data = data;
        }
    }
    public struct Status
    {
        public static int Success = 200;
        public static int NotFound = 404;
        public static int BadRequest = 400;
        public static int Forbidden = 403;
        public static int ApplicationError = 500;
    }
}
