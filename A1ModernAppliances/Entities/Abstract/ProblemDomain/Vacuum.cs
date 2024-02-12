using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities.ProblemDomain
{
    internal class Vacuum : Appliance
    {
        private readonly string _grade;
        private readonly short _batteryVoltage;

        public string Grade { get { return _grade; } }
        public short BatteryVoltage { get { return _batteryVoltage; } }

        public Vacuum(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string grade, short batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _batteryVoltage = batteryVoltage;
        }

        public override string ToString()
        {
            return $"{"Item Number:",-15}{ItemNumber}\n" +
                   $"{"Brand:",-15}{Brand}\n" +
                   $"{"Quantity:",-15}{Quantity}\n" +
                   $"{"Wattage:",-15}{Wattage}\n" +
                   $"{"Color:",-15}{Color}\n" +
                   $"{"Price:",-15}{Price}\n" +
                   $"{"Grade:",-15}{Grade}\n" +
                   $"{"Battery Voltage:",-15}{BatteryVoltage}";
        }
    }
}
