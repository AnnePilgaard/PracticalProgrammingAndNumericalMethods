using System;
using System.IO;
using static System.Console;
using static System.Math;

public static class main{

    static void printMatrix(matrix A){

        int n = A.size1;
        int m = A.size2;

        for (int i = 0; i < n; i++){
            for (int j = 0; j <m; j++){
                Write($"{A.get(i,j)} ");
            }
            Write("\n");

        }
        WriteLine("\n");

    }

    static (matrix, vector, double) generateHamiltonian(int npoints, double rmax){

        double dr = rmax / (npoints+1);
        vector r = new vector(npoints);
        for(int i = 0; i < npoints; i++){
            r[i] = dr * (i+1);
        }
        matrix H = new matrix(npoints, npoints);
        for(int i  = 0; i < npoints-1; i++){
            matrix.set(H, i, i, -2);
            matrix.set(H, i, i+1, 1);
            matrix.set(H, i+1, i, 1);
        }
        matrix.set(H, npoints-1, npoints-1, -2);
        H *= -0.5 / (dr*dr);
        for(int i = 0; i < npoints; i++){
            H[i,i] += -1/r[i];
        }
        return (H, r, dr);
    }
    

    static void Main(){

        //Creating the hamiltonian and diagonalizing it with the Jacobi routine
        var tub1 = generateHamiltonian(20, 10);
        matrix H = tub1.Item1;

        WriteLine($"Matrix H:");
        printMatrix(H);

        WriteLine("Diagonalizing the matrix using the Jacobi eigenvale algorithm:");
        matrix V;
        matrix D;

        matrix H2 = H.copy();

        (D, V) = jacobi.cyclic(H2);

        //Investigate the convergence with respect to rmax
        WriteLine("Investigating the convergence with respect to rmax, see rmax_convergence.pdf");       
        try{
            StreamWriter sw = new StreamWriter("rmax_convergence.txt");
            for (double r = 1; r < 20; r+=0.2){
                var tub2 = generateHamiltonian(50, r);
                matrix H3 = tub2.Item1;
                (D, V) = jacobi.cyclic(H3);
                sw.WriteLine($"{r} {matrix.get(D, 0, 0)} {-0.5} {matrix.get(D, 1, 1)} {-0.125} {matrix.get(D, 2, 2)} {-0.055}");
            }
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        
        //Investigate the convergence with respect to npoints
        WriteLine("Investigating the convergence with respect to npoints, see npoints_convergence.pdf");
        try{
            StreamWriter sw = new StreamWriter("npoints_convergence.txt");
            for (int n = 10; n < 150; n+=5){
                var tub2 = generateHamiltonian(n, 20);
                matrix H3 = tub2.Item1;
                (D, V) = jacobi.cyclic(H3);
                sw.WriteLine($"{n} {matrix.get(D, 0, 0)} {-0.5} {matrix.get(D, 1, 1)} {-0.125} {matrix.get(D, 2, 2)} {-0.055}");
            }
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        
        
   
        //Need to plot eigenfunctions
        
        Func<double, double> analyticalSolution0 = (double x) => 2*Exp(-x);
        Func<double, double> analyticalSolution1 = (double x) => -1.0/Sqrt(2)*(1-1.0/2*x)*Exp(-x/2);
        Func<double, double> analyticalSolution2 = (double x) =>  2.0/(3.0*Sqrt(3.0))*(1-2.0/3.0*x+2.0/27.0*x*x)*Exp(-x/3.0);
        

        var tub4 = generateHamiltonian(300, 35);
        matrix H4 = tub4.Item1;
        vector r4 = tub4.Item2;
        double dr = tub4.Item3;
        (D, V) = jacobi.cyclic(H4);

        try{
            StreamWriter sw = new StreamWriter("eigenfunctions.txt");           
            for (int i = 0; i < V.size1; i++){
                sw.WriteLine($"{r4[i]} {V[0][i]/Sqrt(dr)} {r4[i]*analyticalSolution0(r4[i])} {V[1][i]/Sqrt(dr)} {r4[i]*analyticalSolution1(r4[i])} {-V[2][i]/Sqrt(dr)} {r4[i]*analyticalSolution2(r4[i])}");
            }              
                       
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }








        




    }
}