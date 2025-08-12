function enviarLetra(pIdLetra) {
    limpiarSeleccion();
    let idLetra = pIdLetra
    switch (idLetra) {
        case "boton-letra-B":
            let iteracionLetraB;
            for (iteracionLetraB = 0; iteracionLetraB < 5; iteracionLetraB++) {
                document.getElementById(`celda-${iteracionLetraB}-0`).style.backgroundColor = "rgba(255, 227, 68, 0.5)";
            }
            break;
        case "boton-letra-I":
            let iteracionLetraI;
            for (iteracionLetraI = 0; iteracionLetraI < 5; iteracionLetraI++) {
                document.getElementById(`celda-${iteracionLetraI}-1`).style.backgroundColor = "rgba(105, 255, 68, 0.5)";
            }
            break;
        case "boton-letra-N":
            let iteracionLetraN;
            for (iteracionLetraN = 0; iteracionLetraN < 5; iteracionLetraN++) {
                document.getElementById(`celda-${iteracionLetraN}-2`).style.backgroundColor = "rgba(255, 68, 68, 0.5)";
            }
            break;
        case "boton-letra-G":
            let iteracionLetraG
            for (iteracionLetraG = 0; iteracionLetraG < 5; iteracionLetraG++) {
                document.getElementById(`celda-${iteracionLetraG}-3`).style.backgroundColor = "rgba(180, 68, 255, 0.5)";
            }break;
        case "boton-letra-O":
            let iteracionLetraO
            for (iteracionLetraO = 0; iteracionLetraO < 5; iteracionLetraO++) {
                document.getElementById(`celda-${iteracionLetraO}-4`).style.backgroundColor = "rgba(0, 225, 255, 0.5)";
            }break;
    }
}

