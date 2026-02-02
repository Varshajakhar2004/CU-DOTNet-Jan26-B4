namespace OOPs
{
    class height
    {
        public int Feet { get; set; }
        public double Inches { get; set; }

        public height()
        {
            Feet = 0;
            Inches = 0.0;
        }

        public height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public height AddHeights(height h2)
        {
            int totalFeet = this.Feet + h2.Feet;
            double totalInches = this.Inches + h2.Inches;

            if (totalInches >= 12)
            {
                totalFeet += (int)(totalInches / 12);
                totalInches = totalInches % 12;
            }

            return new height(totalFeet, totalInches);
        }

        public override string ToString()
        {
            return $"Height - {Feet} feet {Inches:F1} inches";
        }
    }
    internal class compareheight
    {
        static void Main(string[] args)
        {
            height person1 = new height(5, 6.5);
            height person2 = new height(5, 7.5);

            height totalHeight = person1.AddHeights(person2);

            Console.WriteLine($"Person1 : {person1}");
            Console.WriteLine($"Person2 : {person2}");
            Console.WriteLine($"total height : {totalHeight}");

        }
    }
}
