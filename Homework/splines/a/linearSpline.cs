using System;
using static System.Console;
using static System.Math;


public static class linearSpline{

    public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
	}

    public static double linterp(double[] x, double[] y, double z){
        int i=binsearch(x,z);
        double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
        }

    public static double linterpInteg(double[] x, double[] y, double z){

        double integSum  = 0;
        int n=binsearch(x,z);

        for(int i = 0; i < n; i++){
            double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
            double dy=y[i+1]-y[i];
            double integ = y[i]*(x[i+1]-x[i]) + 1/2*dy/dx*(x[i+1]*x[i+1]- x[i]*x[i]);
            integSum += integ;

        }

        double dxi=x[n+1]-x[n]; if(!(dxi>0)) throw new Exception("uups...");
        double dyi=y[n+1]-y[n];
        double integFinal = y[n]*(z-x[n]) + 1/2*dyi/dxi*(z*z- x[n]*x[n]);
        integSum += integFinal;


        return integSum;
    }


}