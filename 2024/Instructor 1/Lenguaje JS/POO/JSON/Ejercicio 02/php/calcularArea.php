<?php 
class AreaFiguras{
    private $lado;
    private $base;
    private $altura;
    public $areaCuadrado;
    public $areaRectangulo;
    public $areaTriangulo;
    

    public function __construct(ValorMedida $ladoVM = null, ValorMedida $baseVM, ValorMedida $alturaVM) {
        $this->lado = $ladoVM ? $ladoVM->getValor() : 0;
        $this->base = $baseVM->getValor();
        $this->altura = $alturaVM->getValor();
    }

    public function areaCuadrado(){
        if($this->lado > 0){
            $this->areaCuadrado = pow($this->lado, 2);
            return $this->areaCuadrado;
        }else
        return "Lado no definido";
    }

    public function areaRectangulo(){
        $this -> areaRectangulo = $this -> base * $this -> altura;
        return $this -> areaRectangulo;
    }

    public function areaTriangulo(){
        $this -> areaTriangulo = ($this -> base * $this-> altura)/2;
        return $this -> areaTriangulo;
    }
}

?>