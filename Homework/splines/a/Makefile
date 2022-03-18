all: linSpline.pdf out_integ.txt

linSpline.pdf: linearSpline.gpi input.txt out.txt
	pyxplot $<

out.txt: main.exe
	mono $< "spline" > $@

out_integ.txt: main.exe
	mono $< "integ_spline" > $@
	cat out_integ.txt	

main.exe: main.cs input.txt linearSpline.dll
	mcs -target:exe -out:main.exe -reference:linearSpline.dll main.cs

linearSpline.dll: linearSpline.cs
	mcs -target:library -out:linearSpline.dll linearSpline.cs

clean:
	rm main.exe 


