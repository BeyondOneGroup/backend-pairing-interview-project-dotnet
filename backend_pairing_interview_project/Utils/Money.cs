using System;

namespace backend_pairing_interview_project.utils
{
    public class Money : IEquatable<Money>
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Value cannot be less than zero.", nameof(value));
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString("C");
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator >(Money a, Money b) => a.Value > b.Value;
        public static bool operator <(Money a, Money b) => a.Value < b.Value;
        public static bool operator >=(Money a, Money b) => a.Value >= b.Value;
        public static bool operator <=(Money a, Money b) => a.Value <= b.Value;

        public static Money operator +(Money a, Money b) => new Money(a.Value + b.Value);
        public static Money operator -(Money a, Money b)
        {
            var result = a.Value - b.Value;
            if (result < 0) throw new InvalidOperationException("Money cannot be negative.");
            return new Money(result);
        }
    }
}