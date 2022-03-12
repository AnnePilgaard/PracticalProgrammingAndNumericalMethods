using System;
using static System.Console;
using static System.Math;


public static class main{

    static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
        bool check = false; 
        if (Abs(a-b)<tau){
            check = true;
        }
        else if ((Abs(a-b)/(Abs(a)+Abs(b)))<epsilon){
            check = true;
        }
        return check;
    }

    static void Main(){
        //----------1
        WriteLine("---1---");
        int i=1; 
        while (i+1 > i) {
            i++;
        }
        Write("my max int is {0}\n",i);

        Write($"the system max in is {int.MaxValue}\n");

        if(i == int.MaxValue){
            Write("They are the same\n");
        }
        else{
            Write("They are not the same\n");
        }

        int j=1; while(j-1<j) {j--;}
        Write("my min int is {0}\n",j);

        Write($"the system min in is {int.MinValue}\n");

        if(j == int.MinValue){
            Write("They are the same\n");
        }
        else{
            Write("They are not the same\n");
        }


        //----------2
        WriteLine("---2---");
        double x=1; while(1+x!=1){x/=2;} x*=2;
        Write($"my double machine epsilon is {x} \n");
        Write($"The system double machine epsilon should be {System.Math.Pow(2,-52)} \n");


        float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
        Write($"my float machine epsilon is {y} \n");
        Write($"The system float machine epsilon should be {System.Math.Pow(2,-23)} \n");

        //----------3
        WriteLine("---3---");
        int n = (int)1e6;
        double epsilon = Pow(2,-52);
        double tiny = epsilon / 2;
        double sumA = 0;
        double sumB = 0;

        sumA += 1;
        for (int k = 0; k < n; k++) {
            sumA += tiny;
        }
        WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");

        for (int l = 0; l < n; l++) {
            sumB += tiny;
        } 
        sumB += 1;
        WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");


        //----------4
        WriteLine("---4---");
        double a = 2E-16;
        double b = 3E-16; 
        Write($"a = {a} and b = {b} are approximately equal: approx(a,b) = {approx(a,b)} \n");
        double c = 2E-16;
        double d = 1; 
        Write($"while c = {c} and d = {d} are not approximately equal: approx(c,d) = {approx(c,d)} \n");
        
    }


}