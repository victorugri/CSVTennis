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
                    TourneyId = csv.GetField<string>("tourney_id"),
                    Tournament = csv.GetField<string>("tourney_name"),
                    Surface = csv.GetField<string>("surface"),
                    DrawSize = csv.TryGetField<int?>("draw_size", out var drawSize) ? drawSize ?? 0 : 0,
                    TourneyLevel = csv.GetField<string>("tourney_level"),
                    TourneyDate = csv.TryGetField<int?>("tourney_date", out var tourneyDate) ? tourneyDate ?? 0 : 0,
                    MatchNum = csv.TryGetField<int?>("match_num", out var matchNum) ? matchNum ?? 0 : 0,

                    WinnerId = csv.TryGetField<int?>("winner_id", out var winnerId) ? winnerId ?? 0 : 0,
                    WinnerSeed = csv.TryGetField<int?>("winner_seed", out var winnerSeed) ? winnerSeed : null,
                    WinnerEntry = csv.GetField<string>("winner_entry"),
                    Winner = csv.GetField<string>("winner_name"),
                    WinnerHand = csv.GetField<string>("winner_hand"),
                    WinnerHeight = csv.TryGetField<int?>("winner_ht", out var winnerHeight) ? winnerHeight : null,
                    WinnerIoc = csv.GetField<string>("winner_ioc"),
                    WinnerAge = csv.TryGetField<double?>("winner_age", out var winnerAge) ? winnerAge ?? 0 : 0,

                    LoserId = csv.TryGetField<int?>("loser_id", out var loserId) ? loserId ?? 0 : 0,
                    LoserSeed = csv.TryGetField<int?>("loser_seed", out var loserSeed) ? loserSeed : null,
                    LoserEntry = csv.GetField<string>("loser_entry"),
                    Loser = csv.GetField<string>("loser_name"),
                    LoserHand = csv.GetField<string>("loser_hand"),
                    LoserHeight = csv.TryGetField<int?>("loser_ht", out var loserHeight) ? loserHeight : null,
                    LoserIoc = csv.GetField<string>("loser_ioc"),
                    LoserAge = csv.TryGetField<double?>("loser_age", out var loserAge) ? loserAge ?? 0 : 0,

                    Score = csv.GetField<string>("score"),
                    BestOf = csv.TryGetField<int?>("best_of", out var bestOf) ? bestOf ?? 0 : 0,
                    Round = csv.GetField<string>("round"),
                    Minutes = csv.TryGetField<int?>("minutes", out var minutes) ? minutes : null,

                    WinnerAces = csv.TryGetField<int?>("w_ace", out var wAces) ? wAces ?? 0 : 0,
                    WinnerDoubleFaults = csv.TryGetField<int?>("w_df", out var wDf) ? wDf ?? 0 : 0,
                    WinnerServicePoints = csv.TryGetField<int?>("w_svpt", out var wSvpt) ? wSvpt ?? 0 : 0,
                    WinnerFirstIn = csv.TryGetField<int?>("w_1stIn", out var w1stIn) ? w1stIn ?? 0 : 0,
                    WinnerFirstWon = csv.TryGetField<int?>("w_1stWon", out var w1stWon) ? w1stWon ?? 0 : 0,
                    WinnerSecondWon = csv.TryGetField<int?>("w_2ndWon", out var w2ndWon) ? w2ndWon ?? 0 : 0,
                    WinnerServiceGames = csv.TryGetField<int?>("w_SvGms", out var wSvGms) ? wSvGms ?? 0 : 0,
                    WinnerBreakPointsSaved = csv.TryGetField<int?>("w_bpSaved", out var wBpSaved) ? wBpSaved ?? 0 : 0,
                    WinnerBreakPointsFaced = csv.TryGetField<int?>("w_bpFaced", out var wBpFaced) ? wBpFaced ?? 0 : 0,

                    LoserAces = csv.TryGetField<int?>("l_ace", out var lAces) ? lAces ?? 0 : 0,
                    LoserDoubleFaults = csv.TryGetField<int?>("l_df", out var lDf) ? lDf ?? 0 : 0,
                    LoserServicePoints = csv.TryGetField<int?>("l_svpt", out var lSvpt) ? lSvpt ?? 0 : 0,
                    LoserFirstIn = csv.TryGetField<int?>("l_1stIn", out var l1stIn) ? l1stIn ?? 0 : 0,
                    LoserFirstWon = csv.TryGetField<int?>("l_1stWon", out var l1stWon) ? l1stWon ?? 0 : 0,
                    LoserSecondWon = csv.TryGetField<int?>("l_2ndWon", out var l2ndWon) ? l2ndWon ?? 0 : 0,
                    LoserServiceGames = csv.TryGetField<int?>("l_SvGms", out var lSvGms) ? lSvGms ?? 0 : 0,
                    LoserBreakPointsSaved = csv.TryGetField<int?>("l_bpSaved", out var lBpSaved) ? lBpSaved ?? 0 : 0,
                    LoserBreakPointsFaced = csv.TryGetField<int?>("l_bpFaced", out var lBpFaced) ? lBpFaced ?? 0 : 0,

                    WinnerRank = csv.TryGetField<int?>("winner_rank", out var winnerRank) ? winnerRank ?? 0 : 0,
                    WinnerRankPoints = csv.TryGetField<int?>("winner_rank_points", out var winnerRankPoints) ? winnerRankPoints ?? 0 : 0,
                    LoserRank = csv.TryGetField<int?>("loser_rank", out var loserRank) ? loserRank ?? 0 : 0,
                    LoserRankPoints = csv.TryGetField<int?>("loser_rank_points", out var loserRankPoints) ? loserRankPoints ?? 0 : 0,

                    WinnerGames = ExtractGamesFromScore(csv.GetField<string>("score"), true),
                    LoserGames = ExtractGamesFromScore(csv.GetField<string>("score"), false)
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

        public (string player, int turnaroundCount) GetPlayerWithMostTurnarounds(List<Models.Match> matches)
        {
            var turnaroundCounts = new Dictionary<string, int>();

            foreach (var match in matches)
            {
                if (string.IsNullOrEmpty(match.Score)) continue;

                string[] sets = match.Score.Split(' ');

                if (sets.Length == 0) continue;

                string firstSet = sets[0]; // Primeiro set
                string[] games = firstSet.Split('-');

                if (games.Length != 2) continue;

                if (int.TryParse(games[0], out int winnerGames) && int.TryParse(games[1], out int loserGames))
                {
                    bool winnerWonFirstSet = winnerGames > loserGames;

                    if (!winnerWonFirstSet) // Se o vencedor PERDEU o primeiro set, foi uma virada
                    {
                        if (!turnaroundCounts.ContainsKey(match.Winner))
                        {
                            turnaroundCounts[match.Winner] = 0;
                        }

                        turnaroundCounts[match.Winner]++;
                    }
                }
            }

            if (turnaroundCounts.Count == 0)
            {
                return ("Ninguém", 0);
            }

            // Encontrar o jogador com mais viradas
            var topPlayer = turnaroundCounts.OrderByDescending(x => x.Value).First();
            return (topPlayer.Key, topPlayer.Value);
        }

    }
}
