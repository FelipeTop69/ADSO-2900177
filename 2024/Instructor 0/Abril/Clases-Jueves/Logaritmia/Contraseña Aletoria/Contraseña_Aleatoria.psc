Algoritmo Contrase�a_Aleatoria
	Definir longitudContrase�a, generarContrase�a como Entero
	Definir contenido como Cadena
	contrase�a = ""
	Dimension contenido[18]
	contenido[1] = "1"; contenido[2]= "2"; contenido[3] = "3"; contenido[4] = "4";
	contenido[5] = "5"; contenido[6] = "6"; contenido[7] = "7"; contenido[8] = "8"; contenido[9] = "9";
	contenido[10] = "a"; contenido[11] = "e"; contenido[12] = "i"; contenido[13] = "o"; contenido[14] = "u";
	contenido[15] = "@"; contenido[16] = "#"; contenido[17] = "*"; 
	
	Escribir "Digite la cantidad de caracteres que desea para su contrase�a"
	Repetir
		Leer longitudContrase�a
		Si longitudContrase�a < 6 Entonces
			Escribir "Contrase�a Debil, ingrese otro valor"
		SiNo
			Escribir Sin Saltar "Su Contrase�a es: "
			Para generarContrase�a = 0 hasta (longitudContrase�a - 1) Hacer
				Escribir  Sin Saltar contenido[Azar(17)]
			FinPara
			Escribir ""
		Fin Si
	Hasta Que longitudContrase�a > 5

	
	
	
FinProceso

