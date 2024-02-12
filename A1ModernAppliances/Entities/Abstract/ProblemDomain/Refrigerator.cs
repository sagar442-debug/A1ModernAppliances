using ModernAppliances.Entities.Abstract;

namespace  ModernAppliances.Entities.Abstract
{
    internal class Refrigerator : Appliance
    {
        private readonly short _doors;
        private readonly int _width;
        private readonly int _height;

        public short Doors { get { return _doors; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        public Refrigerator(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, short doors, int width, int height)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _doors = doors;
            _width = width;
            _height = height;
        }

        public override string ToString()
        {
            return $"{"Item Number:",-13}{ItemNumber}\n" +
                   $"{"Brand:",-13}{Brand}\n" +
                   $"{"Quantity:",-13}{Quantity}\n" +
                   $"{"Wattage:",-13}{Wattage}\n" +
                   $"{"Color:",-13}{Color}\n" +
                   $"{"Price:",-13}{Price}\n" +
                   $"{"Doors:",-13}{Doors}\n" +
                   $"{"Width:",-13}{Width}\n" +
                   $"{"Height:",-13}{Height}";
        }
    }
}
