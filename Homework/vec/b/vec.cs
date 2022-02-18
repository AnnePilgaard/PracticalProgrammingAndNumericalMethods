using System;
using static System.Console;
using static System.Math;

public class vec{

    public double x, y, z;

    //Constructors:
    public vec(double a, double b, double c){
        x = a;
        y = b;
        z = c;
    }
    public vec(){
        x = 0;
        y = 0;
        z = 0;
    }

    //Override ToString
        public override string ToString(){
        string s = (this.x).ToString() + (this.y).ToString() + (this.z).ToString();
        return s;
    }   

    //Print method:
    public void print(string s){
        Write(s);WriteLine($"{x}  {y}  {z}");
    }
    public void print() {this.print("");}
    public static void print(vec v){v.print("Static method:");}

    //Operators
    public static vec operator*(vec u, double c){
        return new vec(u.x*c, u.y*c, u.z*c);
    }

    public static vec operator*(double c, vec u){
        return new vec(u.x*c, u.y*c, u.z*c);
    }

    public static vec operator+(vec u, vec v){
        return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
    }

    public static vec operator-(vec u){
        return -1*u;
    }

    public static vec operator-(vec u, vec v){
        return new vec(u.x-v.x, u.y-v.y, u.z-v.z);

    }

    //Methods
    public static double dot(vec v, vec u){
        double n = v.x*u.x+v.y*u.y+v.z*u.z;
        return n;
    }

    public static vec cross(vec a, vec b){
        double x = a.y*b.z + a.z*b.y;
        double y = a.z*b.x + a.x*b.z;
        double z = a.x*b.y + a.y*b.x;
        return new vec(x,y,z);    
    }

    public static double norm(vec v){
        return Sqrt(v.x*v.x+v.y*v.y+v.z*v.z);
    }
    

}