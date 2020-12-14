using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._ThePianist
{
    public class Piece
    {
        public string PieceName { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece(string pieceName, string composer, string key)
        {
            this.PieceName = pieceName;
            this.Composer = composer;
            this.Key = key;
        }

        public override string ToString()
        {
            return $"{this.PieceName} -> Composer: {this.Composer}, Key: {this.Key}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Piece piece = new Piece(tokens[0], tokens[1], tokens[2]);
                pieces.Add(piece);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] commands = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Piece piece = null;

                if (pieces.Select(x => x.PieceName).Contains(commands[1]))
                {
                    piece = pieces.Where(x => x.PieceName == commands[1]).FirstOrDefault();
                }
                
                switch (commands[0])
                {
                    case "Add":

                        if (piece == null)
                        {
                            var pieceToAdd = new Piece(commands[1], commands[2], commands[3]);
                            pieces.Add(pieceToAdd);
                            Console.WriteLine($"{pieceToAdd.PieceName} by {pieceToAdd.Composer} in {pieceToAdd.Key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece.PieceName} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieces.Contains(piece))
                        {
                            pieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece.PieceName}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        if (pieces.Contains(piece))
                        {
                            piece.Key = commands[2];
                            Console.WriteLine($"Changed the key of {piece.PieceName} to {piece.Key}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
                        }
                        break;
                }
            }

            foreach (var piece in pieces.OrderBy(x => x.PieceName).ThenBy(x => x.Composer))
            {
                Console.WriteLine(piece.ToString());
            }
        }
    }
}
