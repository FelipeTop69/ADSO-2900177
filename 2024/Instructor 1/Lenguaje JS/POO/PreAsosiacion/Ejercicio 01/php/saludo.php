<?php

    class saludo {
        private $mensaje;

        public function setSaludar($mensaje){
            $this -> mensaje = $mensaje;
        }

        public function getSaludar(){
            return $this -> mensaje;
        }
    }

?>