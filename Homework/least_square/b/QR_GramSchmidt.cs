using System;
using System.IO;
using static System.Console;
public class QRGS{
	public matrix Q;
    public matrix R;
	public QRGS(matrix A){

        int m = A.size2;

        Q = A.copy(); 
        R = new matrix(m, m);
        for (int i = 0; i < m; i ++){
            R[i , i] = Q[i].norm();
            Q[i] /= R[i, i];
            for ( int j = i + 1; j < m; j ++){
                R[i , j]=Q[i].dot(Q[j]);
                Q[j] -= Q[i] * R[i, j ]; 
            } 
        }


        
    }

	public vector solve(vector b){

        vector newb = Q.T*b;
        
        vector c = newb.copy();

        for (int i = c.size-1; i >= 0; i--){
            double sum = 0;
            for (int k = i + 1; k < c.size; k++){
                sum += R.get(i,k)*c[k];
            }
            c[i] = (c[i]-sum)/R.get(i,i);

        }
        return c;

        }
	public matrix inverse(){

        int ncloumn = R.size1;
        int nrows = Q.size1;
        matrix inverse = new matrix(nrows, ncloumn);
        
        for(int i = 0; i < ncloumn; i++){
            vector unitVector = makeUnitVector(nrows, i);
            vector x = solve(unitVector);
            for(int j = 0; j < x.size; j++){
                matrix.set(inverse, j, i, x[j]);
            }

        }

        return inverse;
    }


    private vector makeUnitVector(int rows, int i){
        double[] array = new double[rows];

        for (int j = 0; j < rows; j++){
            if(j == i ){
                array[j] = 1;
            }
            else{
                array[j] = 0;
            }
        }

        vector v = new vector(array);
        return v;

    }
	//public double determinant(){/* return ΠiRii */}
}