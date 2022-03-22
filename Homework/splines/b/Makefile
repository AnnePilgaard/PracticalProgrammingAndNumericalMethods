all: qSpline.pdf main.exe out.txt

qSpline.pdf: qSpline.gpi input1.txt qspline1.txt qsplineDer.txt
	pyxplot $<

out.txt qspline1.txt qsplineDer.txt: main.exe
	mono $<  > out.txt
	cat out.txt	

main.exe: main.cs input1.txt qSpline.dll
	mcs -target:exe -out:main.exe -reference:qSpline.dll main.cs

qSpline.dll: qSpline.cs
	mcs -target:library -out:qSpline.dll qSpline.cs

clean:
	rm main.exe 


