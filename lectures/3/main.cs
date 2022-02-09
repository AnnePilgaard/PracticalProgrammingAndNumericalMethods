using System;
using static System.Console;

public static class test{
    public static int n = 7;
    public static const double pi = 3.1415927;
    public static const double e = 2.71828;

}

public static class main{
    static string s = "main\n"
    static void hello(){
        string s = "hello\n";
        Write(s);
        {
            string s1 = "block\n"
            Write(s1)
        }

    }

    static int Main{
        double x, y;
        x = test.pi;
        y = test.e;
        Write($'x={x} y={y}\n')
    return 0;
    }

}