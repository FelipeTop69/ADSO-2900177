<?php

class CalcularArea {
    public $lado;
    public $base;
    public $altura;
    public $area;

    public function areaCuadrado() {
        $this->area = $this->lado * $this->lado;
        return $this->area;
    }

    public function areaRectangulo() {
        $this->area = $this->base * $this->altura;
        return $this->area;
    }

    public function areaTriangulo() {
        $this->area = ($this->base * $this->altura) / 2;
        return $this->area;
    }
}

$calcular = new CalcularArea();

?>