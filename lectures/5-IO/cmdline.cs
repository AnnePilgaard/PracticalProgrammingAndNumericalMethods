using System;
using System.IO;
using static System.Console;


class main{

    public static int Main(string[] args){
        foreach(string arg in args){
            Write($"arg=|{arg}|");
            double x = double.Parse(arg);
            WriteLine($"     x = {x}");


        }
        


        return 0;
    }

}