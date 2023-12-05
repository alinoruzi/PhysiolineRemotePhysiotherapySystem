namespace Physioline.Shared.Domain.ValueObjects;

public record BaseEntityCreatedAt
{
	public DateTime Value { get; init; }

        public BaseEntityCreatedAt(DateTime dateTime)
        {
            Value = dateTime;
        }

	public static implicit operator DateTime(BaseEntityCreatedAt obj)
		=> obj.Value;
	public static implicit operator BaseEntityCreatedAt (DateTime dateTime)
        => new BaseEntityCreatedAt(dateTime);
	
}
