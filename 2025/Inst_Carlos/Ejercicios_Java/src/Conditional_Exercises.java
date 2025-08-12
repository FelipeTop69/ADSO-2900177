import java.util.Scanner;

public class Conditional_Exercises {
    public static void main(String[] args) throws Exception {

        Scanner scanner = new Scanner(System.in);

        System.out.println("Exercise 1 - Evaluate Number");
        System.out.println("Enter a number:");
        float number = scanner.nextFloat();

        evaluateNumber(number);

        System.out.println("");

        System.out.println("Exercise 2 - Largest Number" );
        System.out.println("Enter the first number:");
        float numberOne = scanner.nextFloat();
        System.out.println("Enter the second number:");
        float numberTwo = scanner.nextFloat();
        System.out.println("Enter the third number:");
        float numberThree = scanner.nextFloat();

        largestNumber(numberOne, numberTwo, numberThree);

        System.out.println("");

        System.out.println("Exercise 2 - Lape Year" );
        System.out.println("Enter a year:");
        int year = scanner.nextInt();

        leapYear(year);

        System.out.println("");

        System.out.println("Exercise 3 - Claiffy Triangle" );
        System.out.println("Enter the side one:");
        float sideOne = scanner.nextFloat();
        System.out.println("Enter the side two:");
        float sideTwo = scanner.nextFloat();
        System.out.println("Enter the side three:");
        float sideThree = scanner.nextFloat();

        classifyTriangle(sideOne, sideTwo, sideThree);

        System.out.println("");

        System.out.println("Exercise 4 - Calculator");
        System.out.print("Enter the fisrt number: ");
        float num1 = scanner.nextFloat();

        System.out.print("Enter the second number: ");
        float num2 = scanner.nextFloat();

        System.out.print("Ingrese the operation (+, -, *, /): ");
        char operacion = scanner.next().charAt(0); 

        calculator(num1, num2, operacion);

        scanner.close();
    }
    
    public static void evaluateNumber(float number){
        if (number == 0){
            System.out.println("The number " + number +" is zero");
        }else if (number > 0) {
            System.out.println("The number " + number +" is positive");
        }else if (number < 0) {
            System.out.println("The number " + number +" is negative");
        }
    }

    public static void largestNumber(float numberOne, float numberTwo, float numberThree){
        float largestNumber;

        if (numberOne > numberTwo && numberOne > numberThree) {
            largestNumber = numberOne;
        } else if (numberTwo > numberOne && numberTwo > numberThree) {
            largestNumber = numberTwo;
        } else {
            largestNumber = numberThree;
        }
        
        System.out.println("The largest number is: " + largestNumber);
    }

    public static void leapYear(int year) {
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) {
            System.out.println("The year " + year + " is a leap year.");
        } else {
            System.out.println("The year " + year + " is not a leap year.");
        }
    }


    public static void classifyTriangle(float sideOne, float sideTwo, float sideThree) {
        if (sideOne == sideTwo && sideTwo == sideThree) {
            System.out.println("Equilateral (All sides are equal)");
        } else if (sideOne == sideTwo || sideOne == sideThree || sideTwo == sideThree) {
            System.out.println("Isosceles (Two sides are equal)");
        } else {
            System.out.println("Scalene (All sides are different)");
        }
    }

    public static void calculator(float num1, float num2, char operation) {
        float result;
        switch (operation) {
            case '+':
                result = num1 + num2;
                System.out.println("The result is: " + result);
                break;
            case '-':
                result = num1 - num2;
                System.out.println("The result is: " + result);
                break;
            case '*':
                result = num1 * num2;
                System.out.println("The result is: " + result);
                break;
            case '/':
                if (num2 != 0) {
                    result = num1 / num2;
                    System.out.println("The result is: " + result);
                } else {
                    System.out.println("Error: cannot divide by zero");
                }
                break;
            default:
                System.out.println("Invalid operation. Use +, -, * o /.");
        }
    }

}


// Ejercicios Cíclicos (bucles for, while, do-while)
// Tabla de multiplicar: Pide un número y muestra su tabla de multiplicar del 1 al 10.
// Suma de N números: Solicita un número N y suma los primeros N números naturales.
// Contador de dígitos: Pide un número entero y cuenta cuántos dígitos tiene.
// Serie Fibonacci: Imprime los primeros N términos de la serie de Fibonacci.
// Números primos en un rango: Solicita un número límite y muestra todos los primos hasta ese número.