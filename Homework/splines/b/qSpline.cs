using System;
using static System.Console;
using static System.Math;


public class qspline {
	double[] x,y,b,c;
	public qspline(double[] xs,double[] ys){

		int n  = xs.GetLength(0);

		double[] bs = new double[n];
		double[] cs = new double[n];

		
		//Forward recursion: initial assumption
		double dxi0 = x[1] - x[0];
		double dyi0 = y[1] - y[0];
		bs[0] = dyi0/dxi0;

		cs[0] = 0;

		//Forward resurcion loop:
		for(int i = 1; i < n; i++){
			double dxi = xs[i+1] - xs[i];
			double dyi = ys[i+1] - ys[i];
			bs[i] = dyi/dxi;

			double dbi_1 = b[i-1]-b[i];
			double dxi_1 = xs[i-1] -xs[i];

			cs[i] = (-dbi_1 +  cs[i-1] + dxi_1)/dxi;
		}

		//Backward rescursion

		
		double[] bs2 = new double[n];
		double[] cs2 = new double[n];

		cs2[n-1] = 0.5*cs[n-1];
		bs2[n-1] = xs[n-1] - xs[n-2];


		for(int i = n-2; i > n; i--){
			double dxi = xs[i+1] - xs[i];
			double dyi = ys[i+1] - ys[i];
			bs2[i] = dyi/dxi;

			double dbi = b[i+1]-b[i];
			double dxi_1 = xs[i+2] -xs[i+1];

			cs2[i] = (dbi - cs[i+1] + dxi_1)/dxi;
		}

		x = xs;
		y = ys;
		b = bs2;
		c = cs2;
		}
	//public double spline(double z){/* evaluate the spline */}
	//public double derivative(double z){/* evaluate the derivative */}
	//public double integral(double z){/* evaluate the integral */}

}