// Define the Cricket class
public class Cricket
{
    // 1. Define a delegate type that represents methods accepting two string arguments (player, team).
    public delegate void CricketScore(string player, string team);

    // 2. Declare the event using the delegate type. The event allows methods to subscribe and get triggered.
    public static event CricketScore? CricketScored;

    // 3. The Score method simulates a player scoring. It displays player/team info and triggers the event.
    public static void Score(string player, string team)
    {
        Console.WriteLine($"{player}={team}"); // Print player/team details
        CricketScored?.Invoke(player, team); // Trigger the event if there are any subscribers
    }
}

// Define the Program class
public class Program
{
    // Main entry point of the program
    static void Main(string[] args)
    {
        // 4. Subscribe the methods to the CricketScored event.
        Cricket.CricketScored += ScoreUpdate; // Subscribe to scoreboard update
        Cricket.CricketScored += CommentatorReaction; // Subscribe to commentator reaction

        // 5. Simulate a player scoring by calling the Score method.
        Cricket.Score("Virat Kholi", "RCB"); // This will trigger both subscribed methods
    }

    // 6. ScoreUpdate method prints the player's score on the scoreboard.
    public static void ScoreUpdate(string player, string team)
    {
        Console.WriteLine($"[Scoreboard] 4 = {player}, team={team}"); // Print score update
    }

    // 7. CommentatorReaction method prints the commentator's response to the score.
    public static void CommentatorReaction(string player, string team)
    {
        Console.WriteLine($"Fantastic score from {player}. {team} Fans are getting encouraged");
    }
}
