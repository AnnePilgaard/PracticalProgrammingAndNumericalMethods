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

        matrix A = readMatrixFromFile("AmatrixTall.txt");


        WriteLine($"Matrix A tall:");
        printMatrix(A);

        QRGS myQRGS = new QRGS(A);
        matrix Q = myQRGS.Q;
        matrix R = myQRGS.R;

        //Testing QR decomposition
        WriteLine($"Matrix Q:");
        printMatrix(Q);

        WriteLine($"Matrix R is upper triangle:");
        printMatrix(R);

        WriteLine($"Q^T*Q is:");
        printMatrix(Q.T*Q);
        WriteLine("Which is really close to 1");

        WriteLine($"Checking if Q*R=A: {A.approx(Q*R)}");

        WriteLine("\n");

        //Solving using back substituition
        matrix Asquare = readMatrixFromFile("AmatrixSquare.txt");

        WriteLine($"Matrix A square:");
        printMatrix(Asquare);

        //Reading b vector file
        vector b = readVectorFromFile("bvector.txt");
        WriteLine("The vector b:");
        printVector(b);

        QRGS squareQRGS = new QRGS(Asquare);
        matrix Q2 = squareQRGS.Q;
        matrix R2 = squareQRGS.R;

        WriteLine($"Matrix Q:");
        printMatrix(Q2);

        WriteLine($"Matrix R is upper triangle:");
        printMatrix(R2);

        vector x = squareQRGS.solve(b);
        WriteLine("The vector x which solves the equation QRx = b is:");
        printVector(x);

        vector temp = Asquare*x;
        WriteLine("A*x:");
        printVector(temp);
        
        WriteLine($"Checking that A*x = b: {vector.approx(Asquare*x, b)}");

        //WriteLine("here:");
        //printVector(Asquare*b);
        

    }
}