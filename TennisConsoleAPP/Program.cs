
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anoBase = 1968;
            int anoFinal = 2025;
            for (int anoAnalisado = anoBase; anoAnalisado <= anoFinal; anoAnalisado++)
            {
                string filePath = @$"D:\Downloads\tennis_atp-master\tennis_atp-master\atp_matches_{anoAnalisado}.csv";

                var service = new CSVTennisService.Services.CSVTennisService();
                var matches = service.ReadMatches(filePath);

                //Console.WriteLine("Torneio         | Superfície | Rodada   | Vencedor         | Perdedor        | Score");
                //Console.WriteLine(new string('-', 100));

                //foreach (var match in matches)
                //{
                //    Console.WriteLine($"{match.Tournament,-15} | {match.Surface,-10} | {match.Round,-8} | {match.Winner,-15} | {match.Loser,-15} | {match.Score}");
                //}

                double percentage = service.CalculateFirstSetWinPercentage(matches);

                Console.WriteLine($"Porcentagem de jogadores que venceram o 1º set e ganharam a partida em {anoAnalisado}: {percentage:F2}%");
            }
        }
    }
}
