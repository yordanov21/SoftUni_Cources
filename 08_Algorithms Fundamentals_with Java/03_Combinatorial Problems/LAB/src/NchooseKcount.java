import java.util.Scanner;

public class NchooseKcount {

    public static  int N;
    public static  int K;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        N= Integer.parseInt(scanner.nextLine());
        K= Integer.parseInt(scanner.nextLine());

        System.out.println(binom(N, K));
    }

    public static int  binom(int n, int k) {
        if (k > n) {
            return 0;
        }
        if (k== 0) {
            return 1;
        }
        if (k == n) {
            return 1;
        }
      return binom(n - 1, k - 1)+binom(n-1,k);
    }
}

