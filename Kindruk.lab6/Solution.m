%МЧА
%Лабораторная №6 
%Киндрук П.А., гр.353505
clc;
clear;
reset(symengine);
syms x L(x) li(x) P(x) t(x);
xi = [0 0.1 0.2 0.3 0.4 0.5 0.6 0.7 0.8 0.9 1];
pi = [0 0.41 0.79 1.13 1.46 1.76 2.04 2.3 2.55 2.79 3.01];
k = 9;
m = 4.5;
x0 = 0.47;
h = 0.1;
yi = pi+(-1)^k*m;
%Интерполяционный многочлен Лагранжа
L(x) = 0;
for j = 1:length(yi)
   li(x) = 1;
   for i = 1:length(yi)
      if j ~= i
          li(x) = li(x)*(x - xi(i))/(xi(j) - xi(i));
      end
   end
   L(x) = L(x) + li(x)*yi(j);
end
L(x) = simplify(L(x));
%Интерполяционный многочлен Ньютона
dy = zeros(length(yi), length(yi));
for i = 1:length(yi) - 1
    dy(1, i) = yi(i+1) - yi(i);
end
for i = 2:length(yi)
    for j = 1:length(yi) - 1
        dy(i,j) = dy(i - 1, j+1) - dy(i - 1, j);
    end
end
P(x) = yi(1);
for i = 1:length(yi)
    t(x) = dy(i, 1);
    for j = 1:i
        t(x) = t(x)*(x - xi(j))/h/j;
    end
    P(x) = P(x) + t(x);
end
P(x) = simplify(P(x));



disp('Интерполяционный многочлен Лангранжа:');
disp(L(x));
disp('Интерполяционный многочлен Ньютона:');
disp(P(x));
disp('L(x0) = ');
disp(double(L(x0)));
disp('P(x0) = ');
disp(double(P(x0)));