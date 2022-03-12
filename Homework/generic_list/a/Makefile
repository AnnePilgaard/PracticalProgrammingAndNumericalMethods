Out.txt: main.exe input.txt
	mono main.exe < input.txt > out.txt
	cat Out.txt

main.exe: main.cs genlist.dll
	mcs -target:exe -out:main.exe -reference:genlist.dll main.cs

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs

input.txt: 
	echo 1 2 3 4 5 > input.txt

clean:
	rm input.txt main.exe out.txt

