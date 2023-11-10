namespace Buldex.Domain.Abstractions
{
    public abstract class EntityId<T> : IEntityId, IEquatable<EntityId<T>>
    {
        public T Value { get; }
        protected EntityId(T t)
        {
            Value = t;
        }

        public override string ToString() => Value?.ToString() ?? string.Empty;

        public bool Equals(EntityId<T>? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EntityId<T>)obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? EqualityComparer<T>.Default.GetHashCode(Value) : 0;
        }

        public static bool operator ==(EntityId<T>? left, EntityId<T>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityId<T>? left, EntityId<T>? right)
        {
            return !Equals(left, right);
        }

        public static implicit operator T(EntityId<T> value) => value.Value;
    }
}