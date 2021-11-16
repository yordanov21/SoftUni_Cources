import java.util.Scanner;

public class RecursiveDrawing {
    public static void main(String[] args) {

        Scanner scanner= new Scanner(System.in);
        int number= Integer.parseInt(scanner.nextLine());

        drawFigure(number);
    }

    public static  void drawFigure(int number){

        if (number == 0) {
            return;
        }
       for (int i=0; i<number; i++){
           System.out.print("*");
       }
       System.out.println();

       drawFigure(number-1);

        for (int i=0; i<number; i++){
            System.out.print("#");
        }
        System.out.println();
    }
}
