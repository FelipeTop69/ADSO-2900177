<?php

    class nomina{
        private $diasTrabajados;
        private $valorDia;
        private $edadPersona;

        public function setDiasTrabajados($diasTrabajados){
            $this -> diasTrabajados = $diasTrabajados;
        }
        public function getDiasTrabajados(){
            return $this -> diasTrabajados;
        }

        public function setValorDia($valorDia){
            $this -> valorDia = $valorDia;
        }
        public function getValorDia(){
            return $this -> valorDia;
        }

        public function setEdadPersona($edadPersona){
            $this -> edadPersona = $edadPersona;
        }
        public function getEdadPersona(){
            return $this -> edadPersona;
        }
    }

    class calcularNomina{
        public $valorDia;
        public $diasTrabajados;
        public $salarioMinimo = 1300000; 
        public $edad;
        public $sueldo;
        public $subsidioTransporte;
        public $pension;
        public $salud;
        public $arl;
        public $retencion;
        public $extra;
        public $deducibles;
        public $sueldoTotal;

        public function calcularSueldo(nomina $claseNomina){
            $this -> sueldo = $claseNomina -> getDiasTrabajados() * $claseNomina -> getValorDia();
            return $this -> sueldo;
        }

        public function calcularSubsidioTransporte() {
            if($this->sueldo < $this->salarioMinimo * 2) {
                $this->subsidioTransporte = 114000;
            } else {
                $this->subsidioTransporte = 0;
            }
            return $this->subsidioTransporte;
        }
    
        public function calcularPension() {
            $this->pension = $this->sueldo * 0.16;
            return $this->pension;
        }
    
        public function calcularSalud() {
            $this->salud = $this->sueldo * 0.12;
            return $this->salud;
        }
    
        public function calcularARL() {
            $this->arl = $this->sueldo * 0.052;
            return $this->arl;
        }
    
        public function calcularRetencion() {
            if($this->sueldo < $this->salarioMinimo * 4) {
                $this->retencion = 0;
            } else {
                $this->retencion = $this->sueldo * 0.04;
            }
            return $this->retencion;
        }
    
        public function calcularExtra(nomina $claseNomina) {
            if($claseNomina -> getEdadPersona() > 39 && $claseNomina -> getEdadPersona() < 60) {
                $this->extra = $this->sueldo * 0.06;
            } elseif($claseNomina -> getEdadPersona() >= 60) {
                $this->extra = $this->sueldo * 0.08;
            } else {
                $this->extra = 0;
            }
            return $this->extra;
        }
    
        public function calcularDeducibles() {
            $this->deducibles = $this->pension + $this->salud + $this->arl + $this->retencion;
            return $this->deducibles;
        }
    
        public function calcularSueldoTotal() {
            $this->sueldoTotal = ($this->sueldo + $this->subsidioTransporte + $this->extra) - $this->deducibles;
            return $this->sueldoTotal;
        }

    }

?>