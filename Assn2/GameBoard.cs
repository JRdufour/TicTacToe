using System;
namespace Assn2 {
    public class GameBoard {

        Square square0;
        Square square1;
        Square square2;
        Square square3;
        Square square4;
        Square square5;
        Square square6;
        Square square7;
        Square square8;

        Square[] squareArray;


        public GameBoard() {
            square0 = new Square();
            square1 = new Square();
            square2 = new Square();
            square3 = new Square();
            square4 = new Square();
            square5 = new Square();
            square6 = new Square();
            square7 = new Square();
            square8 = new Square();

            squareArray = new Square[]{
                square0, square1, square2, square3, square4, square5, square6, square7, square8
            };
        }


        public void GenerateBoard(){
            Console.WriteLine($" {square0.identifier} | {square1.identifier} | {square2.identifier} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {square3.identifier} | {square4.identifier} | {square5.identifier} ");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {square6.identifier} | {square7.identifier} | {square8.identifier} ");
           
        }

        public bool ChooseSquare(int position, string identifier){

            Square chosenSquare = squareArray[position];
            if(chosenSquare.PickSquare(identifier)){
                //square was available
                return true;
            } else {
                //the square was unavailable
                Console.WriteLine("Sorry, that square is not available");
                return false;
            }
        }

        public bool boardFull(){
            var full = true;
            foreach (Square s in squareArray){
                if(s.isOccupied()) {
                    full = false;
                }
            }

            return full;
        }
    }
}
