using System;
using System.IO;
using static System.Console;
using static System.Math;


public static class main{
    static void Main(){

        double b = 0.25;
        double c = 5.0;
        Func<double, vector, vector> pend = delegate(double x, vector y){
            return new vector(y[1],-b*y[1] - c* Sin(y[0]));
        };

        double start = 0.0;
        double end = 10.0;
        vector ya=new vector(PI-0.1,0.0);


        var sol = ODE.driver(pend, start, ya, end);

        var xlist = sol.Item1; 
        var ylist = sol.Item2;
       
        try
        {
            StreamWriter sw = new StreamWriter("pendODE.txt");
            for(int i = 0; i < ylist.size; i++){
                sw.WriteLine($"{xlist.data[i]} {ylist.data[i][0]} {ylist.data[i][1]}");
            }
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }



    }
}