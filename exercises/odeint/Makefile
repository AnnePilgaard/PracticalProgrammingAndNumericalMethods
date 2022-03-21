CSC = mcs
RUN = mono

all: Fig.oscillator.png

Fig.oscillator.png: fig.oscillator.gpi oscillator.data.txt
	pyxplot $<

oscillator.data.txt: main.exe
	mono $< 1> $@ 2>log

main.exe: main.cs matlib.dll

matlib.dll: ode.cs vector.cs
	mcs -target:library -out:./$@ $^
	
%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm *.dll *.exe *.png *.txt log*