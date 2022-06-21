out.txt: main.exe
	mono $<  > $@
	cat out.txt	

main.exe: main.cs matlib.dll
	mcs -target:exe -out:main.exe -reference:matlib.dll main.cs

matlib.dll: matrix.cs vector.cs QR_GramSchmidt.cs quasinewton.cs
	mcs -target:library -out:./$@ $^

clean:
	rm main.exe 