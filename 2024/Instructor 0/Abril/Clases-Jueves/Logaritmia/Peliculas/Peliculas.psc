Algoritmo Peliculas
	Definir sala,cantidadEntradas Como Entero
	Definir valorNeto,totalPagar,descuento Como Real
	Escribir '     BIENVENIDOS A CINE ADSO     '
	Escribir '            CARTELERA            '
	Escribir 'SALA    Pelicula        Precio Entrada   '
	Escribir '  1    Interestelar        10.000 COP   '
	Escribir '  2    Baby Driver          9.000 COP   '
	Escribir '  3    Deadpool 3           8.000 COP   '
	Escribir ''
	Escribir 'Digite la sala de la pelicula a ver: '
	Leer sala
	Repetir
		Si sala=1 O sala=2 O sala=3 Entonces
			Escribir 'Digite la cantidad de entradas'
			Leer cantidadEntradas
			Segun sala  Hacer
				1:
					valorNeto <- 10000*cantidadEntradas
					Si cantidadEntradas>=3 Entonces
						descuento <- valorNeto*0.3
					SiNo
						descuento <- 0
					FinSi
					Escribir 'Descuento: ',descuento
					totalPagar <- valorNeto-descuento
					Escribir 'El Valor Para Ver Interestelar es: ',totalPagar
				2:
					valorNeto <- 9000*cantidadEntradas
					Si cantidadEntradas>=3 Entonces
						descuento <- valorNeto*0.3
					SiNo
						descuento <- 0
					FinSi
					totalPagar <- valorNeto-descuento
					Escribir 'Descuento: ',descuento
					Escribir 'El Valor Para Ver Baby Driver es: ',totalPagar
				3:
					valorNeto <- 8000*cantidadEntradas
					Si cantidadEntradas>=3 Entonces
						descuento <- valorNeto*0.3
					SiNo
						descuento <- 0
					FinSi
					totalPagar <- valorNeto-descuento
					Escribir 'Descuento: ',descuento
					Escribir 'El Valor Para Ver Deadpool 3 es: ',totalPagar
			FinSegun
		SiNo
			Escribir 'Sala no disponible, selecione otra'
			Leer sala
		FinSi
	Hasta Que totalPagar<>0
FinAlgoritmo
