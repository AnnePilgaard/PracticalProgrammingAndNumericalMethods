using System;
using static System.Console;
using static System.Math;


public static class main{

    static double gamma(double x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(x<0)return PI/Sin(PI*x)/gamma(1-x);
        if(x<9)return gamma(x+1)/x;
        double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return Exp(lngamma);
    }

    static double gamma_log(double x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        return Log(Abs(gamma(x)));
    }

    static void Main(string[] args){
        double dx=1.0/64, shift=dx/2;

        if (args[0] == "gamma"){
            for(double x=-5+shift; x<=5; x+=dx)
                WriteLine($"{x} {gamma(x)}");


        }
        else if (args[0] == "log_gamma"){           
            for(double x=-5+shift; x<=5; x+=dx)
                WriteLine($"{x} {gamma_log(x)}");

        }

    }
}