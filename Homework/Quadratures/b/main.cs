using System;
using System.IO;
using static System.Console;
using static System.Math;


public static class main{

    static int numberOfInterations = 0;

    static double integrate(Func<double,double> f, double a, double b, 
                            double delta = 0.001, double eps = 0.001, double f2 = double.NaN, double f3 = double.NaN){
    double h = b-a;
    
    if(double.IsNaN(f2)){ 
        numberOfInterations = 0;
        f2=f(a+2*h/6); f3=f(a+4*h/6); // first call, no points to reuse
    } 
    numberOfInterations++;
    double f1 = f(a+h/6);
    double f4 = f(a+5*h/6);
    double Q = (2*f1+f2+f3+2*f4) / 6*(b-a); // higher order rule
    double q = (  f1+f2+f3+  f4) / 4*(b-a); // lower order rule
    double err = Abs(Q-q);
    if (err <= delta+eps*Abs(Q)){
         return Q;
    }
    else return integrate(f, a, (a+b)/2, delta/Sqrt(2), eps, f1, f2) + integrate(f, (a+b)/2, b, delta/Sqrt(2), eps, f3, f4);
    }

    static double integrateCC(Func<double,double> f, double a, double b, 
                            double delta = 0.001, double eps = 0.001, double f2 = double.NaN, double f3 = double.NaN){

        Func<double, double> f_CC = delegate(double theta){
            return f((a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2;
        };

        return integrate(f_CC, 0, PI);

    }

    static void Main(){

        Func<double, double> f2 = delegate(double x){
            return 1/Sqrt(x);
        };

        double f2_int = integrate(f2, 0, 1);
        WriteLine($"Integral of 1/Sqrt(x) from 0 to 1 should be 2, is: {f2_int} and it took {numberOfInterations} iterations");
        double f2_intCC = integrateCC(f2, 0, 1);
        WriteLine($"Same integral now by Clenshaw–Curtis variable transformation: {f2_intCC} and it took {numberOfInterations} iterations");
 

        Func<double, double> f4 = delegate(double x){
            return Log(x)/Sqrt(x);
        };

        double f4_int = integrate(f4, 0, 1);
        WriteLine($"Integral of Log(x)/Sqrt(x) from 0 to 1 should be -4, is: {f4_int} and it took {numberOfInterations} iterations");
        double f4_intCC = integrateCC(f4, 0, 1);
        WriteLine($"Same integral now by Clenshaw–Curtis variable transformation: {f4_intCC} and it took {numberOfInterations} iterations");
 


    }
}