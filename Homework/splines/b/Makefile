all: qSpline.pdf main.exe

qSpline.pdf: qSpline.gpi input1.txt 
	pyxplot $<

main.exe: main.cs input1.txt qSpline.dll
	mcs -target:exe -out:main.exe -reference:qSpline.dll main.cs

qSpline.dll: qSpline.cs
	mcs -target:library -out:qSpline.dll qSpline.cs

clean:
	rm main.exe 


