namespace HomeAPI.Common.Interface
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        DateTimeOffset CreatedDate { get; set; }
    }
}
