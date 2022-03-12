out.txt: main.exe input.txt
	mono main.exe < input.txt > out.txt
	cat out.txt

main.exe: main.cs
	mcs main.cs

input.txt: 
	echo 1 2 3 4 5 > input.txt

clean:
	rm input.txt main.exe out.txt