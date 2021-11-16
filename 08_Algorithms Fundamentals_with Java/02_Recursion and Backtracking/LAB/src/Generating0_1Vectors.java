import java.util.Scanner;

public class Generating0_1Vectors {
    public static void main(String[] args) {

        Scanner scanner= new Scanner(System.in);
        int number= Integer.parseInt(scanner.nextLine());

        Integer[] memory = new Integer[number];

        fillVector(memory, memory.length-1);
    }

    private static void fillVector(Integer[] memory, int index) {
        if (index<0){
            print(memory);
            return;
        }

        for (int i=0; i<=1; i++){
            memory[index]=i;
            fillVector(memory,index-1);
        }
    }

    private static void print(Integer[] memory) {
        for (int i=memory.length-1; i>=0; i--){
            System.out.print(memory[i]);
        }

        System.out.println();
    }
}