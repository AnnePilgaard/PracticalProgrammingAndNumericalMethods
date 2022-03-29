using System;
using System.IO;
using static System.Console;
using static System.Math;

public static class main{


    static matrix readMatrixFromFile(string filename){

        string[] lines = File.ReadAllLines(filename);  

        int nrows = lines.Length;

        string[] firstRow = lines[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        int ncolumns = firstRow.Length; 

        matrix A = new matrix(nrows, ncolumns);

        int rowIdx = 0;
        int columnIdx = 0;

        foreach(string line in lines){  
            string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in dataarray){

                matrix.set(A, rowIdx, columnIdx, double.Parse(element) );

                columnIdx++;
            }
            columnIdx = 0;
            rowIdx++;

        }

        return A;

    }

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

        matrix A = readMatrixFromFile("Amatrix.txt");

        WriteLine($"Matrix A:");
        printMatrix(A);


        WriteLine("Doing eigenvalue decomposition:");
        matrix V;
        matrix D;

        matrix A2 = A.copy();

        (D, V) = jacobi.cyclic(A2);

        WriteLine($"Matrix D:");
        printMatrix(D);

        WriteLine($"Matrix V:");
        printMatrix(V);

        matrix test1 = matrix.id(V.size1);

        WriteLine($"Testing if V.T*V == 1: {test1.approx(V.T*V)}");
        WriteLine($"Testing if V*V.T == 1: {test1.approx(V*V.T)}");

        WriteLine($"Testing if V.T*A*V == D: {D.approx(V.T*A*V)}");
        WriteLine($"Testing if V*D*V.T == A: {A.approx(V*D*V.T)}");



        





        




    }
}