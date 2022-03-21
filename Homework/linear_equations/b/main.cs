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

    static vector readVectorFromFile(string filename){
        string[] lines = File.ReadAllLines(filename);  

        int nrows = lines.Length;

        string[] firstRow = lines[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        int ncolumns = firstRow.Length; 

        double[] barray = new double[lines.Length];

        int idx = 0;

        foreach(string line in lines){  
            string[] dataarray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            barray[idx] = double.Parse(dataarray[0]);
            idx++;
        }

        vector b = new vector(barray);
        return b;
    }

    static void printVector(vector b){

        int n = b.size;

        for (int i = 0; i < n; i++){
            WriteLine($"{b[i]}");
        }
        WriteLine("\n");
    }

    
    static void Main(string[] args){

        matrix A = readMatrixFromFile("AmatrixSquare.txt");

        WriteLine($"Matrix A:");
        printMatrix(A);


        QRGS squareQRGS = new QRGS(A);
        matrix Q = squareQRGS.Q;
        matrix R = squareQRGS.R;

        WriteLine($"Matrix Q:");
        printMatrix(Q);

        WriteLine($"Matrix R is upper triangle:");
        printMatrix(R);

        WriteLine("The invsere of A is:");
        matrix B = squareQRGS.inverse();
        printMatrix(B);

        WriteLine("A*B=");
        printMatrix(A*B);

    }
}