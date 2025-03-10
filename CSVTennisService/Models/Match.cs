using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTennisService.Models
{
    public class Match
    {
        /// <summary>
        /// Identificador único do torneio.
        /// </summary>
        public string TourneyId { get; set; }

        /// <summary>
        /// Nome do torneio.
        /// </summary>
        public string Tournament { get; set; }

        /// <summary>
        /// Tipo de superfície da quadra (Hard, Clay, Grass, etc.).
        /// </summary>
        public string Surface { get; set; }

        /// <summary>
        /// Número total de jogadores no torneio.
        /// </summary>
        public int DrawSize { get; set; }

        /// <summary>
        /// Nível do torneio (ex: A, G, M).
        /// </summary>
        public string TourneyLevel { get; set; }

        /// <summary>
        /// Data do torneio no formato AAAAMMDD.
        /// </summary>
        public int TourneyDate { get; set; }

        /// <summary>
        /// Número identificador da partida no torneio.
        /// </summary>
        public int MatchNum { get; set; }

        /// <summary>
        /// ID do jogador vencedor.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// Cabeça de chave do vencedor (se aplicável).
        /// </summary>
        public int? WinnerSeed { get; set; }

        /// <summary>
        /// Como o vencedor entrou no torneio (ex: WC - Wild Card, Q - Qualifier, etc.).
        /// </summary>
        public string WinnerEntry { get; set; }

        /// <summary>
        /// Nome do jogador vencedor.
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// Mão dominante do vencedor (R - destro, L - canhoto).
        /// </summary>
        public string WinnerHand { get; set; }

        /// <summary>
        /// Altura do vencedor em centímetros.
        /// </summary>
        public int? WinnerHeight { get; set; }

        /// <summary>
        /// Nacionalidade (país) do vencedor.
        /// </summary>
        public string WinnerIoc { get; set; }

        /// <summary>
        /// Idade do vencedor na data da partida.
        /// </summary>
        public double WinnerAge { get; set; }

        /// <summary>
        /// ID do jogador perdedor.
        /// </summary>
        public int LoserId { get; set; }

        /// <summary>
        /// Cabeça de chave do perdedor (se aplicável).
        /// </summary>
        public int? LoserSeed { get; set; }

        /// <summary>
        /// Como o perdedor entrou no torneio (ex: WC - Wild Card, Q - Qualifier, etc.).
        /// </summary>
        public string LoserEntry { get; set; }

        /// <summary>
        /// Nome do jogador perdedor.
        /// </summary>
        public string Loser { get; set; }

        /// <summary>
        /// Mão dominante do perdedor (R - destro, L - canhoto).
        /// </summary>
        public string LoserHand { get; set; }

        /// <summary>
        /// Altura do perdedor em centímetros.
        /// </summary>
        public int? LoserHeight { get; set; }

        /// <summary>
        /// Nacionalidade (país) do perdedor.
        /// </summary>
        public string LoserIoc { get; set; }

        /// <summary>
        /// Idade do perdedor na data da partida.
        /// </summary>
        public double LoserAge { get; set; }

        /// <summary>
        /// Placar do jogo, incluindo tiebreaks.
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// Número máximo de sets possíveis na partida.
        /// </summary>
        public int BestOf { get; set; }

        /// <summary>
        /// Rodada da partida (R16, QF, SF, F, etc.).
        /// </summary>
        public string Round { get; set; }

        /// <summary>
        /// Duração da partida em minutos.
        /// </summary>
        public int? Minutes { get; set; }

        /// <summary>
        /// Aces do vencedor.
        /// </summary>
        public int WinnerAces { get; set; }

        /// <summary>
        /// Duplas faltas do vencedor.
        /// </summary>
        public int WinnerDoubleFaults { get; set; }

        /// <summary>
        /// Pontos sacados pelo vencedor.
        /// </summary>
        public int WinnerServicePoints { get; set; }

        /// <summary>
        /// Primeiros serviços dentro de quadra do vencedor.
        /// </summary>
        public int WinnerFirstIn { get; set; }

        /// <summary>
        /// Pontos ganhos no primeiro saque do vencedor.
        /// </summary>
        public int WinnerFirstWon { get; set; }

        /// <summary>
        /// Pontos ganhos no segundo saque do vencedor.
        /// </summary>
        public int WinnerSecondWon { get; set; }

        /// <summary>
        /// Games de saque do vencedor.
        /// </summary>
        public int WinnerServiceGames { get; set; }

        /// <summary>
        /// Break points salvos pelo vencedor.
        /// </summary>
        public int WinnerBreakPointsSaved { get; set; }

        /// <summary>
        /// Break points enfrentados pelo vencedor.
        /// </summary>
        public int WinnerBreakPointsFaced { get; set; }

        /// <summary>
        /// Aces do perdedor.
        /// </summary>
        public int LoserAces { get; set; }

        /// <summary>
        /// Duplas faltas do perdedor.
        /// </summary>
        public int LoserDoubleFaults { get; set; }

        /// <summary>
        /// Pontos sacados pelo perdedor.
        /// </summary>
        public int LoserServicePoints { get; set; }

        /// <summary>
        /// Primeiros serviços dentro de quadra do perdedor.
        /// </summary>
        public int LoserFirstIn { get; set; }

        /// <summary>
        /// Pontos ganhos no primeiro saque do perdedor.
        /// </summary>
        public int LoserFirstWon { get; set; }

        /// <summary>
        /// Pontos ganhos no segundo saque do perdedor.
        /// </summary>
        public int LoserSecondWon { get; set; }

        /// <summary>
        /// Games de saque do perdedor.
        /// </summary>
        public int LoserServiceGames { get; set; }

        /// <summary>
        /// Break points salvos pelo perdedor.
        /// </summary>
        public int LoserBreakPointsSaved { get; set; }

        /// <summary>
        /// Break points enfrentados pelo perdedor.
        /// </summary>
        public int LoserBreakPointsFaced { get; set; }

        /// <summary>
        /// Ranking ATP do vencedor antes da partida.
        /// </summary>
        public int WinnerRank { get; set; }

        /// <summary>
        /// Pontos no ranking ATP do vencedor antes da partida.
        /// </summary>
        public int WinnerRankPoints { get; set; }

        /// <summary>
        /// Ranking ATP do perdedor antes da partida.
        /// </summary>
        public int LoserRank { get; set; }

        /// <summary>
        /// Pontos no ranking ATP do perdedor antes da partida.
        /// </summary>
        public int LoserRankPoints { get; set; }
        public int WinnerGames { get; set; }
        public int LoserGames { get; set; }
    }

}
