using System;

namespace Step03
{
    public static class Step03Extensions
    {
        public static double power(this double x, double power)
            => Math.Pow(x,power);
        
        // public static double operator ^(this double x, double power)
        //     => Math.Pow(x,power);
    }
}