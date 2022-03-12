all:ms.pdf

ms.pdf:ms.tex exp_pyx.pdf 
	pdflatex $<
	pdflatex $<

exp_pyx.pdf:fig_pyxplot.gpi exp_approx.txt exp_real.txt
	pyxplot $<

exp_approx.txt: main.exe
	mono $< "approx" > $@

exp_real.txt: main.exe
	mono $< "real" > $@

main.exe: main.cs
	mcs main.cs

clean:
	rm main.exe 