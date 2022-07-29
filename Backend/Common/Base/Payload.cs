namespace HomeAPI.Common.Base
{
    public abstract class Payload
    {
        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }
        private IReadOnlyList<UserError>? Errors { get; }
    }
}
