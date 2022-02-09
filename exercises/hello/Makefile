out.txt: hello.exe 
	mono hello.exe > out.txt

hello.exe: hello.cs
	mcs hello.cs

.PHONEY: clean
clean:
	rm -rf out.txt hello.exe
