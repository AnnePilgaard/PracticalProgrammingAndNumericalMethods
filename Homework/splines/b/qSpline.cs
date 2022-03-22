using System;
using static System.Console;
using static System.Math;


public class qspline {
	public readonly double[] x,y,b,c;
	public qspline(double[] xs,double[] ys){
		int n = xs.Length;

		x = xs;
		y = ys;
		b = new double[n-1];
		c = new double[n-1];

		double[] h = new double[n-1];
		double[] p = new double[n-1];

		//Create h = x[i+1] - x[i] and p = (y[i+1] - y[i])/h[i] arrays
		for( int i = 0; i < n-1; i++){
			h[i] = x[i+1] - x[i];
			p[i] = (y[i+1] - y[i])/h[i];
		}

		//Forward recursion
		c[0] = 0;
		for (int i = 0; i < n-2; i++){
			c[i+1] = (p[i+1] - p[i] - c[i]*h[i])/h[i+1];
		}

		//Backward recursion
		c[n-2] = c[n-2]/2;
		for (int i = n-3; i >= 0; i--){
			c[i] = (p[i+1] - p[i] - c[i+1]*h[i+1])/h[i];
		}

		//Set bs
		for (int i = 0; i < n-1; i++){
			b[i] = p[i] - c[i]*h[i];
		}

		}
	public double spline(double z){
		int i=binsearch(x,z);
		return y[i]+b[i]*(z-x[i])+c[i]*(z-x[i])*(z-x[i]);
		}

	public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
	}
	public double derivative(double z){
		int i=binsearch(x,z);
		return b[i] + 2*c[i]*(z-x[i]);
		
		}
	public double integral(double z){
		int i=binsearch(x,z);
		double integSum  = 0;

		//Do the inegration in every interval before the interval in which z is located 
		for (int j = 0; j < i; j++){

			double integ = y[i]*(x[i+1]-x[i]) + 1/2*b[i]*(x[i+1]*x[i+1]-x[i]*x[i]) - b[i]*x[i]*(x[i+1]-x[i]) 
							+ 1/3*c[i]*(x[i+1]*x[i+1]*x[i+1]-x[i]*x[i]*x[i]) -c[i]*(x[i+1]*x[i+1]-x[i]*x[i])*x[i]
							+ c[i]*x[i]*x[i]*(x[i+1]-x[i]);
			integSum += integ;
		}
	
		double integFinal = y[i]*(z-x[i]) + 1/2*b[i]*(z*z-x[i]*x[i]) - b[i]*x[i]*(z-x[i]) 
							+ 1/3*c[i]*(z*z*z-x[i]*x[i]*x[i]) -c[i]*(z*z-x[i]*x[i])*x[i]
							+ c[i]*x[i]*x[i]*(z-x[i]);
		integSum += integFinal;

		return integSum;

		}

}