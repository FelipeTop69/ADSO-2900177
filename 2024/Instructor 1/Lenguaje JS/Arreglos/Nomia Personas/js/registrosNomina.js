/**
 * Nomina de Personas
 * Autor: Ruben Felipe Tovar Aviles
 * 6 de junio del 2024
 */

let  nomina = [];
let sueldoPersona;
let subsidioTransportePersona;
let pensionPersona;
let saludPersona;
let arlPersona;
let retencionPersona;
let extraPersona;
let deduciblesPersona;
let pagoTotalPersona;
let iteracion;
let nominaPagoTotal = [];

nomina = [
    {id:1, nombres:'Ruben Felipe', apellidos:'Tovar Aviles', cedula:1076503319, edad:17, estrato:2, valorDia:200000, diasTrabajados:30},
    {id:2, nombres:'Andres', apellidos:'Moreno', cedula:7511689, edad:44, estrato:3, valorDia:120000, diasTrabajados:30},
    {id:3, nombres:'Esteban', apellidos:'Palomar', cedula:10373487, edad:18, estrato:3, valorDia:190000, diasTrabajados:30},
    {id:4, nombres:'Juan', apellidos:'Artunduaga', cedula:10311174, edad:19, estrato:3, valorDia:190000, diasTrabajados:30},
    {id:5, nombres:'Daniel', apellidos:'Bata', cedula:1178995, edad:17, estrato:1, valorDia:180000, diasTrabajados:25},
    {id:6, nombres:'Isabella', apellidos:'Carrera', cedula:1082505099, edad:16, estrato:3, valorDia:60000, diasTrabajados:30},
    {id:7, nombres:'Santiago', apellidos:'Chaparro', cedula:55156340, edad:20, estrato:4, valorDia:110000, diasTrabajados:20},
    {id:8, nombres:'Jesus', apellidos:'Carvajal', cedula:17799905, edad:18, estrato:2, valorDia:150000, diasTrabajados:30},
    {id:9, nombres:'Luis', apellidos:'Aviles', cedula:1996980, edad:62, estrato:1, valorDia:250000, diasTrabajados:30},
    {id:10, nombres:'Camilo', apellidos:'Charri', cedula:88992207, edad:20, estrato:3, valorDia:80000, diasTrabajados:30},

];

console.table(nomina)

for(iteracion = 0; iteracion < nomina.length; iteracion++){
    let valorD = nomina[iteracion].valorDia;
    let diasT = nomina[iteracion].diasTrabajados;
    sueldoPersona = calcularSueldo(valorD, diasT);
    subsidioTransportePersona = calcularSubsidioTransporte(sueldoPersona);
    pensionPersona = calcularPension(sueldoPersona);
    saludPersona = calcularSalud(sueldoPersona);
    arlPersona = calcularARL(sueldoPersona);
    retencionPersona = calcularRetencion(sueldoPersona);
    extraPersona = calcularExtra(sueldoPersona);
    deduciblesPersona = calcularDeducibles(sueldoPersona)
    pagoTotalPersona = calcularSueldoTotal(sueldoPersona)
    // console.log(`Variable Persona ${iteracion} es ${pagoTotalPersona}`);
    nominaPagoTotal.push({
        id: nomina[iteracion].id, nombres: nomina[iteracion].nombres, apellidos: nomina[iteracion].apellidos, cedula: nomina[iteracion].cedula,
        edad: nomina[iteracion].edad, subsidioT: subsidioTransportePersona, pension: pensionPersona, salud: saludPersona, arl: arlPersona,
        retencion: retencionPersona, extra: extraPersona, pagoTotal: pagoTotalPersona
    });
}

console.table(nominaPagoTotal)
