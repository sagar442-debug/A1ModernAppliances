using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities.ProblemDomain
{
    internal class Dishwasher : Appliance
    {
        private readonly string _feature;
        private readonly string _soundRating;

        public string Feature { get { return _feature; } }
        public string SoundRating { get { return _soundRating; } }

        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _feature = feature;
            _soundRating = soundRating;
        }

        public override string ToString()
        {
            return $"{"Item Number:",-15}{ItemNumber}\n" +
                   $"{"Brand:",-15}{Brand}\n" +
                   $"{"Quantity:",-15}{Quantity}\n" +
                   $"{"Wattage:",-15}{Wattage}\n" +
                   $"{"Color:",-15}{Color}\n" +
                   $"{"Price:",-15}{Price}\n" +
                   $"{"Feature:",-15}{Feature}\n" +
                   $"{"Sound Rating:",-15}{(_soundRating == "Qt" ? "Quietest" : (_soundRating == "Qr" ? "Quieter" : (_soundRating == "Qu" ? "Quiet" : (_soundRating == "M" ? "Moderate" : "Unknown"))))}";
        }
    }
}
