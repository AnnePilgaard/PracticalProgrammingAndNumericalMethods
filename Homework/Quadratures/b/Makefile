Out.txt: main.exe integrate.py
	mono main.exe > Out.txt
	python3 integrate.py >> Out.txt
	cat Out.txt

main.exe: main.cs vector.dll
	mcs -target:exe -out:main.exe -reference:vector.dll main.cs

vector.dll: vector.cs 
	mcs -target:library -out:./$@ $^

clean: 
	rm main.exe

