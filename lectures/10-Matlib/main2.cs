using System;
using static System.Console;
using static System.Math;


public static class main{

    


    public static async double sin(double x){

        Func<double, vector, vector> F = delegate(double t, vector y){
            double dydt0 = y[1];
            double dydt1=-y[0];
            return new vector(dydt0, dydt1);
    };

        double a = 0;
        double b = 0;
        vector ya = new vector(0,1);
        ode.ivp(F, a, ref ya, b);
        return ya[0];

    }
    


    static void Main(){
        for (double x=0;x<=6;x+=1.0/8){
            WriteLine($"{x} {sin(x)}");
        }
    }

}