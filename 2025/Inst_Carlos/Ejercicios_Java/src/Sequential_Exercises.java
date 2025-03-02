import java.util.Scanner;

public class Sequential_Exercises {
    public static void main(String[] args) throws Exception {

        Scanner scanner = new Scanner(System.in);

        System.out.println("Exercise 1 - Degrees Conversion");
        System.out.println("Enter the degress C°:");
        float degressC = scanner.nextFloat();

        degreeConversions(degressC);

        System.out.println("");

        System.out.println("Exercise 2 - Calculation BMI");
        System.out.println("Enter the weight of the person:");
        float weightPerson = scanner.nextFloat();
        System.out.println("Enter the weight of the person:");
        float heightPerson = scanner.nextFloat();

        calculationBMI(weightPerson, heightPerson);

        System.out.println("");

        System.out.println("Exercise 3 - Area and Perimeter of Triangle");
        System.out.println("Enter the base of the triangle:");
        float baseTriangle = scanner.nextFloat();
        System.out.println("Enter the height of the triangle:");
        float heightTriangle = scanner.nextFloat();

        triangleCalculation(heightTriangle, baseTriangle);

        System.out.println("");

        System.out.println("Exercise 4 - Arithmetic Operations");
        System.out.println("Enter the first number:");
        float numberOne = scanner.nextFloat();
        System.out.println("Enter the second number:");
        float numberTwo = scanner.nextFloat();

        operations(numberOne, numberTwo);

        System.out.println("");

        System.out.println("Exercise 5 - Exchange of Values");
        System.out.println("Enter the first value:");
        float valueA = scanner.nextFloat();
        System.out.println("Enter the second value:");
        float valueB = scanner.nextFloat();

        exchangeValues(valueA, valueB);
        
        scanner.close();
    }

    public static void degreeConversions(float degreesC){
        float degreesK = degreesC + 273.15f;
        float degreesF = (9 * degreesC / 5) + 32;

        System.out.println("The " + degreesC + " °C " + " to degrees fahrenheit are: " + degreesF + "°F");
        System.out.println("The " + degreesC + " °C " + " to degrees kelvin are: " + degreesK + "°K");
    }

    public static void triangleCalculation(float heightTriangle, float baseTriangle){
        float areaTriangle = (baseTriangle * heightTriangle) / 2;
        double hypotenuseTriangle = Math.sqrt(baseTriangle * baseTriangle + heightTriangle * heightTriangle);
        double perimeterTriangle = baseTriangle + heightTriangle + hypotenuseTriangle;

        System.out.println("The area of the triangle is: " + areaTriangle);
        System.out.println("The perimeter of the triangle is: " + perimeterTriangle);
    }

    public static void calculationBMI(float weightPerson, float heightPerson){
        double bmiPerson = weightPerson / Math.pow(heightPerson, 2);
        System.out.println("Your body mass index is: " + bmiPerson);
    }

    public static void operations(float numberOne, float numberTwo) {
        float addition  = numberOne + numberTwo;
        float subtraction = numberOne - numberTwo;
        float multiplication = numberOne * numberTwo;
        float division = numberOne / numberTwo;
        float module = numberOne % numberTwo;

        System.out.println("The addition of " + numberOne + " and " + numberTwo + " is " + addition);
        System.out.println("The subtraction of " + numberOne + " and " + numberTwo + " is " + subtraction);
        System.out.println("The multiplication of " + numberOne + " and " + numberTwo + " is " + multiplication);
        System.out.println("The division of " + numberOne + " and " + numberTwo + " is " + division);
        System.out.println("The module of " + numberOne + " and " + numberTwo + " is " + module);
    }

    public static void exchangeValues(float valueA, float valueB) {
        valueA = valueA + valueB;
        valueB = valueA - valueB;
        valueA = valueA - valueB;

        System.out.println(valueA);
        System.out.println(valueB);
    }
}