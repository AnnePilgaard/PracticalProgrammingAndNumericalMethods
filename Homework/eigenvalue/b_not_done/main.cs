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

    static matrix generateHamiltonian(int npoints, double rmax){

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
        return H;
    }
    

    static void Main(){

        //Creating the hamiltonian and diagonalizing it with the Jacobi routine
        matrix H = generateHamiltonian(20, 10);

        WriteLine($"Matrix H:");
        printMatrix(H);

        WriteLine("Diagonalizing the matrix using the Jacobi eigenvale algorithm:");
        matrix V;
        matrix D;

        matrix H2 = H.copy();

        (D, V) = jacobi.cyclic(H2);

        

        //Investigate the convergence with respect to rmax
        try{
            StreamWriter sw = new StreamWriter("rmax_convergence.txt");
            for (double r = 1; r < 20; r+=0.2){
                matrix H3 = generateHamiltonian(20, r);
                (D, V) = jacobi.cyclic(H3);
                sw.WriteLine($"{r} {matrix.get(D, 0, 0)} {matrix.get(D, 1, 1)} {matrix.get(D, 2, 2)}");
            }
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        
        //Investigate the convergence with respect to npoints
        try{
            StreamWriter sw = new StreamWriter("npoints_convergence.txt");
            for (int n = 10; n < 150; n+=5){
                matrix H3 = generateHamiltonian(n, 20);
                (D, V) = jacobi.cyclic(H3);
                sw.WriteLine($"{n} {matrix.get(D, 0, 0)} {matrix.get(D, 1, 1)} {matrix.get(D, 2, 2)}");
            }
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        
        

        //Need to add analystical energies to convergence inversitagtions {-0.5, -0.125, -0.055}
    
        //Need to plot eigenfunctions







        




    }
}