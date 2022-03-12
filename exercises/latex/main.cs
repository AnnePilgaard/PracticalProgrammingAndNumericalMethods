using System;
using static System.Console;
using static System.Math;


public static class main{

    static double ex_approx(double x){
        if(x<0)return 1/ex_approx(-x);
        if(x>1.0/8)return Pow(ex_approx(x/2),2); // explain this
        return 1+x*(1+x/2*(1+x/3*(1+x/4*(1+x/5*(1+x/6*(1+x/7*(1+x/8*(1+x/9*(1+x/10)))))))));
    }

    static void Main(string[] args){

        double dx=1.0/64, shift=dx/2;

        if (args[0] == "approx"){
            for(double x=-5+shift; x<=5; x+=dx)
                WriteLine($"{x} {ex_approx(x)}");


        }
        else if (args[0] == "real"){           
            for(double x=-5+shift; x<=5; x+=dx)
                WriteLine($"{x} {Exp(x)}");

        }


    }
}