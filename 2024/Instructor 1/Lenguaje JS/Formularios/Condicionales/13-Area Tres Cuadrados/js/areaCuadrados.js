/**
 * Función Numeros Mayores - Imprimir el mayor de tres números con la misma validación
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: 17 de junio del 2024
 */

function areaCuadrados(pLado1, pLado2, pLado3){
    let lado1 = pLado1;
    let lado2 = pLado2;
    let lado3 = pLado3;

    let area1 = lado1 * lado1;
    let area2 = lado2 * lado2;
    let area3 = lado3 * lado3;

    let areaMayor

    if(area1 == area2 && area1 == area2 && area2 == area3){
        areaMayor = "";
    }else if (area1 == area2 && area1 > area3) {
        areaMayor = "Area Mayor: " + area1.toString() + "cm\u00b2";
    } else if (area1 == area3 && area1 > area2) {
        areaMayor = "Area Mayor: " + area1.toString() + "cm\u00b2";
    } else if (area2 == area3 && area2 > area1) {
        areaMayor = "Area Mayor: " + area2.toString() + "cm\u00b2";
    } else if (area1 > area2 && area1 > area3) {
        areaMayor = "Area Mayor: Primer Cuadrado " + area1 + "cm\u00b2";
    } else if (area2 > area1 && area2 > area3) {
        areaMayor = "Area Mayor: Segundo Cuadrado " + area2 + "cm\u00b2";
    } else {
        areaMayor = "Area Mayor: Tercer Cuadrado " + area3 + "cm\u00b2";
    }
    

    return areaMayor
}

function areaMayor() {
    let ladoUno = parseFloat(document.getElementById("txtLadoUno").value);
    let ladoDos = parseFloat(document.getElementById("txtLadoDos").value);
    let ladoTres = parseFloat(document.getElementById("txtLadoTres").value);
    
    if(isNaN(ladoUno) || isNaN(ladoDos) || isNaN(ladoTres)){
        document.getElementById("error").style.display = "block";
        document.getElementById("resultado").innerHTML = "";
    }else{
        let areaMayor = areaCuadrados(ladoUno, ladoDos, ladoTres);
        if (areaMayor.includes("Cuadrado") ){
            document.getElementById("igualdad").style.display = "none";
            document.getElementById("resultado").innerHTML = `<strong>${areaMayor} </strong>`
            document.getElementById("error").style.display = "none";
            
        }else if(areaMayor == ""){
            document.getElementById("igualdad").style.display = "none";
            document.getElementById("resultado").innerHTML = `<strong>Las Areas son Iguales</strong>`
            document.getElementById("error").style.display = "none";
            return false
        }else{
            document.getElementById("igualdad").style.display = "block";
            document.getElementById("igualdad").innerHTML = `<strong>Dos Cuadrados Iguales</strong>`
            document.getElementById("resultado").innerHTML = `<strong>${areaMayor}</strong>`
            document.getElementById("error").style.display = "none";
            
        }
        
    }

    return false;
}