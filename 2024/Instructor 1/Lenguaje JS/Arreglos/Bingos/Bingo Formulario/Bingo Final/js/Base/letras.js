// Inicio Letra B
function letraB(pBingo){
    let bingo = pBingo;
    let iteracionLetraB;
    let pantallaLetraB = "";

    for (iteracionLetraB = 0; iteracionLetraB < 5; iteracionLetraB++) {
        pantallaLetraB += `<h6>Numero Letra B: ${bingo[iteracionLetraB][0]}</h6>`
    }

    return pantallaLetraB;
    
}
function mostrarLetraB() {
    let iteracionLetraB
    for (iteracionLetraB = 0; iteracionLetraB < 5; iteracionLetraB++) {
        document.getElementById(`celda-${iteracionLetraB}-0`).style.backgroundColor = "yellow";
    }
}
// Fin Letra B

// Inicio Letra I
function letraI(pBingo){
    let bingo = pBingo;
    let iteracionLetraI;
    let pantallaLetraI = "";

    for (iteracionLetraI = 0; iteracionLetraI < 5; iteracionLetraI++) {
        pantallaLetraI += `<h6>Numero Letra I: ${bingo[iteracionLetraI][1]}</h6>`
    }

    return pantallaLetraI;
    
}
function mostrarLetraI() {
    let iteracionLetraI
    for (iteracionLetraI = 0; iteracionLetraI < 5; iteracionLetraI++) {
        document.getElementById(`celda-${iteracionLetraI}-1`).style.backgroundColor = "yellow";
    }
}
// Fin Inicio Letra I

// Inicio Letra N
function letraN(pBingo){
    let bingo = pBingo;
    let iteracionLetraN;
    let pantallaLetraN = "";

    for (iteracionLetraN = 0; iteracionLetraN < 5; iteracionLetraN++) {
        pantallaLetraN += `<h6>Numero Letra N: ${bingo[iteracionLetraN][2]}</h6>`
    }

    return pantallaLetraN;
    
}
function mostrarLetraN() {
    let iteracionLetraN
    for (iteracionLetraN = 0; iteracionLetraN < 5; iteracionLetraN++) {
        document.getElementById(`celda-${iteracionLetraN}-2`).style.backgroundColor = "yellow";
    }
}
// Fin Letra N

// Inicio Letra G
function letraG(pBingo){
    let bingo = pBingo;
    let iteracionLetraG;
    let pantallaLetraG = "";

    for (iteracionLetraG = 0; iteracionLetraG < 5; iteracionLetraG++) {
        pantallaLetraG += `<h6>Numero Letra G: ${bingo[iteracionLetraG][3]}</h6>`
    }

    return pantallaLetraG;
    
}
function mostrarLetraG() {
    let iteracionLetraG
    for (iteracionLetraG = 0; iteracionLetraG < 5; iteracionLetraG++) {
        document.getElementById(`celda-${iteracionLetraG}-3`).style.backgroundColor = "yellow";
    }
}
// Fin Letra G

// Inicio Letra O
function letraO(pBingo){
    let bingo = pBingo;
    let iteracionLetraO;
    let pantallaLetraO = "";

    for (iteracionLetraO = 0; iteracionLetraO < 5; iteracionLetraO++) {
        pantallaLetraO += `<h6>Numero Letra O: ${bingo[iteracionLetraO][4]}</h6>`
    }

    return pantallaLetraO;
    
}
function mostrarLetraO() {
    let iteracionLetraO
    for (iteracionLetraO = 0; iteracionLetraO < 5; iteracionLetraO++) {
        document.getElementById(`celda-${iteracionLetraO}-4`).style.backgroundColor = "yellow";
    }
}
// Inicio Letra O
