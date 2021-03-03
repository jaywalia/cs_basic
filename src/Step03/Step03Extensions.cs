using System;

namespace Step03
{
    public static class Step03Extensions
    {
        public static double power(this double x, double power)
            => Math.Pow(x,power);
        
        // public static double operator ^(this double x, double power)
        //     => Math.Pow(x,power);

        // regular method , not an extension
        public static double Power(double x, double power)
        {
            return Math.Pow(x, power);
        }

        public static string Capitalize(this string s)
        {
            return s.Substring(0,1).ToUpper() + s.Substring(1);
        }

    }
}

