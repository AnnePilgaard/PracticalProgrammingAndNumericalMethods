set terminal pdf
set output "gamma_gnu.tex"
set size 0.6
set tics out
set grid
set xlabel "$x$"
set ylabel "$y$"
set key bottom right
plot[][-5:5]\
 "out.gamma.txt" with lines title "$\Gamma(x)$"\
,"tab.gamma.txt" with points title "tab data"