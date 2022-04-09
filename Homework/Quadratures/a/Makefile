all: Out.txt erf.pdf

erf.pdf: erf.gpi erf.txt tab_error.txt
	pyxplot $<

Out.txt erf.txt: main.exe 
	mono main.exe > Out.txt
	cat Out.txt

main.exe: main.cs vector.dll
	mcs -target:exe -out:main.exe -reference:vector.dll main.cs


vector.dll: vector.cs 
	mcs -target:library -out:./$@ $^

clean: 
	rm main.exe

