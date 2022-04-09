using System;
using System.IO;
using static System.Console;
using static System.Math;



public static class main{

    static Random random = new Random();
    static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
        int dim = a.size; 
        double V = 1; 
        for(int i = 0; i < dim; i++){
            V *= b[i] - a[i];
        }
        double sum = 0;
        double sum2 = 0;
	    var x = new vector(dim);
        for(int i = 0; i < N; i++){
            for(int k = 0; k < dim; k++){
                var rnd = random.NextDouble();
                x[k] = a[k] + rnd*(b[k] - a[k]);
                //WriteLine($"my random: {rnd}");
            }
            double fx = f(x); 
            sum += fx; 
            sum2 += fx * fx;
            }
        double mean = sum / N;
        double sigma = Sqrt(sum2/N-mean*mean);
        var result = (mean*V , sigma*V/Sqrt(N)); //result and error
        return result;
}

    static void Main(){

    Func<vector, double> f = delegate(vector v){
        double x = v[0];
        double y = v[1];
        double z = v[2];
        return 1/(1-Cos(x)*Cos(y)*Cos(z));
    };

    vector start = new vector(0, 0, 0);
    vector end = new vector(PI, PI, PI);

    int N = 10000;

    var sol = plainmc(f, start, end, N);
    WriteLine($"The integral of ∫_0^π  dx/π ∫_ 0^π  dy/π ∫_0^π  dz/π  [1-cos(x)cos(y)cos(z)]-1 :{sol.Item1} with error: {sol.Item2} calculated with {N} steps");



    }
}