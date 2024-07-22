/**
 * Tercer ejercicio - Matriz Objeto
 * Autor: Ruben Felipe Tovar Aviles
 * Fecha: Miercoles 8 de abril del 2024
*/

let arregloTienda = [];
arregloTienda = [
    {
        id: 1, nombreProducto: "Pera", tipoProducto: "Fruta", cantidad: 100, tipoCantidad: "Unidad", precio: 600
    },
    {
        id: 2, nombreProducto: "Durazno", tipoProducto: "Fruta", cantidad: 80, tipoCantidad: "Unidad", precio: 900
    },
    {
        id: 3, nombreProducto: "Arbejas", tipoProducto: "Grano", cantidad: 2000, tipoCantidad: "gramos", precio: 200
    },
    {
        id: 4, nombreProducto: "Lenetajas", tipoProducto: "Grano", cantidad: 3100, tipoCantidad: "gramos", precio: 300
    },
    {
        id: 5, nombreProducto: "Galleta Oreo", tipoProducto: "Galleta", cantidad: 90, tipoCantidad: "Unidad", precio: 800
    },
    {
        id: 6, nombreProducto: "Galleta Festival", tipoProducto: "Galleta", cantidad: 100, tipoCantidad: "Unidad", precio: 700
    }
]

for(let iteracion = 0; iteracion < 6; iteracion++){
    if(arregloTienda[iteracion].cantidad <= 100 && arregloTienda[iteracion].tipoProducto == "Fruta"){
        console.log(arregloTienda[iteracion])
    }else{
        console.log("-")
        co
    }
}
