using System;
namespace Assn2 {
    public class Square {

        private bool occupied { get; set; } = false;

        public string identifier { get; set; } = " ";

        public Square() {
            //this.occupied = false;
        }

        public bool PickSquare(string identifier){
            if (this.occupied) { return false; } else {
                this.identifier = identifier;
                this.occupied = true;
                return true;
            }
        }

        public bool isOccupied(){
            return this.occupied;
        }
    }
}
