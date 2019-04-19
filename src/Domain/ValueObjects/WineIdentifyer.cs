using System;
using System.Collections.Generic;

namespace Wineventory.Domain.ValueObjects
{
    public class WineIdentifyer : IEquatable<WineIdentifyer>
    {
        public WineIdentifyer(string producer, string name, string vintage)
        {
            Producer = producer;
            WineName = name;
            Vintage = vintage;
        }

        public string Producer { get; }
        public string WineName { get; }
        public string Vintage { get; }

        public bool Equals(WineIdentifyer other)
        {
            return Producer == other.Producer && WineName == other.WineName && Vintage == other.Vintage;
        }

        public static bool operator ==(WineIdentifyer identifyer1, WineIdentifyer identifyer2)
        {
            return Equals(identifyer1, identifyer2);
        }

        public static bool operator !=(WineIdentifyer identifyer1, WineIdentifyer identifyer2)
        {
            return !(identifyer1 == identifyer2);
        }

        public override int GetHashCode()
        {
            var hashCode = 481274131;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Producer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WineName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Vintage);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj);
        }
    }
}
