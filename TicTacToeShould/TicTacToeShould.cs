using FluentAssertions;
using NUnit.Framework;

namespace TicTacToeShould {
    public class TicTacToeShould{
        private const char SecondPlayerMark = 'O';
        private const char FirstPlayerMark = 'X';

        [Test]
        public void have_initial_board_without_marks() {
            var game = new TicTacToeGame();

            game.Board[0, 0].Should().Be('1');
            game.Board[0, 1].Should().Be('2');
            game.Board[0, 2].Should().Be('3');
            game.Board[1, 0].Should().Be('4');
            game.Board[1, 1].Should().Be('5');
            game.Board[1, 2].Should().Be('6');
            game.Board[2, 0].Should().Be('7');
            game.Board[2, 1].Should().Be('8');
            game.Board[2, 2].Should().Be('9');
        }

        [Test]
        public void set_mark_for_first_player() {
            var game = new TicTacToeGame();
            var xPosition = 1;
            var yPosition = 1;

            game.Play(FirstPlayerMark,xPosition, yPosition);

            game.Board[xPosition, yPosition].Should().Be(FirstPlayerMark);
        }

        [Test]
        public void set_mark_for_second_player() {
            var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;

            game.Play(SecondPlayerMark,xPosition,yPosition);

            game.Board[xPosition, yPosition].Should().Be(SecondPlayerMark);
        }
        
        [Test]
        public void throw_an_exception_if_cell_is_already_taken() {
            var game = new TicTacToeGame();
            var xPosition = 0;
            var yPosition = 0;
            game.Play(FirstPlayerMark,xPosition,yPosition);

            var act = () => game.Play(SecondPlayerMark,xPosition,yPosition);

            act.Should().Throw<InvalidPositionException>().WithMessage("The cell is already taken");
        }
    }

    public class InvalidPositionException : Exception {
        public InvalidPositionException() : base("The cell is already taken") { }
    }

    public class TicTacToeGame {
        private const char SecondPlayerMark = 'O';
        private const char FirstPlayerMark = 'X';
        public char [,] Board { get;}

        public TicTacToeGame() {
            Board = new[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        public void Play(char c, int x, int y) {
            if (Board[x,y] == FirstPlayerMark || Board[x,y] == SecondPlayerMark)throw new InvalidPositionException();
            Board[x, y] = c;
        }
    }
}
