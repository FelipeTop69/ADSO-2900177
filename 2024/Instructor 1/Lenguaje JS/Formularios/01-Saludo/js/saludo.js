/*
Funcion Saludar 
Autor: Ruben Felipe Tovar Aviles
Fecha: 17 de junio del 2024
*/

function saludar(){
    let saludo = document.getElementById("txtSaludo").value
    if(saludo == ""){
        document.getElementById("error").style.display = "block";
        document.getElementById("saludo").innerHTML = "";
        
    }else{
        
        document.getElementById("saludo").innerHTML=`<strong>${saludo}</strong>`
        
        
        document.getElementById("error").style.display = "none";
    }
    return false

}