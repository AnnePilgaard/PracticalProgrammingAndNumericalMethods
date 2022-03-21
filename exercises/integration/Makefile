all: Out.integ.txt Fig.erf.pdf 

Fig.erf.pdf: fig.erf.gpi erf.data.txt
	pyxplot $<


Out.integ.txt erf.data.txt: main.exe 
	mono $< 1> Out.txt 2>erf.data.txt

main.exe:main.cs matlib.dll

matlib.dll: integrate.cs 
	mcs -target:library -out:./$@ $^
	
%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm *.dll *.exe *.pdf *.txt log*