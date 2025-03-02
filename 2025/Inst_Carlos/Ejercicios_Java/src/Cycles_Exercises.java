import java.util.Scanner;

public class Cycles_Exercises {
    public static void main(String[] args) throws Exception {

        Scanner scanner = new Scanner(System.in);

        System.out.println("Exercise 1 - Multiplication Tables");
        System.out.println("Enter a number: ");
        int numberTable = scanner.nextInt();

        multiplicationTable(numberTable);

        System.out.println("");

        System.out.println("Exercise 2 - Addition Numbers");
        System.out.println("Enter a number: ");
        int numberSum = scanner.nextInt();

        additionNumbers(numberSum);

        System.out.println("");

        System.out.println("Exercise 3 - Digit Counter");
        System.out.println("Enter a number: ");
        int numberCounter = scanner.nextInt();

        digitCounter(numberCounter);

        System.out.println("");

        System.out.println("Exercise 4 - Fibonacci Series");
        System.out.println("Enter a number: ");
        int numberSeries = scanner.nextInt();

        fibonacciSeries(numberSeries);

        System.out.println("");

        System.out.println("Exercise 5 - Prime Numbers");
        System.out.println("Enter a number: ");
        int numberPrime = scanner.nextInt();

        primeNumbers(numberPrime);





        scanner.close();
    }
    
    public static void multiplicationTable(int numberTable) {

        System.out.println("Table of " + numberTable);

        int result;

        for(int index = 1; index <= 10; index++){
            result = numberTable * index ;
            System.out.println(numberTable + "x" + index + "=" + result);
        }

    }

    public static void additionNumbers(int number) {
        int sum = 0;
        for(int index = 1; index <= number; index++){
            sum = sum + index;
        }
        System.out.println("The sum of numbers up to " + number + " is: " + sum);

    }

    public static void digitCounter(int number) {
        int digits = 0;
        int numberOriginal = number;

        if (number == 0) {
            System.out.println("The number " + number + " has a digit");
        }else{
            if (number < 0) {
                number = -number;
            }

            while (number > 0) {
                number /= 10;
                digits++;
            }

            System.out.println("The number " + numberOriginal + " has " + digits + " digits");

        }

        // if (number == 0) {
        //     System.out.println("The number " + number + " have a digit");
        //     return;
        // }
        // digits = String.valueOf(number).length();
        
        // if (number > 0) {
        //     System.out.println("The number " + number + " has " + digits + " digits");
        // }else{
        //     digits = digits - 1;
        //     System.out.println("The number " + number + " has " + digits + " digits");
        // }
    }



    public static void fibonacciSeries(int number) {

        int numberBefore = 0;
        int numberCurrent = 1;
        int sum = 0;

        for(int index = 1; index <= number; index++){
            System.out.println(numberBefore);
            sum = numberBefore + numberCurrent;
            numberBefore = numberCurrent;
            numberCurrent = sum;
        }

    }

    public static void primeNumbers(int number) {

        for (int num = 2; num <= number; num++) {
            boolean isPrime = true;


            for (int index = 2; index <= Math.sqrt(num); index++) {
                if (num % index == 0 || num < 2) {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) {
                System.out.println(num);
            }

        }

    }




}

