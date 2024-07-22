Algoritmo Contraseña_Aleatoria
	Definir longitudContraseña, generarContraseña como Entero
	Definir contenido como Cadena
	contraseña = ""
	Dimension contenido[18]
	contenido[1] = "1"; contenido[2]= "2"; contenido[3] = "3"; contenido[4] = "4";
	contenido[5] = "5"; contenido[6] = "6"; contenido[7] = "7"; contenido[8] = "8"; contenido[9] = "9";
	contenido[10] = "a"; contenido[11] = "e"; contenido[12] = "i"; contenido[13] = "o"; contenido[14] = "u";
	contenido[15] = "@"; contenido[16] = "#"; contenido[17] = "*"; 
	
	Escribir "Digite la cantidad de caracteres que desea para su contraseña"
	Repetir
		Leer longitudContraseña
		Si longitudContraseña < 6 Entonces
			Escribir "Contraseña Debil, ingrese otro valor"
		SiNo
			Escribir Sin Saltar "Su Contraseña es: "
			Para generarContraseña = 0 hasta (longitudContraseña - 1) Hacer
				Escribir  Sin Saltar contenido[Azar(17)]
			FinPara
			Escribir ""
		Fin Si
	Hasta Que longitudContraseña > 5

	
	
	
FinProceso

