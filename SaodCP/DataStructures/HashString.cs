using SaodCP.Interfaces;
using SaodCP.Utils;

namespace SaodCP.Infrastructure
{
    class HashString : IHashable
    {
        readonly string _value;

        public HashString(string value)
        {
            this._value = value;
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
