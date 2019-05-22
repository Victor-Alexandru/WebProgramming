package webapp;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class PlayersQueue {
    List<String> playersList;

    public PlayersQueue() {
        this.playersList = new ArrayList<>();
    }

    public void addPlayer(String name) {
        this.playersList.add(name);
    }

    public List<String> getPlayersList() {
        return this.playersList;
    }
}
