using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    /// <summary>
    /// Represents a game piece is chess, like a rook, or a pawn
    /// </summary>
    class Piece
    {
        /// <summary>
        /// Denotes the type of piece. R - rook, B - bishop, N - knight, K - king, Q - queen, P - pawn
        /// </summary>
        public char Type { get; }

        public char Color { get; }

        /// <summary>
        /// The piece's location. Consists of a single letter and number.
        /// </summary>
        public string Location { get { return loc; } }
        private string loc;

        private bool HasMoved;

        public Piece(char type, char color, string location)
        {
            Type = type;
            loc = location;
            Color = color;
            HasMoved = false;
        }

        /// <summary>
        /// Gets the possible moves of this piece
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GetMoves(Dictionary<string, BoardSpace> GameState)
        {
            BoardSpace space;
            char column = Location[0];
            char row = Location[1];
            char foe = (Color == 'W') ? 'B' : 'W';
            HashSet<string> moves = new HashSet<string>();
            // Possible pawn moves
            if (Type == 'P')
            {
                // White pawns go upwards on the board, black ones go down
                int dir = (Color == 'W') ? 1 : -1;
                if (!HasMoved)
                {
                    char farRow = (char)(row + 2 * dir);
                    string newLoc = column + "" + farRow;
                    // If the space isn't present in the dictionary, or the space is not occupied, we can go there
                    if (!GameState.TryGetValue(newLoc, out space) || !space.IsOccupied())
                    {
                        moves.Add(newLoc);
                    }
                }
                // These are the possible new coords
                char newRow = (char)(row + 1 * dir);
                char leftCol = (char)(column - 1);
                char rightCol = (char)(column + 1);
                if (newRow < '9' && newRow > '0')
                {
                    // Check to see if the pawn can move one space forward
                    string newLoc = column + "" + newRow;
                    if (!GameState.TryGetValue(newLoc, out space) || !space.IsOccupied())
                    {
                        moves.Add(newLoc);
                    }
                    // Check to see if it can kill any foes
                    newLoc = leftCol + "" + newRow;
                    if (leftCol >= 'A' && GameState.TryGetValue(newLoc, out space) && space.ContainsFoe(foe))
                    {
                        moves.Add(newLoc);
                    }
                    newLoc = rightCol + "" + newRow;
                    if (rightCol <= 'H' && GameState.TryGetValue(newLoc, out space) && space.ContainsFoe(foe))
                    {
                        moves.Add(newLoc);
                    }
                }
            }
            // Possible rook moves
            else if (Type == 'R')
            {

                // First go up the board
                int radius = 1;
                char newRow = (char)(row + radius);
                string newLoc = column + "" + newRow;

                while (newRow < '9' && (!GameState.TryGetValue(newLoc, out space) || space.Occupant == null || space.ContainsFoe(foe)))
                {
                    // If the above condition is met, add it to the possible move collection
                    // Then increase the radius and reassign newRow and newLoc
                    moves.Add(newLoc);
                    ++radius;
                    newRow = (char)(row + radius);
                    newLoc = column + "" + newRow;
                }

                // Then go down the board
                radius = 1;
                newRow = (char)(row - radius);
                newLoc = column + "" + newRow;

                while (newRow > '0' && (!GameState.TryGetValue(newLoc, out space) || space.Occupant == null || space.ContainsFoe(foe)))
                {
                    // If the above condition is met, add it to the possible move collection
                    // Then increase the radius and reassign newRow and newLoc
                    moves.Add(newLoc);
                    ++radius;
                    newRow = (char)(row - radius);
                    newLoc = column + "" + newRow;
                }

                // Then go left

                // Then go right
            }
            // Possible bishop moves
            else if (Type == 'B') { }
            // Possible knight moves
            else if (Type == 'N') { }
            // Possible queen moves
            else if (Type == 'Q') { }
            // Possible king moves
            else
            {

            }
            return moves;
        }

        public void Move(string location)
        {
            loc = location;
            HasMoved = true;
        }
    }
}
