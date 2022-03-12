using System;
using static System.Console;
using static System.Math;


public static class main{
    static void Main(){

        var list = new genlist<double[]>();
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;

        for(string line = ReadLine(); line!=null; line = ReadLine()){
            var words = line.Split(delimiters,options);
            int n = words.Length;
            var numbers = new double[n];
            //Here the numbers are pushed into the genlist
            for(int i=0;i<n;i++){ 
                numbers[i] = double.Parse(words[i]);
            }
            list.push(numbers);
            }
        //Here the numbers in the genlist is written out  
        WriteLine("The list:"); 
        for(int i=0;i<list.size;i++){
            var numbers = list.data[i];
            foreach(var number in numbers)Write($"{number:e} ");
            WriteLine("");
        }
        WriteLine($"The size of the list is {list.size}");

        //Here item number 2 is removed
        list.remove(2);
        WriteLine("The list now that item number 2 has been removed");
        for(int i=0;i<list.size;i++){
            var numbers = list.data[i];
            foreach(var number in numbers)Write($"{number:e} ");
            WriteLine("");
        }
        WriteLine($"The size of the list is {list.size}");
        





    }
}