Out.txt: main.exe
	mono main.exe > Out.txt
	cat Out.txt

main.exe: main.cs table.dll
	mcs -target:exe -out:main.exe -reference:table.dll main.cs

table.dll: table.cs
	mcs -target:library -out:table.dll table.cs

