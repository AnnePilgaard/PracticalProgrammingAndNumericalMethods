using System;
using System.IO;
using static System.Console;
using static System.Math;


public static class main{

    static double integrate(Func<double,double> f, double a, double b, 
                            double delta = 0.001, double eps = 0.001, double f2 = double.NaN, double f3 = double.NaN){
    double h = b-a;

    if(double.IsNaN(f2)){ 
        f2=f(a+2*h/6); f3=f(a+4*h/6); // first call, no points to reuse
    } 
    double f1 = f(a+h/6);
    double f4 = f(a+5*h/6);
    double Q = (2*f1+f2+f3+2*f4) / 6*(b-a); // higher order rule
    double q = (  f1+f2+f3+  f4) / 4*(b-a); // lower order rule
    double err = Abs(Q-q);
    if (err <= delta+eps*Abs(Q)){
         return Q;
    }
    else return integrate(f,a,(a+b)/2,delta/Sqrt(2),eps,f1,f2) + integrate(f,(a+b)/2,b,delta/Sqrt(2),eps,f3,f4);
    }


    static void Main(){

        Func<double, double> f1 = delegate(double x){
            return Sqrt(x);
        };

        double f1_int = integrate(f1, 0, 1);
        WriteLine($"Integral of Sqrt(x) from 0 to 1 should be 2/3, is: {f1_int}");

        Func<double, double> f2 = delegate(double x){
            return 1/Sqrt(x);
        };

        double f2_int = integrate(f2, 0, 1);
        WriteLine($"Integral of 1/Sqrt(x) from 0 to 1 should be 2, is: {f2_int}");

        Func<double, double> f3 = delegate(double x){
            return 4*Sqrt(1-x*x);
        };

        double f3_int = integrate(f3, 0, 1);
        WriteLine($"Integral of 4*Sqrt(1-x^2) from 0 to 1 should be pi, is: {f3_int}");

        Func<double, double> f4 = delegate(double x){
            return Log(x)/Sqrt(x);
        };

        double f4_int = integrate(f4, 0, 1);
        WriteLine($"Integral of Log(x)/Sqrt(x) from 0 to 1 should be -4, is: {f4_int}");

        Func<double, double> erf = delegate(double x){
            return 2/Sqrt(PI)*Exp(-(x*x));
        };


        try
        {
            StreamWriter sw = new StreamWriter("erf.txt");
            for(double z=-4; z <= 4; z+=1.0/8){
                sw.WriteLine($"{z} {integrate(erf, 0, z)}");
	        }
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }



    }
}