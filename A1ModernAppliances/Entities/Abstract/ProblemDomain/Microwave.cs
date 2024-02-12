using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities.ProblemDomain
{
    internal class Microwave : Appliance
    {
        private readonly float _capacity;
        private readonly char _roomType;

        public float Capacity { get { return _capacity; } }
        public char RoomType { get { return _roomType; } }

        public Microwave(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, float capacity, char roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _capacity = capacity;
            _roomType = roomType;
        }

        public override string ToString()
        {
            return $"{"Item Number:",-15}{ItemNumber}\n" +
                   $"{"Brand:",-15}{Brand}\n" +
                   $"{"Quantity:",-15}{Quantity}\n" +
                   $"{"Wattage:",-15}{Wattage}\n" +
                   $"{"Color:",-15}{Color}\n" +
                   $"{"Price:",-15}{Price}\n" +
                   $"{"Capacity:",-15}{Capacity}\n" +
                   $"{"Room Type:",-15}{(_roomType == 'K' ? "Kitchen" : (_roomType == 'W' ? "Work Site" : "Unknown"))}";
        }
    }
}
