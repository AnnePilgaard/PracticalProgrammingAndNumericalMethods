all: out.txt rmax_convergence.pdf npoints_convergence.pdf eigenfunctions.pdf 

eigenfunctions.pdf: eigenfunctions.gpi eigenfunctions.txt 
	pyxplot $<

rmax_convergence.pdf: rmax_convergence.gpi rmax_convergence.txt 
	pyxplot $<

npoints_convergence.pdf: npoints_convergence.gpi npoints_convergence.txt 
	pyxplot $<	

eigenfunctions.txt rmax_convergence.txt npoints_convergence.txt out.txt: main.exe
	mono $<  > $@
	cat out.txt	

main.exe: main.cs matlib.dll  jacobi.dll 
	mcs -target:exe -out:main.exe -reference:matlib.dll,jacobi.dll main.cs

matlib.dll: matrix.cs vector.cs 
	mcs -target:library -out:./$@ $^

jacobi.dll: jacobi.cs matlib.dll
	mcs -target:library -out:jacobi.dll -reference:matlib.dll jacobi.cs

clean:
	rm main.exe 
