
all: Out.txt fig.erf.png

fig.erf.png: fig.erf.gpi
	pyxplot $<

main_ode.exe: main2.cs matlib.dll

Out.txt erf.data.txt: main.exe
	mono $< 1> Out.txt 2>erf.data.txt
	#python3 test.py >> Out.txt
	cat Out.txt
	cat erf.data.txt

main.exe: main.cs matlib.dll

#LIBDIR = ../matlib/integrate
matlib.dll: integrate.cs # ode.cs vector.cs #$(LIBDIR)/integrate
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library -out: ./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


clean:
	rm *.dll

