using SaodCP.Interfaces;
using SaodCP.Utils;

namespace SaodCP.Infrastructure
{
    /// <summary>
    /// like-string класс для удобного вызова своей реализации хеша
    /// через стандартный GetHashCode()
    /// </summary>
    class HashString : IHashable
    {
        readonly string _value;

        public HashString(string value)
        {
            this._value = value;
        }

        public override int GetHashCode()
        {
            return HashCode();
        }

        public int HashCode()
        {
            return _value.HashCode();
        }

        public static implicit operator string(HashString d)
        {
            return d._value;
        }

        public static implicit operator HashString(string d)
        {
            return new HashString(d);
        }
    }
}
