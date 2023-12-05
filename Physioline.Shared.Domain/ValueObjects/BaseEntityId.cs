namespace Physioline.Shared.Domain.ValueObjects;

public record BaseEntityId
{
	public long Value { get; init; }

        public BaseEntityId(long value)
        {
            Value = value;
        }

        public static implicit operator long (BaseEntityId obj)
		=> obj.Value;
	public static implicit operator BaseEntityId (long value)
		=> new BaseEntityId (value);
}
