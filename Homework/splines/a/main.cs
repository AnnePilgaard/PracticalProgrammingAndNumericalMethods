using System;
using System.IO;
using static System.Console;
using static System.Math;
using static linearSpline;

public static class main{
    static void Main(string[] args){


        if (args[0] == "spline"){
            string[] lines = File.ReadAllLines("input.txt");  

            double[] xarray = new double[lines.Length];
            double[] yarray = new double[lines.Length];
            int idx = 0;

            foreach(string line in lines){  
                string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                xarray[idx] = double.Parse(dataarray[0]);
                yarray[idx] = double.Parse(dataarray[1]);
                idx++;
            }

            for(double z=xarray[0];z<=xarray[xarray.Length-1];z+=1.0/8){
                double yz = linterp(xarray, yarray, z);
                WriteLine($"{z} {yz}");
            }
        }
        else if (args[0] == "integ_spline"){ 

            string[] lines = File.ReadAllLines("input.txt");  

            double[] xarray = new double[lines.Length];
            double[] yarray = new double[lines.Length];
            int idx = 0;

            foreach(string line in lines){  
                string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                xarray[idx] = double.Parse(dataarray[0]);
                yarray[idx] = double.Parse(dataarray[1]);
                idx++;
            }
          
            double integ3 = linterpInteg(xarray, yarray, 3);
            WriteLine($"The integration of the spline from 0 to 3 is {integ3}");
            double integ5 = linterpInteg(xarray, yarray, 5);
            WriteLine($"The integration of the spline from 0 to 5 is {integ5}");
            double integ9 = linterpInteg(xarray, yarray, 9);
            WriteLine($"The integration of the spline from 0 to 9 is {integ9}");


        }



    }
}