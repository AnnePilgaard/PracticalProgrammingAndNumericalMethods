using System;
using static System.Console;
using static System.Math;


public static class main{

    public static int Main(string[] args){
        string infile=null,outfile=null;
        foreach(var arg in args){
                var words=arg.Split(':');
                WriteLine($"{arg}");
                if(words[0]=="-input"){
                    infile=words[1];
                }
                else if(words[0]=="-output"){
                    outfile=words[1];
                }
                else { Error.WriteLine("wrong argument"); return 1; }
                }
        var instream =new System.IO.StreamReader(infile);
        var outstream=new System.IO.StreamWriter(outfile);

        char[] delimiters = {' ','\t','\n'};

        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            var words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words) {
                double x = double.Parse(word);
                outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
        }
        instream.Close();
        outstream.Close();
	return 0;
    }
}