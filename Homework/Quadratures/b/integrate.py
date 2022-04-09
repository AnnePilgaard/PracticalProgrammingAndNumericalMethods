import math
import scipy.integrate as integrate


ncalls2=0
def f2(x):
	global ncalls2
	ncalls2+=1
	return 1/math.sqrt(x)

result2=integrate.quad(f2,0,1)
print("Integration of of 1/Sqrt(x) from 0 to 1 in python =",result2[0],"which took ",ncalls2, "iterations")



ncalls4=0
def f4(x):
	global ncalls4
	ncalls4+=1
	return math.log(x)/math.sqrt(x)

result4=integrate.quad(f4,0,1)
print("Integration of of Log(x)/Sqrt(x) from 0 to 1 in python =",result4[0],"which took ",ncalls4, "iterations")