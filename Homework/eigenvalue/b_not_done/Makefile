all: out.txt rmax_convergence.pdf npoints_convergence.pdf


rmax_convergence.pdf: rmax_convergence.gpi rmax_convergence.txt 
	pyxplot $<

npoints_convergence.pdf: npoints_convergence.gpi npoints_convergence.txt 
	pyxplot $<	

rmax_convergence.txt npoints_convergence.txt out.txt: main.exe
	mono $<  > $@
	cat out.txt	

main.exe: main.cs matlib.dll  Amatrix.txt jacobi.dll 
	mcs -target:exe -out:main.exe -reference:matlib.dll,jacobi.dll main.cs

matlib.dll: matrix.cs vector.cs 
	mcs -target:library -out:./$@ $^

jacobi.dll: jacobi.cs matlib.dll
	mcs -target:library -out:jacobi.dll -reference:matlib.dll jacobi.cs

clean:
	rm main.exe 
