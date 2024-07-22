Algoritmo Calculadora
	Definir N1,N2,op,op2,N Como Real
	Escribir 'Este algoritmo realiza cuatro operaciones basicas'
	Escribir 'Seleciones la ecuaciòn a realizar'
	Escribir '1. Suma'
	Escribir '2. Resta'
	Escribir '3. Multiplicaciòn'
	Escribir '4. Divisiòn'
	Escribir '5. Porcentaje'
	Escribir 'Selecione el numero de la ecuacion que requiere utilizar'
	Leer N
	Escribir 'Digite el primer numero'
	Leer N1
	Escribir 'Digite el segundo numero'
	Leer N2
	Segun N  Hacer
		1:
			op <- N1+N2
			Escribir 'La operacion que usted elijio fue la Suma y el resultado de los dos numeros es ',op
		2:
			op <- N1-N2
			Escribir 'La operacion que usted elijio fue la Resta y el resultado de los dos numeros es ',op
		3:
			op <- N1*N2
			Escribir 'La operacion que usted elijio fue la Multiplicaciòn y el resultado de los dos numeros es ',op
		4:
			op <- N1/N2
			Escribir 'La operacion que usted elijio fue la Division y el resultado de los dos numeros es ',op
		5:
			op <- N1/100
			op2 <- N2/100
			Escribir 'La operacion que usted elijio fue el porcentaje de un numero '
			Escribir 'Porcentaje del numero ',N1,' es ',op
			Escribir 'Porcentaje del numero ',N2,' es ',op2
		De Otro Modo:
			Escribir 'El numero de las opciones de operaciones no se encuentra dentro del rango'
	FinSegun
FinAlgoritmo
