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
        private $suma;
        private $resta;
        private $multiplicacion;
        private $division;
        public $mensajeError = "No se puede dividir por 0";

        public function sumar(operaciones $claseOperaciones){
            $this -> suma = $claseOperaciones -> getNumeroUno() + $claseOperaciones -> getNumeroDos();
            return $this -> suma;
        }

        public function restar(operaciones $claseOperaciones){
            $this -> resta = $claseOperaciones -> getNumeroUno() - $claseOperaciones -> getNumeroDos();
            return $this -> resta;
        }

        public function multiplicar(operaciones $claseOperaciones){
            $this -> multiplicacion = $claseOperaciones->getNumeroUno() * $claseOperaciones -> getNumeroDos();
            return $this -> multiplicacion;
        }

        public function dividir(operaciones $claseOperaciones){ 
            if($claseOperaciones -> getNumeroDos() == 0){
                $this -> mensajeError;
                return $this -> mensajeError;
            }else{
                $this -> division = $claseOperaciones->getNumeroUno() / $claseOperaciones -> getNumeroDos();
                return $this -> division;
            }
            
        }

    }

?>