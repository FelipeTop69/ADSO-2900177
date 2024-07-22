/**
 * Arreglo: Numeros del 1 al 10
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 08 de julio del 2024
 */

let arreglo = [];
let iteracion;
let resultadoLista = "";
let resultadoFactorial = "";
let numero;
let factorial = 1;

// Arreglo Quemado
arreglo = [1,2,4,5,6,7,8,9,10];

for(iteracion = 0; iteracion < arreglo.length; iteracion++){
    resultadoLista += `<option>${arreglo[iteracion]}</option>`;
}

document.getElementById("lista-numeros").innerHTML = resultadoLista;

// Arreglo Generado
arreglo = []
for(iteracion = 0; iteracion < 10; iteracion++){
    numero = iteracion + 1;
    arreglo.push(numero);
}

resultadoLista = ``
for(iteracion = 0; iteracion < arreglo.length; iteracion++){
    resultadoLista += `<option>${arreglo[iteracion]}</option>`;
}

document.getElementById("lista-numeros-dos").innerHTML = resultadoLista;

// Arreglo de Factorial
arreglo = []
for(iteracion = 1; iteracion <=5; iteracion++){
    factorial = factorial * iteracion
    arreglo.push(factorial);
}

resultadoLista = ``
for(iteracion = 0; iteracion < arreglo.length; iteracion++){
    resultadoLista += `
        <tr id="tabla-factorial">
          <th scope="row">${iteracion + 1}</th>
          <th scope="row">${arreglo[iteracion]}</th>
        </tr>
        `

        
}
document.getElementById("tabla-factorial").innerHTML = resultadoLista;
