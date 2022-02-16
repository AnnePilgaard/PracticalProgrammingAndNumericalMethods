using System;
using static System.Console;
using static System.Math;

class main{
        static void Main(){
            int n = 9;
            double[] a = new double[n];
            a[0] = 7;
            Write($"a[0]={a[0]}");
            for(int i = 0; i < n; i++){
                a[i] = i;
            }
            for(int i = 0; i < n; i++){
                WriteLine($"a[{i}]={a[i]}");
            }

            int m = n;
            m = 0;
            WriteLine($"m={m}, n= ...{n}");

            double[] b = a;
            b[0] = 999;
            WriteLine($"b[0]={b[0]}, a[0]=...{a[0]}");

            foreach(double ai in a) WriteLine($"ai={ai}");

        }

}

