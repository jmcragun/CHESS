using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    class Board
    {
        public Dictionary<string, BoardSpace> GameState;
        public Dictionary<string, Piece[]> ActivePieces;
    }

    internal class BoardSpace
    {
        public char Color { get; }
        public Piece Occupant;
        
        public BoardSpace(char color)
        {
            this.Color = color;
        }

        public bool IsOccupied()
        {
            return Occupant == null;
        }

        /// <summary>
        /// Converts a pawn into a queen at the specified location
        /// </summary>
        /// <param name="location"></param>
        public void ConvertPawn(string location)
        {
            if (Occupant != null && Occupant.Type == 'P') Occupant = new Piece('Q', Color, location);
        }

        /// <summary>
        /// Indicates if there is an occupant that is a foe to the given color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool ContainsFoe(char color)
        {
            return Occupant != null && color != Occupant.Color;
        }
    }
}
