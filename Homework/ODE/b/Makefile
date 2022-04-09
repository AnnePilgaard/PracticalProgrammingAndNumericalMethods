all: pendODE.png out.txt main.exe

pendODE.png: pendODE.gpi pendODE.txt 
	pyxplot $<

Out.txt: main.exe
	mono main.exe > Out.txt
	cat Out.txt

main.exe: main.cs ODE.dll matlib.dll genlist.dll
	mcs -target:exe -out:main.exe -reference:matlib.dll,ODE.dll,genlist.dll main.cs

matlib.dll: vector.cs 
	mcs -target:library -out:./$@ $^

genlist.dll: genlist.cs 
	mcs -target:library -out:./$@ $^

ODE.dll: ODE.cs matlib.dll genlist.dll
	mcs -target:library -out:ODE.dll -reference:matlib.dll,genlist.dll ODE.cs

clean:
	rm main.exe 

