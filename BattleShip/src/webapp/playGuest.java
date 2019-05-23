package webapp;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;


@WebServlet(name = "playGuest")
public class playGuest extends HttpServlet {
    PlayersQueue playersQueue;

    public playGuest() {
        super();
        this.playersQueue = new PlayersQueue();

    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.playersQueue.addPlayer(request.getParameter("name"));
        request.setAttribute("playerName", request.getParameter("name"));
        request.setAttribute("playerArray", playersQueue.getPlayersList().toString());
        request.setAttribute("playersSize", playersQueue.getPlayersLength());

        if (playersQueue.getPlayersLength() > 2) {
            request.getRequestDispatcher("TooManyPlayers.jsp").forward(request, response);
        }
        request.getRequestDispatcher("waitingQueue.jsp").forward(request, response);

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) {

    }

}
