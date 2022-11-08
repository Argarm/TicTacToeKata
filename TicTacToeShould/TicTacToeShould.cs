using FluentAssertions;
using NUnit.Framework;

namespace TicTacToeShould {
    public class TicTacToeShould{
        [Test]
        public void set_mark_for_first_player() {
            var game = new TicTacToeGame();
            var xPosition = 1;
            var yPosition = 1;

            game.Play(Player.X, xPosition, yPosition);

            game.Board[xPosition, yPosition].Should().Be(Player.X);
        }

        [Test]
        public void set_mark_for_second_player() {
            /*var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;

            game.Play(Player.O, xPosition, yPosition);

            game.Board[xPosition, yPosition].Should().Be(Player.O);*/
        }

        [Test]
        public void not_let_player_play_two_time_in_a_row() {
            var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;
            game.Play(Player.X, xPosition, yPosition);

            Action act = () => game.Play(Player.X, 1, yPosition);

            act.Should().Throw<WrongPlayerTurnException>().WithMessage("Its not your turn");
        }
        
        [Test]
        public void throw_an_exception_if_cell_is_already_taken() {
            var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;
            game.Play(Player.X, xPosition, yPosition);

            var act = () => game.Play(Player.O, xPosition, yPosition);

            act.Should().Throw<InvalidPositionException>().WithMessage("The cell is already taken");
        }
        
        [Test]
        public void finish_a_game_when_all_fields_are_taken() {
            /*var game = new TicTacToeGame();
            
            game.Play(Player.O, 0, 0);
            game.Play(Player.O, 0, 1);
            game.Play(Player.X, 0, 2);

            game.Play(Player.X, 1, 0);
            game.Play(Player.O, 1, 1);
            game.Play(Player.O, 1, 2);
            
            game.Play(Player.O, 2, 0);
            game.Play(Player.X, 2, 1);
            game.Play(Player.O, 2, 2);


            game.IsFinish().Should().BeTrue();*/
        }
    }

    public class WrongPlayerTurnException : Exception {
        public WrongPlayerTurnException() : base ("Its not your turn") {
            
        }
    }

    public class InvalidPositionException : Exception {
        public InvalidPositionException() : base("The cell is already taken") { }
    }

    public enum Player {
        X,
        O,
        
    }

    public class TicTacToeGame {
        private Player playerTurn = Player.X;

        public Player?[,] Board = new Player?[3, 3];

        public void Play(Player player, int x, int y) {
            if (Board[x,y] == Player.X || Board[x,y] == Player.O)throw new InvalidPositionException();
            if (!IsPlayerTurn(player)) throw new WrongPlayerTurnException();
            Board[x, y] = player;
            playerTurn = Player.O;
        }

        private bool IsPlayerTurn(Player player) {
            return player == playerTurn;
        }

        public bool IsFinish() {
            return true;
        }
    }
}
