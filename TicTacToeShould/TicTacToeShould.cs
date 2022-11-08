using FluentAssertions;
using NUnit.Framework;

namespace TicTacToeShould {
    public class TicTacToeShould{
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
        public void METHOD() {
            var game = new TicTacToeGame();
            
            game.Play('X',1, 1);

            game.Board[1, 1].Should().Be('X');
        }
    }

    public class TicTacToeGame {
        public char [,] Board { get;}

        public TicTacToeGame() {
            Board = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        public void Play(char c, int x, int y) {
            
        }
    }
}
