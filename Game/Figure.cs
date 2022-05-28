using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game
{
    public class Figure
    {
        public Bitmap Image;
        public Player PlayerColor;
        public Point Position;
        public Point FormLocation => 
            new Point(Position.Y * GameCode.FieldSize.Width, Position.X * GameCode.FieldSize.Height);
        public Pieces FigureName;
        public List<Point> PossibleMoves;

        public Figure(int figureId, Player playerColor, Point position)
        {
            FigureName = (Pieces)figureId;
            PlayerColor = playerColor;
            Position = position;
            if (figureId != 0)
                Image = playerColor == Player.White ? 
                    WhiteSprites.WhiteFig(figureId) : BlackSprites.BlackFig(figureId);
        }

        public Figure(Figure figure)
        {
            FigureName = figure.FigureName;
            PlayerColor = figure.PlayerColor;
            Position = figure.Position;
            Image = figure.Image;
        }

        public enum Pieces
        {
            Empty,
            Pawn,   //Пешка
            Knight, //Конь
            Bishop, //Слон
            Rook,   //Ладья
            Queen,  //Ферзь
            King    //Король
        }

        public string NameToLetter()
        {
            return FigureName switch
            {
                Pieces.Empty => "",
                Pieces.Pawn => "",
                Pieces.Knight => "N",
                Pieces.Bishop => "B",
                Pieces.Rook => "R",
                Pieces.Queen => "Q",
                _ => "K"
            };
        }

        private Point NewPoint(Point point) => new Point(point.X, point.Y);

        public void MoveFigureTo(Figure swapFigure)
        {
            GameCode.GameField[swapFigure.Position.X, swapFigure.Position.Y] = this;
            GameCode.GameField[Position.X, Position.Y] = new Figure(0, 0, NewPoint(Position));
            this.Position = NewPoint(swapFigure.Position);
        }

        private Point Move(int x, int y)
        {
            if (PlayerColor == Player.White)
                return new Point(Position.X - x, Position.Y + y);
            return new Point(Position.X + x, Position.Y + y);
        }

        private Figure GetFigureFromPosition(int x, int y)
        {
            if (PlayerColor == Player.White)
                return GameCode.GameField[Position.X - x, Position.Y + y];
            return GameCode.GameField[Position.X + x, Position.Y + y];
        }

        private bool CheckInBounds(int x, int y)
        {
            bool xInBound;
            if (PlayerColor == Player.White)
                xInBound = Position.X - x >= 0 &&
                           Position.X - x < 8;
            else
                xInBound = Position.X + x >= 0 &&
                           Position.X + x < 8;

            return Position.Y + y >= 0 &&
                   Position.Y + y < 8 &&
                   xInBound;
        }

        public void FindPossibleMoves()
        {
            PossibleMoves = new List<Point>();
            switch (FigureName)
            {
                case Pieces.Empty:
                    return;
                case Pieces.Pawn:
                    PawnMoves();
                    break;
                case Pieces.Knight:
                    KnightMoves();
                    break;
                case Pieces.Bishop:
                    BishopMoves();
                    break;
                case Pieces.Rook:
                    RookMoves();
                    break;
                case Pieces.Queen:
                    RookMoves();
                    BishopMoves();
                    break;
                case Pieces.King:
                    KingMoves();
                    break;
            }
        }

        private void PawnMoves()
        {
            var posDirections = new[] { (1, 1, 1), (1, -1, 1), (1, 0, 2), (2, 0, 3) };
            foreach (var el in posDirections)
            {
                if (!CheckInBounds(el.Item1, el.Item2)) continue;
                var figureOnPosition = GetFigureFromPosition(el.Item1, el.Item2);
                switch (el.Item3)
                {
                    case 1:
                        if (figureOnPosition.FigureName != Pieces.Empty &&
                            figureOnPosition.PlayerColor != PlayerColor)
                            PossibleMoves.Add(Move(el.Item1, el.Item2));
                        break;
                    case 2:
                        if (figureOnPosition.FigureName == Pieces.Empty)
                            PossibleMoves.Add(Move(el.Item1, el.Item2));
                        break;
                    case 3:
                        if (Position.X == 1 || Position.X == 6)
                            if (figureOnPosition.FigureName == Pieces.Empty)
                                PossibleMoves.Add(Move(el.Item1, el.Item2));
                        break;
                }
            }
        }

        

        private void KnightMoves()
        {
            var posDirections = new[] { (2, -1), (2, 1), (1, -2), (1, 2),
                (-1, -2), (-1, 2), (-2, -1), (-2, 1) };

            foreach (var el in posDirections)
            {
                if (!CheckInBounds(el.Item1, el.Item2)) continue;
                var figureOnPosition = GetFigureFromPosition(el.Item1, el.Item2);

                if (figureOnPosition.FigureName != Pieces.King &&
                    figureOnPosition.PlayerColor != PlayerColor)
                    PossibleMoves.Add(Move(el.Item1, el.Item2));
            }
        }

        private void BishopMoves()
        {
            var boolList = new bool[4];
            foreach (var el in new[] { 1, 2, 3, 4, 5, 6, 7 })
            {
                if (boolList.All(b => b)) break;
                if (!boolList[0]) LinearMove(el, -el, boolList, 0);
                if (!boolList[1]) LinearMove(el, el, boolList, 1);
                if (!boolList[2]) LinearMove(-el, -el, boolList, 2);
                if (!boolList[3]) LinearMove(-el, el, boolList, 3);
            }
        }

        private void RookMoves()
        {
            var boolList = new bool[4];
            foreach (var el in new[] { 1, 2, 3, 4, 5, 6, 7 })
            {
                if (boolList.All(b => b)) break;
                if (!boolList[0]) LinearMove(-el, 0, boolList, 0);
                if (!boolList[1]) LinearMove(el, 0, boolList, 1);
                if (!boolList[2]) LinearMove(0, -el, boolList, 2);
                if (!boolList[3]) LinearMove(0, el, boolList, 3);
            }
        }

        private void KingMoves()
        {
            var directions = new[] { (1, -1), (1, 0), (1, 1), (0, -1),
                                    (-1, -1), (-1, 0), (-1, 1), (0, 1) };
            foreach (var el in directions)
            {
                if (!CheckInBounds(el.Item1, el.Item2)) continue;
                var figureOnPosition = GetFigureFromPosition(el.Item1, el.Item2);
                if (figureOnPosition.FigureName != Pieces.King &&
                    figureOnPosition.PlayerColor != PlayerColor)
                    PossibleMoves.Add(Move(el.Item1, el.Item2));
            }
        }

        private void LinearMove(int x, int y, bool[] boolList, int i)
        {
            if (CheckInBounds(x, y))
            {
                var figureOnPosition = GetFigureFromPosition(x, y);

                if (figureOnPosition.PlayerColor == PlayerColor) boolList[i] = true;

                else if (figureOnPosition.PlayerColor == Player.Empty)
                    PossibleMoves.Add(Move(x, y));
                else if (figureOnPosition.FigureName != Pieces.King)
                {
                    PossibleMoves.Add(Move(x, y));
                    boolList[i] = true;
                }
            }
            else
                boolList[i] = true;
        }
    }
}