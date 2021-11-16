import java.util.Scanner;

public class RecursiveFibonacci {

    static long [] dictionary;

    static long fibonacci(int n) {
        if (n <= 1) {
            return 1;
        }
        if (dictionary[n] !=0) {
            return  dictionary[n];
        }

        dictionary[n]=fibonacci(n - 1) + fibonacci(n - 2);
        dictionary[n]=dictionary[n];
        return dictionary[n];
    }

    public static void main(String[] args) {
        Scanner scanner= new Scanner(System.in);

        int number= Integer.parseInt(scanner.nextLine());
        dictionary= new long[number+1];
        System.out.println(fibonacci(number));
    }

}
