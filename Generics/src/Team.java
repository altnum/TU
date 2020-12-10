import java.util.ArrayList;

public class Team <T extends Player> {
    private String name;
    int played = 0;
    int won = 0;
    int lost = 0;
    int tied = 0;

    private ArrayList<T> members = new ArrayList<>();

    public Team(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public boolean addPlayer(T player) throws NoSuchMethodException {
        if(members.contains(player)){
            System.out.println(player.getName() + "- already in the team!");
            return false;
        } else {
            members.add(player);
            System.out.println(player.getName() + " is added in " + this.name);
            return true;
        }
    }

    public int numPlayers() {
        return this.members.size();
    }

    public void setPlayed(int played) {
        this.played = played;
    }

    public void setWon(int won) {
        this.won = won;
    }

    public void setLost(int lost) {
        this.lost = lost;
    }

    public void setTied(int tied) {
        this.tied = tied;
    }

    public int getPlayed() {
        return played;
    }

    public int getWon() {
        return won;
    }

    public int getLost() {
        return lost;
    }

    public int getTied() {
        return tied;
    }

    public void matchResult(Team opponent, int ourScore, int theirScore) {
        if (ourScore > theirScore) {
            won++;
            System.out.println(this.name + " won against " + opponent.name);
            opponent.setLost(opponent.getLost() + 1);
        } else if (ourScore == theirScore) {
            tied++;
            System.out.println(this.name + " tied against " + opponent.name);
            opponent.setTied(opponent.getTied() + 1);
        } else {
            lost++;
            System.out.println(this.name + " lost against " + opponent.name);
            opponent.setWon(opponent.getWon() + 1);
        }

        played++;
        opponent.setPlayed(opponent.getPlayed() + 1);
    }

    public int ranking() {
        return (won * 2) + tied;
    }
}
