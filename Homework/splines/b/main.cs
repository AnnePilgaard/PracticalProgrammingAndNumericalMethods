using System;
using System.IO;
using static System.Console;
using static System.Math;
using qSpline;
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

        qspline qSpline1 = qspline(xarray, y);


    }
}