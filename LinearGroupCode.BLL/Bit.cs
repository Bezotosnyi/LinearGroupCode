// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bit.cs" company="DNU">
//   Dima Bezotosnyi
// </copyright>
// <summary>
//   Defines the Bit type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LinearGroupCode.BLL
{
    using System;

    /// <summary>
    /// Структура бит (содержит 0 либо 1)
    /// </summary>
    public struct Bit : IComparable, IFormattable, IConvertible, IComparable<Bit>, IEquatable<Bit>
    {
        public const byte MinValue = 0;

        public const byte MaxValue = 1;

        private readonly byte currentValue;

        private Bit(byte value)
        {
            if (!CheckValue(value)) throw new Exception($"Не удается преобразовать. Число должно быть в диапазоне {MinValue}-{MaxValue}");
            this.currentValue = value;
        }

        #region Overload operators
        public static bool operator >(Bit bit1, Bit bit2)
        {
            return bit1.currentValue > bit2.currentValue;
        }

        public static bool operator <(Bit bit1, Bit bit2)
        {
            return bit1.currentValue < bit2.currentValue;
        }

        public static bool operator ==(Bit bit1, Bit bit2)
        {
            return bit1.currentValue == bit2.currentValue;
        }

        public static bool operator !=(Bit bit1, Bit bit2)
        {
            return bit1.currentValue != bit2.currentValue;
        }

        public static Bit operator ^(Bit bit1, Bit bit2)
        {
            if ((bit1.currentValue == 0 && bit2.currentValue == 0) || (bit1.currentValue == 1 && bit2.currentValue == 1)) return new Bit(0);
            return new Bit(1);
        }

        public static Bit operator -(Bit bit1, Bit bit2)
        {
            if ((bit1.currentValue == 0 && bit2.currentValue == 0) || (bit1.currentValue == 1 && bit2.currentValue == 1) ||
                (bit1.currentValue == 0 && bit2.currentValue == 1)) return new Bit(0);
            return new Bit(1);
        }

        public static implicit operator Bit(byte value)
        {
            return new Bit(value);
        }

        public static implicit operator byte(Bit value)
        {
            return value.currentValue;
        }
        #endregion

        public static Bit Parse(string str)
        {
            return new Bit(byte.Parse(str));
        }

        public static Bit Parse(char c)
        {
            return new Bit(byte.Parse(c.ToString()));
        }

        public static bool TryParse(string str, out Bit bit)
        {
            bit = MinValue;
            try
            {
                bit = Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryParse(char c, out Bit bit)
        {
            bit = MinValue;
            try
            {
                bit = Parse(c);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(Bit bit)
        {
            return this.currentValue == bit.currentValue;
        }

        public override int GetHashCode()
        {
            return this.currentValue.GetHashCode();
        }

        public override string ToString()
        {
            return this.currentValue.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Bit && this.Equals((Bit)obj);
        }

        #region Realisation Interfaces

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Convert.ToString(format, formatProvider);
        }

        public int CompareTo(object value)
        {
            if (value == null)
            {
                return 1;
            }

            if (!(value is Bit))
            {
                throw new LinearGroupCodeException("Argument must be Bit");
            }

            return this.currentValue - ((Bit)value).currentValue;
        }

        public int CompareTo(Bit value)
        {
            return this.currentValue - value.currentValue;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(this.currentValue);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(this.currentValue);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(this.currentValue);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(this.currentValue);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(this.currentValue);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(this.currentValue);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(this.currentValue);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(this.currentValue);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(this.currentValue);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(this.currentValue);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(this.currentValue);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(this.currentValue);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(this.currentValue);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(this.currentValue);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Convert.ToString(this.currentValue);
        }

        object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return Convert.ChangeType(this.currentValue, type, provider);
        }
        #endregion

        private static bool CheckValue(byte value)
        {
            return value <= MaxValue;
        }
    }
}