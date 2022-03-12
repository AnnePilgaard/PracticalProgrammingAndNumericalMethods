using System;
using static System.Console;



class main{

    public static Func<double> make_fa(){
    double a = 0;
    Func<double> fa = delegate(){a++; return a;};
    return fa; //so here we return both the function and the environment of the function, so in this case a is also captured. (called closure)
    }

    public static void Main(){
        Func<double> fun = delegate(){ return 7;};
        Func<double, double> square = delegate(double x){ return x*x;};
        Action hello = delegate(){ WriteLine("hello");};
        hello();
        WriteLine($"fun() = {fun()} should be equal 7");
        WriteLine($"square(2) = {square(2)} should be equal 4");


        double a = 0;
        Action fa = delegate(){a++;}; // remember the variable is captured as reference to outside of this function scope.
        fa();
        WriteLine($"a = {a} should be 1");
        fa();
        WriteLine($"a = {a} should be 2");
        fa();
        WriteLine($"a = {a} should be 3");
        fa();
        WriteLine($"a = {a} should be 4");


        Func<double> fb = make_fa();
        WriteLine($"fb() = {fb()} should be 1");
        WriteLine($"fb() = {fb()} should be 2");
        WriteLine($"fb() = {fb()} should be 3");
        Func<double> fc = make_fa();
        WriteLine($"fc() = {fc()} should be 1");

    }
}
