
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anoBase = 1000;
            Console.WriteLine("Digite o ano inicial");
            var anoBaseInput = Console.ReadLine();
            if (int.TryParse(anoBaseInput, out int parsedAnoBase) && parsedAnoBase > 0)
                anoBase = parsedAnoBase;

            int anoFinal = 5000;
            Console.WriteLine("Digite o ano final");
            var anoFinalInput = Console.ReadLine();
            if (int.TryParse(anoFinalInput, out int parsedAnoFinal) && parsedAnoFinal > 0)
                anoFinal = parsedAnoFinal;

            for (int anoAnalisado = anoBase; anoAnalisado <= anoFinal; anoAnalisado++)
            {
                string baseDirectory = AppContext.BaseDirectory;

                string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));

                string filePath = Path.Combine(projectDirectory, "tennis_atp", $"atp_matches_{anoAnalisado}.csv");

                var service = new CSVTennisService.Services.CSVTennisService();
                var matches = service.ReadMatches(filePath).Where(x => x.TourneyLevel == "G").ToList();

                //var randomMatches = matches.OrderBy(m => Guid.NewGuid()).Take(100).ToList();

                Console.WriteLine("\n" + new string('=', 120));
                Console.WriteLine(" 🏆 TORNEIOS DE TÊNIS - RESULTADOS ");
                Console.WriteLine(new string('=', 120));
                Console.WriteLine($"{"Torneio",-20} | {"Data",-10} | {"Quadra",-6} | {"Rodada",-6} | {"Vencedor",-20} | {"Perdedor",-20} | {"Score",-15} | {"Duração",-8} | {"Rank V",-7} | {"Rank P",-7}");
                Console.WriteLine(new string('-', 120));

                int i = 1;
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.Tournament,-20} | " +
                                      $"{match.TourneyDate,-10} | " +
                                      $"{match.Surface,-6} | " +
                                      $"{match.Round,-6} | " +
                                      $"{match.Winner,-20} | " +
                                      $"{match.Loser,-20} | " +
                                      $"{match.Score,-15} | " +
                                      $"{(match.Minutes?.ToString() ?? "N/A"),-8} | " +
                                      $"{match.WinnerRank,-7} | " +
                                      $"{match.LoserRank,-7}");
                    i++;
                }

                Console.WriteLine(new string('=', 120));
                Console.WriteLine($"Total de partidas processadas: {matches.Count}");
                Console.WriteLine(new string('=', 120));


                double percentage = service.CalculateFirstSetWinPercentage(matches);

                Console.WriteLine($"Porcentagem de jogadores que venceram o 1º set e ganharam a partida em {anoAnalisado}: {percentage:F2}%");

                //var (topPlayer, turnaroundCount) = service.GetPlayerWithMostTurnarounds(matches);

                //Console.WriteLine($"Jogador com mais viradas em {anoAnalisado}: {topPlayer} com {turnaroundCount} viradas.");
            }
        }
    }
}
