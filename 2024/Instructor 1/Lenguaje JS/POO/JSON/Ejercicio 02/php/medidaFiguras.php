<?php

    class ValorMedida{
        private $valor;
        
        public function __construct($valor) {
            $this->valor = $valor;
        }

        public function setValor($valor){
            if (is_numeric($valor) && $valor > 0) {
                $this->valor = $valor;
            } else {
                throw new Exception('El valor debe ser un número mayor a 0');
            }
        }
        public function getValor(){
            return $this -> valor;
        }

    }

?>