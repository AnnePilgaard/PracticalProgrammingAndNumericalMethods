all: fitPlot.pdf out.txt


fitPlot.pdf: fitPlot.gpi dataLog.txt 
	pyxplot $<

out.txt: main.exe
	mono $<  > $@
	cat out.txt	

main.exe: main.cs matlib.dll QR_GramSchmidt.dll data.txt
	mcs -target:exe -out:main.exe -reference:matlib.dll,QR_GramSchmidt.dll main.cs

matlib.dll: matrix.cs vector.cs 
	mcs -target:library -out:./$@ $^

QR_GramSchmidt.dll: QR_GramSchmidt.cs matlib.dll
	mcs -target:library -out:QR_GramSchmidt.dll -reference:matlib.dll QR_GramSchmidt.cs

clean:
	rm main.exe 
