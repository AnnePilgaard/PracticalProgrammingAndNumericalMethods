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
    

    static void Main(){

        int npoints = 20;
        double rmax = 10;
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

        WriteLine($"Matrix H:");
        printMatrix(H);

        WriteLine("Diagonalizing the matrix using the Jacobi eigenvale algorithm:");
        matrix V;
        matrix D;

        matrix H2 = H.copy();

        (D, V) = jacobi.cyclic(H2);

        WriteLine($"Size of D matrix: {D.size1}, {D.size2}");

        WriteLine($"npoints: {npoints}");

        WriteLine($"D matrix elements along diagonal:");

        for (int i = 0; i < npoints; i++){
            WriteLine($"{matrix.get(D, i, i)}");
        }
        
        WriteLine($"Size of V matrix: {V.size1}, {V.size2}");

        //Print the first eigenfunction
        try{
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("f0.txt");
            //Write text
            for (int i = 0; i < npoints; i++){
                sw.WriteLine($"{r[i]} {matrix.get(D, i, 0)}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
       
        //Print the second eigenfunction
        try{
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("f1.txt");
            //Write text
            for (int i = 0; i < npoints; i++){
                sw.WriteLine($"{r[i]} {matrix.get(D, i, 1)}");
            }
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }


        





        




    }
}