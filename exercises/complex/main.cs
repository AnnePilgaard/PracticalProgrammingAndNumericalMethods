using static System.Console;
using static System.Math;
using static cmath;
class main{
public static void Main(){
	complex i = I;
	WriteLine($"imaginary i = {i}\n");
	
	exp(I).print("exp(I)         =");
	(Cos(1)+I*Sin(1)).print("cos(1)+i sin(1)=");
	log(exp(I)).print("\nln(exp(I))=");
	exp(I*PI).print("\nexp(I*PI)=");
	log(I).print("\nlog(I)=");
	//(PI*I/2).print("I*PI/2=");
	(I.pow(I)).print("\nI^I          =");
	exp(I*log(I)).print("exp(I*log(I))=");
}
}