package FastEditUserInfo;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {

    public static Map<String, Map<String, Integer>> loyalClients = new HashMap<>();
    static {
        Map<String, Integer> condition = new HashMap<>();
        condition.put("Z6-23", 5);
        loyalClients.put("BG23-45", new HashMap<>(condition));
        condition.clear();
        condition.put("Z6-23", 5);
        loyalClients.put("BG23-45", new HashMap<>(condition));
        condition.clear();
    }

    public static void main(String[] args) throws IOException {
        List<Client> clients = new ArrayList<>();
        Client client = new Client("BG23-45", "Z6-23", 5);
        Client client1 = new Client("123", "1234567890", 25);
        Client client2 = new Client("BG40-50", "Z10-20", 12);

        clients.add(client);
        clients.add(client1);
        clients.add(client2);

        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        checkClients(clients, reader);
    }

    public static void checkClients(List<Client> clients, BufferedReader reader) throws IOException {
        for (Client client: clients) {
            String input = reader.readLine();
            if (client.getClientNum().equals(input)) {
                input = reader.readLine();
                if (client.getDocNum().equals(input)) {
                    input = reader.readLine();
                    if (client.getActiveYears() == Integer.parseInt(input)) {
                        System.out.println("yes");
                    }
                }
            }
        }
    }

    public static void checkClientsMap(List<Client> clients) {
        for (Client client :clients) {
            if (loyalClients.get(client.getClientNum()) != null
                    && loyalClients.get(client.getClientNum()).get(client.getDocNum()).equals(client.getActiveYears())) {
                System.out.println("Loyal client: " + client.getClientNum());
            }
        }
    }
}
