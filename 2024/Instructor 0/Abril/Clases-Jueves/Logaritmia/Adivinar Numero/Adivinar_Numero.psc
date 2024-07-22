Algoritmo Adivinar_Numero
	Definir numeroUsuario, numeroSecreto, vidas, intento, numeroMinimo, numeroMaximo Como Entero
	Definir return Como Caracter
	vidas = 8
	numeroMinimo = 1
	numeroMaximo = 100
	Escribir "ADIVINA EL NUMERO"
	Escribir "Adivino pero no Divino, tienes ", vidas, " vidas para adivinar el numero secreto entre ", numeroMinimo, " y ", numeroMaximo
	numeroSecreto = Aleatorio(numeroMinimo, numeroMaximo)
	Mientras vidas > 0 Hacer
		Escribir "Numero: "
		Leer numeroUsuario
		
		Si numeroUsuario == numeroSecreto Entonces
			Escribir "FELICIDADES!! Eres todo un adivino"
			vidas = 0
		SiNo 
			Si numeroUsuario < numeroSecreto Entonces
				Escribir "El numero es mayor"
			Sino
				Escribir "El numero es menor"
			FinSi
		Fin Si
		vidas = vidas - 1
		Escribir "Te quedan ", vidas, " vidas"
		Si vidas == 0  Entonces
			Escribir "Malo, te quedaste sin vidas. El numero secreto era: " numeroSecreto
			Escribir "¿Desear volver a jugar? S/N"
			Leer return
			Si return == "N" Entonces
				vidas = 0
			SiNo
				Si return == "S" Entonces
					vidas = 8
					numeroSecreto = Aleatorio(numeroMinimo, numeroMaximo)
					Escribir "Numero Secreto Actualizado, adivina"
				SiNo
					Escribir "Respuesta invalida"
					vidas = 0
				FinSi
			Fin Si
		Fin Si
	Fin Mientras
FinAlgoritmo
	