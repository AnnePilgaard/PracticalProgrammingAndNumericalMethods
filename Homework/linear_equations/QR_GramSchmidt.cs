
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
	//public matrix inverse(){/* return the inverse matrix (part B) */}
	//public double determinant(){/* return ΠiRii */}
}