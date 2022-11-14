using System.Collections.Generic;

namespace TicTacToeKata {
    public class TicTacToeGame {
        private Player playerTurnSymbol = Player.X;

        public Dictionary<Position, Player?> Board = new Dictionary<Position, Player?> {
            { Position.TopLeft , null},   { Position.TopMid, null},    { Position.TopRight, null},
            { Position.MidLeft , null},   { Position.Mid, null},       { Position.MidRight, null},
            { Position.BottomLeft, null}, { Position.BottomMid, null}, { Position.BottomRight, null},
        };

        public void Play(Position position) {
            if (IsPositionAlreadyTaken(position))throw new InvalidPositionException();
            Board[position] = playerTurnSymbol;
            ChangePlayerTurn();
        }

        private bool IsPositionAlreadyTaken(Position position) {
            return Board[position] == Player.X || Board[position] == Player.O;
        }

        private void ChangePlayerTurn() {
            playerTurnSymbol = playerTurnSymbol switch {
                Player.X => Player.O,
                Player.O => Player.X,
                _ => playerTurnSymbol
            };
        }

        public string GetWinner() {
            if (PlayerWon(Player.X)) {
                return "X Won";
            } 
            if (PlayerWon(Player.O)) {
                return "O Won";
            }
            return "Its a draw";
        }

        private bool PlayerWon(Player player) {
            return PlayerWonFirstColumn(player) || PlayerWonSecondColumn(player) || PlayerWonLastColumn(player)
                   || PlayerWonFirstRow(player) || PlayerWonSecondRow(player) || PlayerWonLastRow(player)
                   || PlayerWonLeftDiagonal(player) || PlayerWonRightDiagonal(player);
        }

        private bool PlayerWonLeftDiagonal(Player player) {
            return PositionPlayedBy(Position.TopLeft, player) && PositionPlayedBy(Position.Mid, player) && PositionPlayedBy(Position.BottomRight, player);
        }

        private bool PlayerWonRightDiagonal(Player player) {
            return PositionPlayedBy(Position.TopRight, player) && PositionPlayedBy(Position.Mid, player) && PositionPlayedBy(Position.BottomLeft, player);
        }

        private bool PlayerWonFirstRow(Player player) {
            return PositionPlayedBy(Position.TopLeft, player) && PositionPlayedBy(Position.TopMid, player) && PositionPlayedBy(Position.TopRight, player);
        }

        private bool PlayerWonSecondRow(Player player) {
            return PositionPlayedBy(Position.MidLeft, player) && PositionPlayedBy(Position.Mid, player) && PositionPlayedBy(Position.MidRight, player);
        }

        private bool PlayerWonLastRow(Player player) {
            return PositionPlayedBy(Position.BottomLeft, player) && PositionPlayedBy(Position.BottomMid, player) && PositionPlayedBy(Position.BottomRight, player);
        }

        private bool PlayerWonFirstColumn(Player player) {
            return PositionPlayedBy(Position.TopLeft, player) && PositionPlayedBy(Position.MidLeft, player) && PositionPlayedBy(Position.BottomLeft, player);
        }

        private bool PlayerWonSecondColumn(Player player) {
            return PositionPlayedBy(Position.TopMid, player) && PositionPlayedBy(Position.Mid, player) && PositionPlayedBy(Position.BottomMid, player);
        }

        private bool PlayerWonLastColumn(Player player) {
            return PositionPlayedBy(Position.TopRight, player) && PositionPlayedBy(Position.MidRight, player) && PositionPlayedBy(Position.BottomRight, player);
        }

        private bool PositionPlayedBy(Position position, Player player) {
            return Board[position] == player;
        }
    }
}