public class Main {
    public static void main(String[] args) throws NoSuchMethodException {
        FootballPlayer tim = new FootballPlayer("Tim");
        BasketballPlayer joe = new BasketballPlayer("Joe");
        BaseballPlayer vasil = new BaseballPlayer("Vasil");

        Team<FootballPlayer> pichovete;
        pichovete = new Team("Pichovete");
        pichovete.addPlayer(tim);
        pichovete.addPlayer(tim);
        Team<FootballPlayer> pichovete1;
        pichovete1 = new Team<FootballPlayer>("Pichovete1");
        pichovete1.addPlayer(tim);
        pichovete.matchResult(pichovete1, 1, 0);

        System.out.println(pichovete.numPlayers());

    }
}
