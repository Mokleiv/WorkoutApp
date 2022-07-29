namespace HomeAPI.Common.Base
{
    public class UserError
    {
        public UserError(string message, string code)
        {
            Message = message;
            Code = code;
        }
        private string Message { get; }
        private string Code { get; }
    }
}
