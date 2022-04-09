using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

public static class ODE{
 
    public static (vector,vector) rkstep12(Func<double,vector,vector> f, double x, vector y, double h){ 
        vector k0 = f(x,y); /* embedded lower order formula (Euler) */
        vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
        vector yh = y+k1*h;     /* y(x+h) estimate */
        vector er = (k1-k0)*h;  /* error estimate */
	    return (yh,er);
    }

    public static (genlist<double>, genlist<vector>) driver(Func<double,vector,vector> F, double a, vector ya,  double b, double h=0.01, double acc=0.01,  double eps=0.01 ){
        if  (a>b){
            throw new Exception("driver: a>b");
        }
        //Initialize some lists
        var xlist = new genlist<double>(); 
        var ylist = new genlist<vector>();
        xlist.push(a);
        ylist.push(ya);

        double x = a; 
        vector y = ya;
        do{
            if(x >= b){
                return (xlist, ylist); /* job done */
            } 
            if(x + h > b){
                h = b - x;   /* last step should end at b */
            }
            var (yh,erv) = rkstep12(F,x,y,h);

            vector tol = new vector(erv.size);
           
            bool ok = true;
            for(int i = 0; i < tol.size; i++){
                tol[i] = Max(acc,Abs(yh[i])*eps)*Sqrt(h/(b-a));
                ok = (ok && erv[i] < tol[i]);
                if( ok == false){
                    break;
                }
            }
            if(ok){ 
                x += h; 
                y = yh; 
                xlist.push(x);
                ylist.push(y);

            } // accept the step
            double factor = tol[0]/Abs(erv[0]);
            for(int i=1;i<tol.size;i++){
                factor=Min(factor,tol[i]/Abs(erv[i]));
            } 
            h *= Min( Pow(factor,0.25)*0.95 ,2); // reajust stepsize
        }while(true);
}



}

