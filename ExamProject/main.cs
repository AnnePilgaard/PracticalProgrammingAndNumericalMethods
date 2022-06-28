using System;
using System.IO;
using static System.Console;
using static System.Math;
using System.Diagnostics;
using System.Threading;

public static class main{

    
    static matrix readMatrixFromFile(string filename){

        string[] lines = File.ReadAllLines(filename);  

        int nrows = lines.Length;

        string[] firstRow = lines[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        int ncolumns = firstRow.Length; 

        matrix A = new matrix(nrows, ncolumns);

        int rowIdx = 0;
        int columnIdx = 0;

        foreach(string line in lines){  
            string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in dataarray){

                matrix.set(A, rowIdx, columnIdx, double.Parse(element) );

                columnIdx++;
            }
            columnIdx = 0;
            rowIdx++;

        }

        return A;

    }

    static (vector, bool, int) getTimeForCalculation(matrix A){

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        var resultTuble = Quasinewton.varMethod(A, 1.0);
        vector result = resultTuble.Item1;
        bool succesfull = resultTuble.Item2;
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;
        int time = ts.Milliseconds;

        return (result, succesfull, time);

    }

    static matrix generateRandomSymMAtrix(int size){

        matrix M = new matrix(size, size);
        Random rnd = new Random();

        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                if(j>i){continue;}
                else if(i == j){
                    M[i, j] =  rnd.Next(99);
                }
                else{
                    M[i, j] =  rnd.Next(99);
                    M[j, i] = M[i, j];

                }
                
            }

        }


        return M;
    }

    static double getAverageTime(int size){
        int numberOfIterations = 50;
        int[] timeArray = new int[numberOfIterations];
        int numberOfSuccesfull = 0;

        for(int n = 0; n < numberOfIterations; n++){
            matrix m = generateRandomSymMAtrix(size);
            var resultTuble = getTimeForCalculation(m);
            bool succesfull = resultTuble.Item2;
            if(succesfull){
                timeArray[numberOfSuccesfull] = resultTuble.Item3;
            }
            numberOfSuccesfull++;

        }

        int sum = 0;
        for (int i = 0; i < timeArray.Length; i++)
        {
            sum += timeArray[i];
        }
        double averageTime = sum/numberOfSuccesfull;

        return averageTime; //in milliseconds

    }


    static void Main(){

        WriteLine("This is project 22 about Variational method with Lagrange multipliers");

        //Do simple test with a small easy matrix
        matrix simpleA = readMatrixFromFile("simpleA.txt");
        WriteLine($"We start with a small input test matrix:");
        simpleA.print();
        WriteLine("The lowest eigenvalue should be 7.179 with the normalized eigenvector (0.522, 0.674, 0.522)");
        
        double lambda_start = 7.0;

        var resultTuble0 = Quasinewton.varMethod(simpleA, lambda_start);
        vector result = resultTuble0.Item1;
        double lambda = result.pop();
        vector v = result.copy();

        WriteLine($"The lowest calucalted eigenvalue is {lambda} with the eigenvector ({v[0]}, {v[1]}, {v[2]}) ");
        
        //Investigate the scaling
        WriteLine("");
        WriteLine("Now we investigate the scaling of the method");
        
        /**
        int[] Narray = new int[16];
        double[] timeArray = new double[16];
        int N = 20;

        for(int i = 0; i < 16; i++){
            Narray[i] = N;
            timeArray[i] = getAverageTime(N);
            N=+5;

        }
        **/

        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("scaling.txt");
            //Write text
            int N = 25;

            for(int i = 0; i < 7; i++){
                sw.WriteLine($"{N} {getAverageTime(N)}");
                N+=25;
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }


        


    }
}