using System;

namespace Assn2 {
    public class Player {

        public string identifier { get; set; }

        public string name { get;}

        private int[] playerSquareArray { get; set; } = {0,0,0,0,0,0,0,0,0};
   
        public Player(string identifier) {
            this.identifier = identifier;
        }

        public Player(string identifier, string name){
            this.identifier = identifier;
            this.name = name;
        }

        public int TakeTurn() {
            int squarePos = -1;

            do {
                Console.WriteLine($"{this.name} Please select a square");
                string choice = Console.ReadLine();
                
                if (Int32.TryParse(choice, out squarePos)) {
                    Console.WriteLine($"TEST -- Number pressed: {squarePos}");
                    squarePos--;
                    if (squarePos < 0 || squarePos > 8) {
                        //invalid
                        Console.WriteLine("Invalid selection, try again");
                        squarePos = -1;
                    }
                } else {
                    //invaid
                    Console.WriteLine("Invalid selection, try again");
                    squarePos = -1;
                }
            } while (squarePos==-1);

            return squarePos;

        }

        public void takeSquare(int squarePosition){
            //squarePosition is the position of the square chosen numbered 1-9
            //the playerSquareArray represents the squares labelled the oppoite direction
            playerSquareArray[squarePosition] = 1;

        }

        public int GetBitTotal(){
            var total = 0;
            var bitVal = (int) Math.Pow(2, playerSquareArray.Length-1);

            for (int i = 0; i < playerSquareArray.Length; i++) {
                if (playerSquareArray[i] == 1) { total += bitVal; }
                bitVal /= 2;
            }

            return total;
        }
    }
}
