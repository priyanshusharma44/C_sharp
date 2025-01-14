using System;

namespace EventDelegates
{
    public class ChampionsLeagueMatch
    {
        // Defining delegate 
        public delegate void GoalScoredHandler(string team, string player);

        // Event based on delegate
        public event GoalScoredHandler GoalScored;

        // Method to score a goal
        public void ScoreGoal(string team, string player)
        {
            Console.WriteLine($"GOAL! {player} scores for {team}");
            GoalScored?.Invoke(team, player); // Notify subscribers
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Create match object
            ChampionsLeagueMatch match = new ChampionsLeagueMatch();

            // Subscribe to the GoalScored event
            match.GoalScored += UpdateScoreboard;
            match.GoalScored += CommentatorReaction;

            // Simulate goals
            match.ScoreGoal("Realmadrid", "Vinicius");
            match.ScoreGoal("ManchesterCity", "Haaland");
        }

        // Event subscriber to update the scoreboard
        public static void UpdateScoreboard(string team, string player)
        {
            Console.WriteLine($"[Scoreboard Update] {team} now has another goal scored by {player}");
        }

        // Event subscriber for commentator reaction
        public static void CommentatorReaction(string team, string player)
        {
            Console.WriteLine($"[Commentator] What a goal by {player}! The crowd goes wild for {team}");
        }
    }
}
