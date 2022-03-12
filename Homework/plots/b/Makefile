all: gamma_pyx.pdf log_gamma_pyx.pdf

gamma_pyx.pdf: gamma.gpi out_gamma.txt tab_gamma.txt
	pyxplot $<

log_gamma_pyx.pdf: log_gamma.gpi out_log_gamma.txt tab_log_gamma.txt
	pyxplot $<
	
out_gamma.txt: main.exe
	mono $< "gamma" > $@

out_log_gamma.txt: main.exe
	mono $< "log_gamma" > $@

main.exe: main.cs
	mcs main.cs

clean:
	rm main.exe 



