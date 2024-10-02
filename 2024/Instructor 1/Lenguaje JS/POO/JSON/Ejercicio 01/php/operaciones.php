<?php 

class Operaciones{
    private $numeroUno;
    private $numeroDos;
    private $suma;
    private $resta;
    private $multiplicacion;    
    private $division;

    public function __construct(Numero $numeroUno, Numero $numeroDos) {
        $this -> numeroUno = $numeroUno -> getNumero();
        $this -> numeroDos = $numeroDos -> getNumero();
    }
    public function sumar(){
        $this -> suma = $this-> numeroUno + $this-> numeroDos;
        return $this -> suma;
    }

    public function restar(){
        $this -> resta = $this-> numeroUno - $this-> numeroDos;
        return $this -> resta;
    }

    public function multiplicar(){
        $this -> multiplicacion = $this-> numeroUno * $this-> numeroDos;
        return $this -> multiplicacion;
    }

    public function dividir(){
        $this -> dividir = $this-> numeroUno / $this-> numeroDos;
        return $this -> dividir;
    }

}

?>