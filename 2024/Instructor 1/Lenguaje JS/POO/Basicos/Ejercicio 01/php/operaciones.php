<?php
class operacion {

    // Atributos
    public $numeroUno;
    public $numeroDos;
    public $suma;
    public $resta;
    public $multiplicacion;
    public $division;

    // Metodos
    public function sumar($pNumeroUno, $pNumeroDos){
        $this-> numeroUno = $pNumeroUno;
        $this-> numeroDos = $pNumeroDos;
        $this -> suma = $this-> numeroUno + $this-> numeroDos;
        return $this -> suma;
    }
}

$operacion = new operacion();

?>