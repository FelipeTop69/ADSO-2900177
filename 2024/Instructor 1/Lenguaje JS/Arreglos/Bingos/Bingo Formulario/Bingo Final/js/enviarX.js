function enviarX(pIdX) {
    limpiarSeleccion();
    let idX = pIdX
    switch (idX) {
        case "boton-primera-X":
            let iteracionPrimeraXUno;
            let iteracionPrimeraXDos;
            for (iteracionPrimeraXUno = 2; iteracionPrimeraXUno < 5; iteracionPrimeraXUno++) {
                for (iteracionPrimeraXDos = 0; iteracionPrimeraXDos < 3; iteracionPrimeraXDos++) {
                    if (iteracionPrimeraXUno % 2 == 0 && iteracionPrimeraXDos % 2 == 0) {
                        document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "rgba(6, 165, 6, 0.7)";
                    }else if (iteracionPrimeraXUno % 2 == 1 && iteracionPrimeraXDos % 2 == 1) {
                        document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "rgba(6, 165, 6, 0.7)";
                    }else {
                        document.getElementById(`celda-${iteracionPrimeraXUno}-${iteracionPrimeraXDos}`).style.backgroundColor = "";
                    }
                }
            }
            break;
        case "boton-segunda-X":
            let iteracionSegundaXUno;
            let iteracionSegundaXDos;
            for (iteracionSegundaXUno = 2; iteracionSegundaXUno < 5; iteracionSegundaXUno++) {
                for (iteracionSegundaXDos = 2; iteracionSegundaXDos < 5; iteracionSegundaXDos++) {
                    if (iteracionSegundaXUno % 2 == 0 && iteracionSegundaXDos % 2 == 0) {
                        document.getElementById(`celda-${iteracionSegundaXUno}-${iteracionSegundaXDos}`).style.backgroundColor = "rgba(42, 202, 207, 0.7)";
                    }else if (iteracionSegundaXUno % 2 == 1 && iteracionSegundaXDos % 2 == 1) {
                        document.getElementById(`celda-${iteracionSegundaXUno}-${iteracionSegundaXDos}`).style.backgroundColor = "rgba(42, 202, 207, 0.7)";
                    }else {
                        document.getElementById(`celda-${iteracionSegundaXUno}-${iteracionSegundaXDos}`).style.backgroundColor = "";
                    }
                }
            }
            break;
        case "boton-tercera-X":
            let iteracionTerceraXUno;
            let iteracionTerceraXDos;
            for (iteracionTerceraXUno = 0; iteracionTerceraXUno < 3; iteracionTerceraXUno++) {
                for (iteracionTerceraXDos = 1; iteracionTerceraXDos < 4; iteracionTerceraXDos++) {
                    if (iteracionTerceraXUno % 2 == 0 && iteracionTerceraXDos % 2 == 1) {
                        document.getElementById(`celda-${iteracionTerceraXUno}-${iteracionTerceraXDos}`).style.backgroundColor = "rgba(107, 49, 182, 0.7)";
                    }else if (iteracionTerceraXUno % 2 == 1 && iteracionTerceraXDos % 2 == 0) {
                        document.getElementById(`celda-${iteracionTerceraXUno}-${iteracionTerceraXDos}`).style.backgroundColor = "rgba(107, 49, 182, 0.7)";
                    }else {
                        document.getElementById(`celda-${iteracionTerceraXUno}-${iteracionTerceraXDos}`).style.backgroundColor = "";
                    }
                }
            }
            break;
        case "boton-X-general":
            let iteracionXGeneralUno;
            let iteracionXGeneralDos;
        
            for (iteracionXGeneralUno = 0; iteracionXGeneralUno < 5; iteracionXGeneralUno++) {
                for (iteracionXGeneralDos = 0; iteracionXGeneralDos < 5; iteracionXGeneralDos++) {
                    if (iteracionXGeneralUno == iteracionXGeneralDos) {
                        document.getElementById(`celda-${iteracionXGeneralUno}-${iteracionXGeneralDos}`).style.backgroundColor = "rgba(204, 46, 85, 0.7)";
                    }else if (iteracionXGeneralUno + iteracionXGeneralDos == 4) {
                        document.getElementById(`celda-${iteracionXGeneralUno}-${iteracionXGeneralDos}`).style.backgroundColor = "rgba(204, 46, 85, 0.7)";
                    }else {
                        document.getElementById(`celda-${iteracionXGeneralUno}-${iteracionXGeneralDos}`).style.backgroundColor = "";
                    }
                }
            }
        
    }   

}