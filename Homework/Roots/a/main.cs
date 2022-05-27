using System;
using System.IO;
using static System.Console;
using static System.Math;


public static class main{

    static matrix makeJacobian(Func<vector, vector> f, vector x0){
        // Matrix size
        int size1 = f(x0).size;
        int size2 = x0.size;

        // Jacobian matrix
        matrix J = new matrix(size1, size2);

        // Step size for finite difference approximation of Jacobian
        double SqrtEpsilon = Pow(2, -26);
        double dx = SqrtEpsilon * Sqrt(x0.dot(x0));

        // x0 + dx
        vector x0dx;

        // Construct Jacobian matrix
        for (int i=0; i<size1; i++){
            for (int j=0; j<size2; j++){
                x0dx = x0.copy();
                x0dx[j] += dx; 
                J[i, j] = (f(x0dx)[i] - f(x0)[i])/dx;
            }
        }
        return J;
    }

    static vector newton(Func<vector,vector>f, vector x0, double eps=1e-2){

        //Initialize values
        bool notDone = true; 
        int numberOfIterations = 0;
        int maxIterations = 10000; 

        matrix J;
        QRGS solver;              
        vector b;
        vector delta_x;
        double lambda;

        while(notDone){
             //Make Jacobian
            J = makeJacobian(f, x0);

            //solve J∆x = −f(x) for ∆x
            solver = new QRGS(J);
            b = -f(x0);
            delta_x = solver.solve(b);

            //Set lambda to 1
            lambda = 1.0;

            //Do back-tracking linesearch
            while((f(x0 + lambda * delta_x).norm() > (1 - lambda/2)*f(x0).norm()) & (lambda >= 1.0/32)){
                lambda = lambda/2;
            }

            //Set x = x + λ∆x
            x0 = x0 + lambda * delta_x;

            //Check if we are done
            if (numberOfIterations > maxIterations){
                WriteLine($"Root finding failed, exceed max iterations of {maxIterations}");
                notDone = false;
            }
            else if (f(x0).norm() < eps){
                WriteLine($"Root finding succesfull after {numberOfIterations} iterations");
                notDone = false;
            }
            //Increase number of iterations
            numberOfIterations++;

        }

        return x0;
    }


    static void Main(){


        //Partial derivativesof Rosenbrock's valley function
        Func<vector, vector> f = delegate(vector v){
            double x = v[0];
            double y = v[1];

            return new vector(-2 + 2*x - 400*y*x + 400*x*x*x, 200*y - 200*x*x);
        };


        //starting point
        vector x0 = new vector(2,2);

        vector result = newton(f, x0);
        WriteLine($"The roots of the partial derivatives to the Rosenbrock's valley function are");
        WriteLine($"{result[0]}, {result[1]}");

        WriteLine("The values of the function at this point is");
        WriteLine($"{f(result)[0]}, {f(result)[1]}");


    }
}