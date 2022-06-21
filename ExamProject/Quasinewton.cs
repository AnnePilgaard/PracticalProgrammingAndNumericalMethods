using System;
using System.IO;
using static System.Console;
using static System.Math;

public class Quasinewton{


    public static (vector, bool) varMethod(matrix A, double lambda_start){

        int n = A.size1;
        vector x0 = new vector(n + 1);
        for (int i = 0; i < n; i++) {
            x0[i] = 1;
        }

        x0[n] = lambda_start;
        
        Func<vector, vector> f = delegate(vector x){
            vector v = x.copy();
            double lambda = v.pop();

            vector r = A*v-lambda*v;

            r.push(v.dot(v)-1);

            return r;
        };
           
        var resultTuble  = newton(f, A, x0);
        vector result = resultTuble.Item1;
        bool succesfull = resultTuble.Item2;
        

        return (result, succesfull);
    }

    static matrix makeJacobian(matrix A, vector x0){
        // Matrix size
        int n = x0.size; 
        vector v = x0.copy();
        double lambda = v.pop();
        

        // Jacobian matrix
        matrix J = new matrix(n, n);

        // Construct Jacobian matrix
        for (int i=0; i<n; i++){
            for (int j=0; j<n; j++){
                if (i == n-1 && j == n-1){
                   J[i, j] = 0; 
                }
                else if (j == n-1 && i != n-1){
                    J[i, j] = -v[i];
                }
                else if(j != n-1 && i == n-1){
                    J[i, j] = 2*v[j];
                }
                else{
                    if (j == i){
                        J[i, j] = A[i, j] - lambda;
                    }
                    else{
                        J[i, j] = A[i, j];
                    }                   
                }              
            }
        }
        return J;
    }

    static (vector, bool) newton(Func<vector,vector>f, matrix A, vector x0, double eps=1e-2){

        //Initialize values
        bool done = false; 
        bool succesfull = false;
        int numberOfIterations = 0;
        int maxIterations = 10000; 

        matrix J;
        QRGS solver;              
        vector b;
        vector delta_x;
        double lambda;

        while(!done){
             //Make Jacobian
            J = makeJacobian(A, x0);

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
                done = true;
            }
            else if (f(x0).norm() < eps){
                //WriteLine($"Root finding succesfull after {numberOfIterations} iterations");
                done = true;
                succesfull = true;
            }
            //Increase number of iterations
            numberOfIterations++;

        }

        return (x0, succesfull);
    }



}