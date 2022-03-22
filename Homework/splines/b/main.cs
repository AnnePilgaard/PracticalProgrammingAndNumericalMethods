using System;
using System.IO;
using static System.Console;
using static System.Math;

public static class main{
    static void Main(string[] args){

        string[] lines = File.ReadAllLines("input1.txt");  

        double[] xarray = new double[lines.Length];
        double[] yarray = new double[lines.Length];
        int idx = 0;

        foreach(string line in lines){  
            string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            xarray[idx] = double.Parse(dataarray[0]);
            yarray[idx] = double.Parse(dataarray[1]);
            idx++;
        }


       
        qspline qSpline1 = new qspline(xarray, yarray);

        
        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("qspline1.txt");
            //Write text
            for(double z = xarray[0]; z <= xarray[xarray.Length-1]; z += 1.0/8){
                double yz = qSpline1.spline(z);
                sw.WriteLine($"{z} {yz}");
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
            StreamWriter sw = new StreamWriter("qsplineDer.txt");
            //Write text
            for(double z = xarray[0]; z <= xarray[xarray.Length-1]; z += 1.0/8){
                double yz = qSpline1.derivative(z);
                sw.WriteLine($"{z} {yz}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }


        double integ3 = qSpline1.integral(3.0);
        WriteLine($"The integration of the spline from 0 to 3 is {integ3}");
        double integ5 = qSpline1.integral(5.0);
        WriteLine($"The integration of the spline from 0 to 5 is {integ5}");
        double integ8 = qSpline1.integral(8.0);
        WriteLine($"The integration of the spline from 0 to 8 is {integ8}");
        


    }
}