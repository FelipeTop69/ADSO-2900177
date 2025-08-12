#### 1. Tres personas deciden invertir su dinero para fundar una empresa. Cada una de ellas invierte una cantidad distinta. Obtener el porcentaje que cada quien invierte con respecto a la cantidad total invertida.

```
    INICIO

        DEFINIR cantInvertida, inversionP1, inversionP2, inversionP3, porcentajeP1, porcentajeP2, porcentajeP3 COMO REAL

        cantInvertida = 0
        inversionP1 = 0
        inversionP2 = 0
        inversionP3 = 0
        porcentajeP1 = 0
        porcentajeP2 = 0
        porcentajeP3 = 0

        ESCRIBIR "Digite la inversión de la primera persona: "
        LEER inversionP1
        ESCRIBIR "Digite la inversión de la segunda persona: "
        LEER inversionP2
        ESCRIBIR "Digite la inversión de la tercera persona: "
        LEER inversionP3

        cantInvertida = inversionP1 + inversionP2 + inversionP3
        porcentajeP1 = (inversionP1/cantInvertida)*100
        porcentajeP2 = (inversionP2/cantInvertida)*100
        porcentajeP3 = (inversionP3/cantInvertida)*100

        ESCRIBIR "El porcentaje de la inversión de la primer persona es: ",porcentajeP1,"%"
        ESCRIBIR "El porcentaje de la inversión de la segunda persona es: ",porcentajeP2,"%"
        ESCRIBIR "El porcentaje de la inversión de la tercera persona es: ",porcentajeP3,"%"  
    FIN
```

#### 2. Un alumno desea saber cuál será su promedio general en las tres materias más difíciles que cursa y cuál será el promedio que obtendrá en cada una de ellas. Estas materias se evalúan como se muestra a continuación:
-   La calificación de Matemáticas se obtiene de la siguiente manera: Examen 90% Promedio de tareas 10% En esta materia se pidió un total de tres tareas.

-   La calificación de Física se obtiene de la siguiente manera: Examen 80% Promedio de tareas 20% En esta materia se pidió un total de dos tareas.

-   La calificación de Química se obtiene de la siguiente manera: Examen 85% Promedio de tareas 15% En esta materia se pidió un promedio de tres tareas.

```
    INICIO

        DEFINIR promGeneral, promMat, promFis, promQui, examenMat, examenFis, examenQui, promTareasMat, promTareasFis, promTareasQui, tareaMat1, tareaMat2, tareaMat3, tareaFis1, tareaFis2, tareaQui1, tareaQui2, tareaQui3 COMO REAL
	
        promGeneral = 0
        promMat = 0
        promFis = 0
        promQui = 0
        examenMat = 0 
        examenFis = 0 
        examenQui = 0
        promTareasMat = 0 
        promTareasFis = 0 
        promTareasQui = 0
        tareaMat1 = 0 
        tareaMat2 = 0 
        tareaMat3 = 0 
        tareaFis1 = 0 
        tareaFis2 = 0 
        tareaQui1 = 0 
        tareaQui2 = 0 
        tareaQui3 = 0
        
        //Para Matematicas
        ESCRIBIR "Digite la calificación del examen de matemáticas: "
        LEER examenMat
        ESCRIBIR "Digite la calificación de su primera tarea de matemáticas: "
        LEER tareaMat1
        ESCRIBIR "Digite la calificación de su segunda tarea de matemáticas: "
        LEER tareaMat2
        ESCRIBIR "Digite la calificación de su tercera tarea de matemáticas: "
        LEER tareaMat3
        
        //Para Fisica
        ESCRIBIR "Digite la calificación del examen de Fisica: "
        LEER examenFis
        ESCRIBIR "Digite la calificación de su primera tarea de Fisica: "
        LEER tareaFis1
        ESCRIBIR "Digite la calificación de su segunda tarea de Fisica: "
        LEER tareaFis2
        
        //Para Quimica
        ESCRIBIR "Digite la calificación del examen de Química: "
        LEER examenQui
        ESCRIBIR "Digite la calificación de su primera tarea de Química: "
        LEER tareaQui1
        ESCRIBIR "Digite la calificación de su segunda tarea de Química: "
        LEER tareaQui2
        ESCRIBIR "Digite la calificación de su tercera tarea de Química: "
        LEER tareaQui3
        
        // Para Matematicas
        promTareasMat = (tareaMat1 + tareaMat2 +tareaMat3)/3
        promMat = (examenMat * 0.9) + (promTareasMat * 0.1)
        
        // Para Fisica
        promTareasFis = (tareaFis1 + tareaFis2)/2
        promFis = (examenFis * 0.8) + (promTareasFis * 0.2)
        
        // Para Quimica
        promTareasQui = (tareaQui1 + tareaQui2 + tareaQui3)/3
        promQui = (examenQui * 0.85) + (promTareasFis * 0.15)
        
        //Total Nota
        promGeneral = (promMat + promFis + promQui)/3
        
        
        
        ESCRIBIR "El promedio de total de Matemáticas es: ",promMat
        ESCRIBIR "El promedio de total de Fisica es: ",promFis
        ESCRIBIR "El promedio de total de Química es: ",promQui
        ESCRIBIR "La nota final de los promedios de las materias es: ",promGeneral
    FIN
```

### 3. Leer un real e imprimir si el número es positivo o negativo

```
 INICIO
    Definir num como real 
    num= 0.0

    Escribir "Digite un número "
    Leer num 

    Si num > 0 entonces
       Escribir "El número digitado es positivo"
    SiNO entonces
       Escribir "El núero digitado es negativo"
    FinSi   
 FIN 
```

### 4. Leer un real e imprimir si el número es mayor a 200 o no

```
 INICIO
    Definir num como real 
    num= 0.0

    Escribir "Digite un número "
    Leer num 

    Si num > 200 entonces
       Escribir "El número digitado es mayor a 200"
    SiNO entonces
       Escribir "El número digitado es menor a 200"
    FinSi   
 FIN 
```

### 5. Leer un real e imprimir si el número está en el rango de 50 y 100.

```
 INICIO
    Definir num como real 
    num= 0.0
	
    Escribir "Digite un número "
    Leer num 
	
    Si num >= 50 y num <= 100 entonces
		Escribir "El numero se encuentra dentro del rango"
    SiNO 
		Escribir "El numero no se encuentra dentro del rango"
    FinSi  
 FIN 
```
