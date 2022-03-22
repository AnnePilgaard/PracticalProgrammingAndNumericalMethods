using System;
using System.IO;
using static System.Console;
using static System.Math;

public static class main{


    static (vector, vector, vector) readData(string filename){

        string[] lines = File.ReadAllLines(filename);  

        int nrows = lines.Length;

        string[] firstRow = lines[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        int ncolumns = firstRow.Length; 

        vector x = new vector(nrows);
        vector y = new vector(nrows);
        vector dy = new vector(nrows);

        int idx = 0;
 

        foreach(string line in lines){  
            string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            x[idx] = double.Parse(dataarray[0]);
            y[idx] = double.Parse(dataarray[1]);
            dy[idx] = double.Parse(dataarray[2]);
            idx++;

        }

        return (x, y, dy);
    }


    static void printVector(vector b){

        int n = b.size;

        for (int i = 0; i < n; i++){
            WriteLine($"{b[i]}");
        }
        WriteLine("\n");
    }
    

    static (vector, matrix) lsfit(Func<double, double>[] fs, vector x, vector y, vector dy){

        int n = x.size;
        int m = fs.Length;

        matrix A = new matrix(n, m);
        vector b = new vector(n);

        for(int i = 0; i < n; i++){
            b[i] = y[i] / dy[i];
            for(int k = 0; k < m; k++){
                A[i,k] = fs[k](x[i]) / dy[i];
            }
        }
        var qra = new QRGS(A);
        vector c = qra.solve(b);

        var qraTemp = new QRGS(qra.R);
        matrix invR = qraTemp.inverse();
        var S = invR*invR.T;
        
        return (c, S);
    }

    static void Main(){

        
        var dataVectors = readData("data.txt");
        vector x = dataVectors.Item1;
        vector y = dataVectors.Item2;
        vector dy = dataVectors.Item3;

        //printVector(x);
        //printVector(y);
        //printVector(dy);

        var fs = new Func<double,double>[] { z => 1.0, z => z};

        vector logY = new vector(y.size);
        vector logdY = new vector(y.size);

        for (int i = 0; i < y.size; i++){
            logY[i] = Log(y[i]);
            logdY[i] = Log(dy[i]);
        }

        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("dataLog.txt");
            //Write text
            for(int j = 0; j < y.size; j++){
                sw.WriteLine($"{x[j]} {logY[j]} {logdY[j]}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }


        var fitTuple = lsfit(fs, x,logY, logdY);

        vector c = fitTuple.Item1;
        matrix S = fitTuple.Item2;

        //printVector(c);

        double c0 = c[0];
        double c1 = c[1];

        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("fitPlot.txt");
            //Write text
            for(double z = 0; z <= 15 ;z+=1.0/8){
                double yfit =  c0 + c1*z;
                sw.WriteLine($"{z} {yfit}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        double half_life = Log(2)/Abs(c1);
        double half_life_ush = (Log(2) / ( Abs(c1)*Abs(c1))*Sqrt(S[1,1]) );
        WriteLine(Sqrt(S[1,1]));

        WriteLine($"Decay constant from fit: {Round(Abs(c1),2)} +/- {Round(Sqrt(S[1,1]),2)} [1/days]");
        WriteLine($"The half life of ThX from the fit is {Round(half_life, 2)}+/- {Round(half_life_ush,2)} days, while the half-life of 224Ra from Google is 3.6 days, so the fit value with error is not within the modern value. ");
        
        double c0_ush = Sqrt(S[0,0]);
        double c1_ush = Sqrt(S[1,1]);


        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("fitError1.txt");
            //Write text
            for(double z = 0; z <= 15 ;z+=1.0/8){
                double yfit =  (c0-c0_ush) + (c1-c1_ush)*z;
                sw.WriteLine($"{z} {yfit}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("fitError2.txt");
            //Write text
            for(double z = 0; z <= 15 ;z+=1.0/8){
                double yfit =  (c0+c0_ush) + (c1+c1_ush)*z;
                sw.WriteLine($"{z} {yfit}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("fitError3.txt");
            //Write text
            for(double z = 0; z <= 15 ;z+=1.0/8){
                double yfit =  (c0-c0_ush) + (c1+c1_ush)*z;
                sw.WriteLine($"{z} {yfit}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("fitError4.txt");
            //Write text
            for(double z = 0; z <= 15 ;z+=1.0/8){
                double yfit =  (c0+c0_ush) + (c1-c1_ush)*z;
                sw.WriteLine($"{z} {yfit}");
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