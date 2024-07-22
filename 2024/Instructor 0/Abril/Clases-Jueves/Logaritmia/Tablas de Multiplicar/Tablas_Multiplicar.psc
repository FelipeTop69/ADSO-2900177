Algoritmo Tablas_Multiplicar
	Definir contador,multiplicacion,resultado,tabla,tamaño,pares,impares Como Entero
	Escribir 'Digite la cantidad de Tablas de Multiplicar que dese ver: '
	Leer tabla
	Escribir 'Digite hasta que numero va a ir cada tabla: '
	Leer tamaño
	Para contador<-1 Hasta tabla Hacer
		multiplicacion <- 0
		pares <- 0
		impares <- 0
		Escribir 'Tabla del ',contador
		Para multiplicacion<-1 Hasta tamaño Hacer
			resultado <- contador*multiplicacion
			Si resultado MOD 2==0 Entonces
				Escribir contador,' x ',multiplicacion,' = ',resultado,' Resultado Par'
				pares <- pares+1
			SiNo
				Escribir contador,' x ',multiplicacion,' = ',resultado,' Resultado Impar'
				impares <- impares+1
			FinSi
		FinPara
		Escribir 'Cantidad de Pares: ',pares
		Escribir 'Cantidad de Impares: ',impares
		Escribir ''
	FinPara
FinAlgoritmo
