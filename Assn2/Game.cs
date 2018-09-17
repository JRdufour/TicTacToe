using System;
namespace Assn2 {
    public class Game {

        private GameBoard board;
        private Player player1;
        private Player player2;
        private Player active;
        //these numbers represent the winning combinations of squares a player could have
        private long[] winningNumbers = {
            448,56,7,292,146,73,273,84
        };

        const string player1Identifier = "X";
        const string player2Identifier = "O";

        public Game() {
            board = new GameBoard();
            player1 = new Player(player1Identifier, "Player 1");
            player2 = new Player(player2Identifier, "Player 2");

            active = player1;
        }

        public void Play(){
            Console.WriteLine("Welcome to Tic Tac Toe!");
            var completed = false;
            bool valid;
            do {
                board.GenerateBoard();
                int squareChoice;
                do {
                    valid = false;
                    //have the active player take a turn
                    squareChoice = active.TakeTurn();

                    //notify the game board of the player's choice
                    valid = board.ChooseSquare(squareChoice, active.identifier);
                } while (!valid);

                active.takeSquare(squareChoice);
                //check to see if there was a winning combo
                if(CheckWin()){
                    board.GenerateBoard();
                    Console.WriteLine($"{active.name} has won!");
                    completed = true;
                }
                if(board.boardFull()){
                    Console.WriteLine("The Game is a tie!");
                }

                //if not, toggle the active player
                ToggleActivePlayer();
            } while (!completed);
            //game was completed - ask to play agian

        }



        public void ToggleActivePlayer(){
            if(active == player1){
                active = player2;
            } else if(active == player2){
                active = player1;
            }
        }


        public bool CheckWin(){
            //onsole.WriteLine("Checking Win");
            //get the sum of the squares taken by the player
            var squaresBitValue = active.GetBitTotal();

            foreach(int winNum in winningNumbers){

              //  Console.WriteLine($"");
                //checks the player's current square total with the winning values in the array using bitwise AND operator
                int winChk  = winNum & squaresBitValue;
                if(winChk == winNum){
                    //if the players squares add to a winning number, a winning combinations is found
                    return true;
                }
            }
            return false;
        }
    }
}
