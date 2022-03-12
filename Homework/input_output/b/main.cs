using System;
using static System.Console;
using static System.Math;


public static class main{

    public static void Main(string[] args){
        foreach(var arg in args){
            double x = double.Parse(arg);
            WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
    }
}