using System;
using static System.Console;
using static System.Math;


public static class main{

    public static void Main() {
        char[] delimiters = {' ','\t','\n'};
                       
        for (string line = ReadLine(); line != null; line = ReadLine()){
            var words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words) {
                double x = double.Parse(word);
                WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
        }    
        
    }
}