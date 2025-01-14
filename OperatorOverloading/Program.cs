using System.ComponentModel.DataAnnotations;

namespace OperatorOverloading
{
    public class Distance
    {
        private int meter;
        private int centimeter;

        public Distance()
        {
            meter = 0;
            centimeter = 0;
        }
        public Distance(int meter, int centimeter)
        {
            this.meter = meter;
            this.centimeter = centimeter;
        }
      /*  public static Distance AddDistance(Distance d1, Distance d2)
        {
            Distance d3= new Distance();
            d3.centimeter = (d1.centimeter + d2.centimeter) % 100 ;
            d3.meter = d1.meter + d2.meter +(d1.centimeter +d2.centimeter);
            return d3;
        }
      */
        public static Distance operator+(Distance d1, Distance d2)
        {
            Distance d3 = new Distance();
            d3.centimeter = (d1.centimeter + d2.centimeter) % 100;
            d3.meter = d1.meter + d2.meter + (d1.centimeter + d2.centimeter)/100;
            return d3;
        }
        public static Distance operator ++(Distance d)
        {
           
            return new Distance(d.meter +1, d.centimeter);
        }
        public static void  Display(Distance d)
        {
            Console.WriteLine($"the distance is{d.meter} and {d.centimeter}. ");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //int x = 5, y = 6;
            //int z = x+y;
            Distance d1 = new Distance(12,63);
            
            Distance d2 = new Distance(45,87);
             Distance d3 = d1+d2;
            Distance.Display(d3);
            Distance.Display(++d3);
            //or Display(d3) then d3++;
            //Distance d3 = Distance.AddDistance(d1, d2);
        }
    }
}
//operator overloadin g must have static