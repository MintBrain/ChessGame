using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Game
{
    public static class GameCode
    {
        public static Figure[,] GameField;
        private static List<string[]> Variants;
        private static List<int> Played;
        public static List<List<string>> CurGuess;
        public static string[] CurVariant;
        public static int CurrentAttempt;

        public static void Chess()
        {
            var varPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "variants.txt");
            var fileLines = File.ReadLines(varPath);
            Variants = fileLines.Select(s => s.Split()).Where(l => l.Length == 6).ToList();
            Played = new List<int>(); 
        }

        private static string[] RandomVariant()
        {
            Random rnd = new Random();
            if (Played.Count == Variants.Count)
                Played = new List<int>();
            while (true)
            {
                var newVarId = rnd.Next(Variants.Count);
                if (!Played.Contains(newVarId))
                {
                    Played.Add(newVarId);
                    return Variants[newVarId];
                }
            }
        }

        public static void NewGame()
        {
            CurGuess = new List<List<string>>();
            CurGuess.Add(new List<string>());
            CurrentAttempt = 0;
            CurVariant = RandomVariant();
            CreateField();
        }

        public static void AddMove(Figure oldFigure, Figure curFigure)
        {
            if (oldFigure.FigureName == Figure.Pieces.Pawn && 
                curFigure.FigureName == Figure.Pieces.Pawn)
                CurGuess[CurrentAttempt].Add(XtoString(oldFigure.Position.Y + 1) + "x" +
                                             XtoString(curFigure.Position.Y + 1) +
                                             (8 - curFigure.Position.X));
            else
                CurGuess[CurrentAttempt].Add(oldFigure.NameToLetter() + 
                                             XtoString(curFigure.Position.Y + 1) + 
                                             (8 - curFigure.Position.X));

        }

        public static void CreateField()
        {
            GameField = new Figure[8, 8];
            var gameField = new int[,]
            {
                {14, 12, 13, 15, 16, 13, 12, 14},
                {11, 11, 11, 11, 11, 11, 11, 11},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {21, 21, 21, 21, 21, 21, 21, 21},
                {24, 22, 23, 25, 26, 23, 22, 24}
            };
            
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                {
                    var player = (Player) (gameField[i, j] / 10);
                    var figN = gameField[i, j] % 10;

                    GameField[i, j] = new Figure(figN, player, new Point(i,j));
                }
        }

        private static string XtoString(int x)
        {
            return x switch
            {
                1 => "a",
                2 => "b",
                3 => "c",
                4 => "d",
                5 => "e",
                6 => "f",
                7 => "g",
                _ => "h"
            };
        }
    }
}