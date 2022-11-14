using FluentAssertions;
using NUnit.Framework;
using TicTacToeKata;

namespace TicTacToeShould {
    public class TicTacToeShould{
        [Test]
        public void set_mark_for_first_player() {
            var game = new TicTacToeGame();

            game.Play(Position.Mid);

            game.Board[Position.Mid].Should().Be(Player.X);
        }

        [Test]
        public void set_mark_for_second_player() {
            var game = new TicTacToeGame();
            game.Play(Position.Mid);

            game.Play(Position.TopLeft);

            game.Board[Position.TopLeft].Should().Be(Player.O);
        }

        [Test]
        public void throw_an_exception_if_cell_is_already_taken() {
            var game = new TicTacToeGame();
            game.Play(Position.Mid);

            var act = () => game.Play(Position.Mid);

            act.Should().Throw<InvalidPositionException>().WithMessage("The cell is already taken");
        }
        
        [Test]
        public void let_players_play_alternatively() {
            var game = new TicTacToeGame();
            game.Play(Position.TopLeft);
            game.Play(Position.Mid);

            var act = () => game.Play(Position.BottomLeft);

            act.Should().NotThrow<InvalidPositionException>();
        }

        [Test]
        public void set_draw_if_any_player_cant_align_three_marks() {
            var game = new TicTacToeGame();

            game.Play(Position.TopLeft); 
            game.Play(Position.TopMid); 
            game.Play(Position.TopRight);
            game.Play(Position.Mid);
            game.Play(Position.MidLeft);
            game.Play(Position.MidRight);
            game.Play(Position.BottomMid);
            game.Play(Position.BottomLeft);
            game.Play(Position.BottomRight);

            game.GetWinner().Should().Be("Its a draw");
        }

        [Test]
        public void set_first_player_win_if_gets_three_marks_in_the_first_column() {
            var game = new TicTacToeGame();

            game.Play(Position.TopLeft);
            game.Play(Position.Mid);
            game.Play(Position.MidLeft);
            game.Play(Position.MidRight);
            game.Play(Position.BottomLeft);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_second_column() {
            var game = new TicTacToeGame();

            game.Play(Position.TopMid);
            game.Play(Position.TopLeft);
            game.Play(Position.Mid);
            game.Play(Position.MidRight);
            game.Play(Position.BottomMid);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_last_column() {
            var game = new TicTacToeGame();

            game.Play(Position.TopRight);
            game.Play(Position.TopLeft);
            game.Play(Position.MidRight);
            game.Play(Position.BottomLeft);
            game.Play(Position.BottomRight);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_first_row() {
            var game = new TicTacToeGame();

            game.Play(Position.TopLeft);
            game.Play(Position.Mid);
            game.Play(Position.TopMid);
            game.Play(Position.BottomMid);
            game.Play(Position.TopRight);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_second_row() {
            var game = new TicTacToeGame();

            game.Play(Position.MidLeft);
            game.Play(Position.TopLeft);
            game.Play(Position.Mid);
            game.Play(Position.BottomLeft);
            game.Play(Position.MidRight);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_last_row() {
            var game = new TicTacToeGame();

            game.Play(Position.BottomLeft);
            game.Play(Position.TopLeft);
            game.Play(Position.BottomMid);
            game.Play(Position.Mid);
            game.Play(Position.BottomRight);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_left_diagonal() {
            var game = new TicTacToeGame();

            game.Play(Position.TopLeft);
            game.Play(Position.TopMid);
            game.Play(Position.Mid);
            game.Play(Position.TopRight);
            game.Play(Position.BottomRight);

            game.GetWinner().Should().Be("X Won");
        }
        
        [Test]
        public void set_first_player_win_if_gets_three_marks_the_right_diagonal() {
            var game = new TicTacToeGame();

            game.Play(Position.TopRight);
            game.Play(Position.MidRight);
            game.Play(Position.Mid);
            game.Play(Position.TopLeft);
            game.Play(Position.BottomLeft);

            game.GetWinner().Should().Be("X Won");
        }
        
    }
}
