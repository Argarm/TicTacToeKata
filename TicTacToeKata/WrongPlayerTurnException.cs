using System;

namespace TicTacToeKata {
    public class WrongPlayerTurnException : Exception {
        public WrongPlayerTurnException() : base ("Its not your turn") {
            
        }
    }
}