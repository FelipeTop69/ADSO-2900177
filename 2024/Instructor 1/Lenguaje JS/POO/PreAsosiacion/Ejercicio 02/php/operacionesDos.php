<?php

    class operaciones{
        private $numeroUno;
        private $numeroDos;

        public function setNumeroUno($numeroUno){
            $this -> numeroUno = $numeroUno;
        }
        
        public function getNumeroUno(){
            return $this -> numeroUno;
        }

        public function setNumeroDos($numeroDos){
            $this -> numeroDos = $numeroDos;
        }
        
        public function getNumeroDos(){
            return $this -> numeroDos;
        }
    }

    class controlOperaciones{
        private $numeroUno;
        private $numeroDos;
        private $suma;
        private $resta;
        private $multiplicacion;
        private $division;
        public $mensajeError = "No se puede dividir por 0";

        public function sumar($numeroUno, $numeroDos){
            $this -> numeroUno = $numeroUno;
            $this -> numeroDos = $numeroDos;
            $this -> suma = $this -> numeroUno + $this -> numeroDos;
            return $this -> suma;
        }

        public function restar($numeroUno, $numeroDos){
            $this -> numeroUno = $numeroUno;
            $this -> numeroDos = $numeroDos;
            $this -> resta = $this -> numeroUno - $this -> numeroDos;
            return $this -> resta;
        }

        public function multiplicar($numeroUno, $numeroDos){
            $this -> numeroUno = $numeroUno;
            $this -> numeroDos = $numeroDos;
            $this -> multiplicacion = $this -> numeroUno * $this -> numeroDos;
            return $this -> multiplicacion;
        }

        public function dividir($numeroUno, $numeroDos){ 
            $this -> numeroUno = $numeroUno;
            $this -> numeroDos = $numeroDos;
            if($this -> numeroDos == 0){
                $this -> mensajeError;
                return $this -> mensajeError;
            }else{
                $this -> division = $this -> numeroUno / $this -> numeroDos;
                return $this -> division;
            }
            
        }

    }

?>