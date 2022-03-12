using System;
using static System.Console;
using static System.Math;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;


public static class main{

    public static void MakeMySum(double[] results, int index, int a, int b){
        double mySum = 0;
        for (int i = a; i < b; i++) {
            mySum += 1.0/i;
        }
        results[index] = mySum;
    }

    public static void Main(string[] args){
        var a = int.Parse(args[0]);
        var b = int.Parse(args[1]);
        int numberOfThreads = (int) Ceiling((b-a)/10.0);       
        double[] results = new double[numberOfThreads];

        int resultsIndex = 0;
        List<Thread> threads = new List<Thread>();

        for (int i = a; i < b; i += 10) {
            var closureResultsIndex = resultsIndex;
            var closureI = i;
            Thread thread = new Thread(() => MakeMySum(results, closureResultsIndex, closureI, Min(closureI+10,b+1)));
            thread.Start();
            threads.Add(thread);
            resultsIndex++;
        }

        foreach (var thread in threads){
            thread.Join();
        }

        double finalResult = 0;
        
        foreach (double result in results){
            WriteLine(result);
            finalResult += result;
        }

        WriteLine($"The sum of 1/i from {a} to {b} is being calculated using {numberOfThreads} threads");

        double mySumCheck = 0;
        for (int i = a; i < b+1; i++) {
            mySumCheck += 1.0/i;
        }

        WriteLine($"The final results is: {finalResult} and should be {mySumCheck}");


    }
}