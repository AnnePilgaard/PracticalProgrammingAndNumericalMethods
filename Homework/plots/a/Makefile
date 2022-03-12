
error_pyx.pdf: err.gpi out_error.txt tab_error.txt
	pyxplot $<

out_error.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs main.cs

clean:
	$(RM) *.png log* [Oo]ut* *.exe tab*

