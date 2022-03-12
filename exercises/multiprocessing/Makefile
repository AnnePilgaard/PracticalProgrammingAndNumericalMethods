out.txt: main.exe
	mono main.exe 1 8 > out.txt
	cat out.txt

main.exe: main.cs
	mcs main.cs


clean:
	rm main.exe out.txt