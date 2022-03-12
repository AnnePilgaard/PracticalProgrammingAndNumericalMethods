out.txt: main.exe 
	mono main.exe 1 2 3 4 5 > out.txt
	cat out.txt

main.exe: main.cs
	mcs main.cs

clean:
	rm input.txt main.exe out.txt