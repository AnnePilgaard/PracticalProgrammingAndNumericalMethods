// (C) 2020 Dmitri Fedorov; License: GNU GPL v3+; no warranty.
using System;
using System.IO;
using static System.Math;
using static System.Console;
public partial class vector{

private double[] data;
public int size{ get{return data.Length;} }

public double this[int i]{
	get{return data[i];}
	set{data[i]=value;}
}

public vector(int n){data=new double[n];}
public vector(double[] a){data=a;}
public vector(double a)
	{ data = new double[]{a}; }
public vector(double a, double b)
	{ data = new double[]{a,b}; }
public vector(double a, double b, double c)
	{ data = new double[]{a,b,c}; }
public vector(double a, double b, double c, double d)
	{ data = new double[]{a,b,c,d}; }
public vector(string s){
	char[] delims={',',' '};
	var options = StringSplitOptions.RemoveEmptyEntries;
        string[] words = s.Split(delims,options);
        int n = words.Length;
        data = new double[n];
        for(int i=0;i<size;i++){
                        this[i]=double.Parse(words[i]);
                        }
	}


public static implicit operator vector (double[] a){ return new vector(a); }
public static implicit operator double[] (vector v){ return v.data; }

public void print(string s="",string format="{0,10:g3} "){
	this.fprint(Console.Out,s,format);
	}

public void fprint(TextWriter file,string s="",string format="{0,10:g3} "){
	file.Write(s);
	for(int i=0;i<size;i++) file.Write(format,this[i]);
	file.Write("\n");
}

public static vector operator+(vector v, vector u){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]+u[i];
	return r; }

public static vector operator-(vector v){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=-v[i];
	return r; }

public static vector operator-(vector v, vector u){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]-u[i];
	return r; }

public static vector operator*(vector v, double a){
	vector r=new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=a*v[i];
	return r; }

public static vector operator*(double a, vector v){
	return v*a; }

public static vector operator/(vector v, double a){
	vector r=new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=v[i]/a;
	return r; }

public double dot(vector o){
	double sum=0;
	for(int i=0;i<size;i++)sum+=this[i]*o[i];
	return sum;
	}
public static double operator%(vector a,vector b){
	return a.dot(b);
	}

public vector map(System.Func<double,double>f){
	vector v=new vector(size);
	for(int i=0;i<size;i++)v[i]=f(this[i]);
	return v;
	}

public double norm(){
	double meanabs=0;
	for(int i=0;i<size;i++)meanabs+=Abs(this[i]);
	if(meanabs==0)meanabs=1;
	meanabs/=size;
	double sum=0;
	for(int i=0;i<size;i++)sum+=(this[i]/meanabs)*(this[i]/meanabs);
	return meanabs*Sqrt(sum);
	}

public vector copy(){
	vector b=new vector(this.size);
	for(int i=0;i<this.size;i++)b[i]=this[i];
	return b;
}

public void push(double newPoint) {
	var newData = new double[data.Length+1];

	for(int i = 0; i < data.Length; i++){
        newData[i] = data[i];
    }

	newData[newData.Length - 1] = newPoint;
	data = newData;
}

public double pop() {
	double result = data[data.Length-1];
	double[] newData = new double[data.Length-1];
	for(int i = 0; i < data.Length-1; i++){
        newData[i] = data[i];
    }

	data = newData;

	return result;
}

public static bool approx(double x, double y, double acc=1e-9, double eps=1e-9){
	if(Abs(x-y)<acc)return true;
	if(Abs(x-y)/Max(Abs(x),Abs(y))<eps)return true;
	return false;
	}

public static bool approx(vector a,vector b,double acc=1e-9,double eps=1e-9){
	if(a.size!=b.size)return false;
	for(int i=0;i<a.size;i++)
		if(!approx(a[i],b[i],acc,eps))return false;
	return true;
}
public bool approx(vector o){
	for(int i=0;i<size;i++)
		if(!approx(this[i],o[i]))return false;
	return true;
	}

}//vector