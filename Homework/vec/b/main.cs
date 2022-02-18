using System;
using static System.Console;
using static System.Math;
using static vec;

class main{
        static void Main(){
            //Here I make illustrations of the vec class
            vec u = new vec();
            u.print("Constructor without input: u = ");
            vec v1 = new vec(1,2,3);
            v1.print("Constructor with input:   v1 = ");
            vec v2 = new vec(2,3,4);
            v2.print("Constructor with input:   v2 = ");


            (v1+v2).print("Illustrating addition:    v1+v2 = ");
            (v1-v2).print("Illustrating subtraction:     v1-v2 = ");

            double c = 3.0;
            var temp = c*v1;  
            temp.print("Illustrating multiplication: v1*3 = ");
            
            
            double d = dot(v1, v2);
            Write($"Illustating dot product:   v1 dot v2 = {d} \n");

            (cross(v1,v2)).print("Illustrating cross product: v1 cross v2 = ");

            double n = norm(v1);
            Write($"Illustating norm of v1: {n} \n");

            Write($"Illustrating the override ToString on v1: v1.ToString().GetType()= { v1.ToString().GetType()} \n");
            

        }

}

