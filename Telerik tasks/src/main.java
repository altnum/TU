import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

public class main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        StringBuilder str = new StringBuilder();

        for (int i = 0; i < 5; i++) {
            char digit = scanner.nextLine().charAt(0);
            String inputN = String.valueOf(digit);
            String res = String.valueOf(Math.pow(Double.parseDouble(String.valueOf(digit)), 3));
            str.append(res.charAt(res.length() - 3));
        }

        System.out.println(str);
        //task 2
        /*
        String n = scanner.nextLine();

        int evenSum = 0;
        int oddSum = 0;
        for (int i = 0; i < n.length(); i++) {
            int num = Integer.parseInt(String.valueOf(n.charAt(i)));
            if (num % 2 == 0)
                evenSum += num;
            else
                oddSum += num;
        }

        if (evenSum > oddSum) {
            System.out.printf("%d energy drinks%n", evenSum);
        } else if (evenSum < oddSum) {
            System.out.printf("%d cups of coffee%n", oddSum);
        } else {
            System.out.printf("%d of both%n", evenSum);
        }

         */

        //task 4
        /*
        Scanner scanner = new Scanner(System.in);
        String[] words = scanner.nextLine().split(", ");
        int wordsByPage = Integer.parseInt(scanner.nextLine());
        String keyWord = scanner.nextLine();

        int pages = words.length / wordsByPage;

        List<Integer> foundInPages = new LinkedList<>();

        int wordCounter = 0;
        int page = 1;

        for (int i = 0; i < words.length; i++) {
            if (words[i].equals(keyWord))
                foundInPages.add(page);

            if (wordCounter == 2) {
                wordCounter = 0;
                page++;
            }

            wordCounter++;
        }

        if (foundInPages.size() == 0)
            System.out.println(-1);
        else
            System.out.println(foundInPages.get(foundInPages.size() - 1));

         */
    }
}
