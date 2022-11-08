using FluentAssertions;
using NUnit.Framework;
using TicTacToeKata;

namespace TicTacToeShould {
    public class TicTacToeShould{
        [Test]
        public void set_mark_for_first_player() {
            var game = new TicTacToeGame();
            var xPosition = 1;
            var yPosition = 1;

            game.Play(xPosition, yPosition);

            game.Board[xPosition, yPosition].Should().Be(Player.X);
        }

        [Test]
        public void set_mark_for_second_player() {
            var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;
            game.Play(1,1);

            game.Play(xPosition, yPosition);

            game.Board[xPosition, yPosition].Should().Be(Player.O);
        }

        [Test]
        public void throw_an_exception_if_cell_is_already_taken() {
            var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;
            game.Play(xPosition, yPosition);

            var act = () => game.Play(xPosition, yPosition);

            act.Should().Throw<InvalidPositionException>().WithMessage("The cell is already taken");
        }
        
        [Test]
        public void let_players_play_alternatively() {
            var game = new TicTacToeGame();
            game.Play(0,0 );
            game.Play(0, 1);
            game.Play(0, 2);

            var act = () => game.Play(0, 0);

            act.Should().Throw<InvalidPositionException>().WithMessage("The cell is already taken");
        }

        [Test]
        public void set_draw_if_any_player_cant_align_three_marks() {
            var game = new TicTacToeGame();

            game.Play(0, 0); 
            game.Play(0, 1); 
            game.Play(0, 2);
            game.Play(1, 1);
            game.Play(1, 0);
            game.Play(2, 0);
            game.Play(1, 2);
            game.Play(2, 2);
            game.Play(2, 1);

            game.GetWinner().Should().Be("Its a draw");
        }

        [Test]
        public void set_first_player_win_if_gets_three_marks_in_the_first_column() {
            var game = new TicTacToeGame();

            game.Play(0, 0);
            game.Play(1, 1);
            game.Play(0, 1);
            game.Play(1, 2);
            game.Play(0, 2);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_second_column() {
            var game = new TicTacToeGame();

            game.Play(0, 1);
            game.Play(0, 0);
            game.Play(1, 1);
            game.Play(1, 2);
            game.Play(2, 1);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_last_column() {
            var game = new TicTacToeGame();

            game.Play(0, 2);
            game.Play(0, 0);
            game.Play(1, 2);
            game.Play(2, 0);
            game.Play(2, 2);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_first_row() {
            var game = new TicTacToeGame();

            game.Play(0, 0);
            game.Play(1, 1);
            game.Play(0, 1);
            game.Play(2, 1);
            game.Play(0, 2);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_second_row() {
            var game = new TicTacToeGame();

            game.Play(1, 0);
            game.Play(0, 2);
            game.Play(1, 1);
            game.Play(2, 1);
            game.Play(1, 2);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_last_row() {
            var game = new TicTacToeGame();

            game.Play(2, 0);
            game.Play(0, 2);
            game.Play(2, 1);
            game.Play(0, 1);
            game.Play(2, 2);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_left_diagonal() {
            var game = new TicTacToeGame();

            game.Play(0, 0);
            game.Play(0, 2);
            game.Play(1, 1);
            game.Play(0, 1);
            game.Play(2, 2);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_right_diagonal() {
            var game = new TicTacToeGame();

            game.Play(0, 2);
            game.Play(1, 2);
            game.Play(1, 1);
            game.Play(0, 1);
            game.Play(2, 0);

            game.GetWinner().Should().Be("X Won");
        }
        
    }

    public class TicTacToeGame {
        private Player playerTurn = Player.X;

        public Player?[,] Board = new Player?[3, 3];

        public void Play(int x, int y) {
            if (Board[x,y] == Player.X || Board[x,y] == Player.O)throw new InvalidPositionException();
            Board[x, y] = playerTurn;
            ChangePlayerTurn();
        }

        private void ChangePlayerTurn() {
            if (playerTurn == Player.X) playerTurn = Player.O;
            else if (playerTurn == Player.O) playerTurn = Player.X;
        }

        public string GetWinner() {
            if (PlayerWon(Player.X)) {
                return "X Won";
            } if (PlayerWon(Player.O)) {
                return "O Won";
            }
            return "Its a draw";
        }

        private bool PlayerWon(Player player) {
            return PlayerWonFirstColumn(player) || PlayerWonSecondColumn(player) || PlayerWonLastColumn(player)
                   || PlayerWonFirstRow(player) || PlayerWonSecondRow(player) || PlayerWonLastRow(player)
                   || PlayerWonLeftDiagonal(player) || PlayerWonRightDiagonal(player);
        }

        private bool PlayerWonRightDiagonal(Player player) {
            return PositionPlayedBy(0, 2, player) && PositionPlayedBy(1, 1, player) && PositionPlayedBy(2, 0, player);
        }

        private bool PlayerWonLeftDiagonal(Player player) {
            return PositionPlayedBy(0, 0, player) && PositionPlayedBy(1, 1, player) && PositionPlayedBy(2, 2, player);
        }

        private bool PlayerWonFirstRow(Player player) {
            return PositionPlayedBy(0, 0, player) && PositionPlayedBy(1, 0, player) && PositionPlayedBy(2, 0, player);
        }

        private bool PlayerWonSecondRow(Player player) {
            return PositionPlayedBy(1, 0, player) && PositionPlayedBy(1, 1, player) && PositionPlayedBy(1, 2, player);
        }

        private bool PlayerWonLastRow(Player player) {
            return PositionPlayedBy(2, 0, player) && PositionPlayedBy(2, 1, player) && PositionPlayedBy(2, 2, player);
        }

        private bool PlayerWonLastColumn(Player player) {
            return PositionPlayedBy(0, 2, player) && PositionPlayedBy(1, 2, player) && PositionPlayedBy(2, 2, player);
        }

        private bool PlayerWonSecondColumn(Player player) {
            return PositionPlayedBy(0, 1, player) && PositionPlayedBy(1, 1, player) && PositionPlayedBy(2, 1, player);
        }

        private bool PlayerWonFirstColumn(Player player) {
            return PositionPlayedBy(0, 0, player) && PositionPlayedBy(0, 1, player) && PositionPlayedBy(0, 2, player);
        }

        private bool PositionPlayedBy(int x, int y, Player player) {
            return Board[x, y] == player;
        }
    }
}
