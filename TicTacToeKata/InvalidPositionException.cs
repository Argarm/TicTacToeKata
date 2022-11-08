using System;

namespace TicTacToeKata {
    public class InvalidPositionException : Exception {
        public InvalidPositionException() : base("The cell is already taken") { }
    }
}