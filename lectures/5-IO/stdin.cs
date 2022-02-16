using System;
using System.IO;
using static System.Console;


class main{

    public static int Main(){
        //WriteLine("This goes to stdout")
        System.Console.Out.WriteLine("This goes to stdout");
        System.Console.Error.WriteLine("This goes to stderr");

        System.IO.TextWriter stdout = System.Console.Out;
        stdout.WriteLine("another stdout");

        string line =System.Console.ReadLine();
        WriteLine("Line = " + line);
        string[] words = line.Split();
        foreach(string word in words){
            WriteLine("word = " + word);
            double x = double.Parse(word);
            WriteLine($"x={x}");
        }


        /*
        System.Console.In.ReadLine();
        var stdin = System.Console.In;
        string s = stdin.ReadLine();
        */


        return 0;
    }

}