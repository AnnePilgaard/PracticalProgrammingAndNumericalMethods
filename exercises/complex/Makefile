CSC = mcs
RUN = mono

all: Out.txt
	cat Out.txt

Out.txt: main.exe
	$(RUN) main.exe > Out.txt

main.exe: main.cs cmath.dll
	$(CSC) -t:exe -out:$@ $(addprefix -r:,$(filter %.dll,$^)) $<

cmath.dll: complex.cs cmath.cs
	$(CSC) -t:library -out:./$@ $^

clean:
	$(RM) *.exe *.dll [Oo]ut*.txt