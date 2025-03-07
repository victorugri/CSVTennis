using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using System.Globalization;
using System.Text.RegularExpressions;
using CSVTennisService.Models;

namespace CSVTennisService.Services
{
    public class CSVTennisService
    {

        public List<Models.Match> ReadMatches(string filePath)
        {
            var matches = new List<Models.Match>();

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            });

            // Ler o cabeçalho antes de começar
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                var match = new Models.Match
                {
                    Tournament = csv.GetField<string>("tourney_name"),
                    Surface = csv.GetField<string>("surface"),
                    Round = csv.GetField<string>("round"),
                    Winner = csv.GetField<string>("winner_name"),
                    Loser = csv.GetField<string>("loser_name"),
                    WinnerGames = ExtractGamesFromScore(csv.GetField<string>("score"), true),
                    LoserGames = ExtractGamesFromScore(csv.GetField<string>("score"), false),
                    Score = csv.GetField<string>("score")
                };

                matches.Add(match);
            }

            return matches;
        }

        private int ExtractGamesFromScore(string score, bool isWinner)
        {
            // Exemplo de "score": "6-4 7-6(5)"
            // Apenas uma lógica básica para contar games. Você pode ajustar conforme necessidade.

            if (string.IsNullOrEmpty(score))
                return 0;

            var sets = score.Split(' ');
            int totalGames = 0;

            foreach (var set in sets)
            {
                var games = set.Split('-');
                if (games.Length == 2 && int.TryParse(games[0], out int wGames) && int.TryParse(games[1], out int lGames))
                {
                    totalGames += isWinner ? wGames : lGames;
                }
            }

            return totalGames;
        }

        public double CalculateFirstSetWinPercentage(List<Models.Match> matches)
        {
            if (matches == null || matches.Count == 0)
            {
                return 0;
            }

            int totalMatches = 0;
            int firstSetWinnersWhoWonMatch = 0;

            foreach (var match in matches)
            {
                if (string.IsNullOrEmpty(match.Score)) continue;

                string[] sets = match.Score.Split(' ');

                if (sets.Length == 0) continue;

                string firstSet = sets[0]; // Pega o primeiro set
                string[] games = firstSet.Split('-');

                if (games.Length != 2) continue;

                if (int.TryParse(games[0], out int winnerGames) && int.TryParse(games[1], out int loserGames))
                {
                    totalMatches++;

                    // Quem venceu o primeiro set?
                    bool winnerWonFirstSet = winnerGames > loserGames;

                    // Se o vencedor da partida venceu o primeiro set, incrementamos o contador
                    if (winnerWonFirstSet)
                    {
                        firstSetWinnersWhoWonMatch++;
                    }
                }
            }

            if (totalMatches == 0)
                return 0;

            return (double)firstSetWinnersWhoWonMatch / totalMatches * 100;
        }
    }
}
