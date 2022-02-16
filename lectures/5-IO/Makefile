all: Out-stdin.txt Outfile.txt out.cmdLine.txt
	cat out.cmdline.txt


out.cmdLine.txt: cmdline.exe Makefile
	mono cmdline.exe 12 13 14 > $@

cmdline.exe: cmdline.cs
	mcs -target:exe -out:$@ $<

Outfile.txt: fileio.exe	
	mono $< input.txt 1 > $@

fileio.exe: fileio.cs	
	mcs -target:exe -out:$@ $<

Out-stdin.txt: stdin.exe 
	mono $< input.txt 1>$@ 2>log.txt

input.txt: Makefile
	echo -1.234e-5 99.9e+5 > input.txt

stdin.exe: stdin.cs
	mcs -target:exe -out:$@ $<

.PHONEY: clean
clean:
	$(RM) [Oo]ut* *.exe [Ll]og*

TEST = 'output'
test: 
	echo $(RM)