using System;
using static System.Console;
using static System.Math;


public static class main{
    static void Main(){
        for (int k=1;k<=3;k++){
            /**
            var test = (double x) => {
                return Sin(k*x);
            };
            **/

            Func<double, double> mySin = delegate(double x){
                return Sin(k*x);
            };
            table.make_table(mySin, -3.0, 3.0, 0.1);
        }
    }
}