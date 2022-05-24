
//for (var i = 0; i < 8; i++)
//for (var j = 0; j < 8; j++)
//{
//    Button figureButton = new Button();
//    figureButton.Size = new Size(50, 50);
//    figureButton.Location = new Point(j * 50, i * 50);
//    if (Map[i,j] != 0)
//        figureButton.Image = FigureImage(Map[i, j]);
//    switch ((i + j) % 2)
//    {
//        case 0:
//            figureButton.BackColor = Color.FromArgb(240, 217, 181);
//            break;
//        case 1:
//            figureButton.BackColor = Color.FromArgb(181, 135, 96);
//            break;
//    }
//    figureButton.FlatStyle = FlatStyle.Flat;
//    figureButton.FlatAppearance.BorderColor = Color.White;
//    figureButton.FlatAppearance.BorderSize = 0;
//    figureButton.Click += new EventHandler(OnFigurePress);
//    this.Controls.Add(figureButton);
//}

//var CurPressedBut = sender as Button;

//if (OldPressedButton != null)
//    OldPressedButton.FlatAppearance.BorderSize = 0;

//if (Map[CurPressedBut.Location.Y / 50, CurPressedBut.Location.X / 50] != 0 &&
//    Map[CurPressedBut.Location.Y / 50, CurPressedBut.Location.X / 50] / 10 == (int)CurPlayer)
//{
//    CurPressedBut.FlatAppearance.BorderSize = 2;
//    FigurePressed = true;
//}
//else
//{
//    if (FigurePressed)
//    {
//        Map[CurPressedBut.Location.Y / 50, CurPressedBut.Location.X / 50] =
//            Map[OldPressedButton.Location.Y / 50, OldPressedButton.Location.X / 50];
//        Map[OldPressedButton.Location.Y / 50, OldPressedButton.Location.X / 50] = 0;
//        CurPressedBut.Image = OldPressedButton.Image;
//        OldPressedButton.Image = null;
//        FigurePressed = false;
//        SwitchPlayer();
//    }
//}
//OldPressedButton = CurPressedBut;

//public Bitmap FigureImage(int i)
//{
//    if (i / 10 == 1)
//        return BlackSprites.BlackFig(i % 10);
//    else
//        return WhiteSprites.WhiteFig(i % 10);
//}

//public class Pawn : Figure
//{
//    public Bitmap Image;
//    public Player PlayerColor;
//    public Point Position;
//    public Point FormLocation;

//    public Pawn(Player playerColor, Point position)
//    {
//        PlayerColor = playerColor;
//        Position = position;
//        Image = playerColor == Player.White ? WhiteSprites.Pawn : BlackSprites.Pawn;
//        FormLocation = new Point(position.Y * 50, position.X * 50);
//    }
//}

//public class Knight : Figure
//{
//    public Bitmap Image;
//    public Player PlayerColor;
//    public Point Position;
//    public Point FormLocation;

//    public Knight(Player playerColor, Point position)
//    {
//        PlayerColor = playerColor;
//        Position = position;
//        Image = playerColor == Player.White ? WhiteSprites.Knight : BlackSprites.Knight;
//        FormLocation = new Point(position.Y * 50, position.X * 50);
//    }
//}

//public class Bishop : Figure
//{
//    public Bitmap Image;
//    public Player PlayerColor;
//    public Point Position;
//    public Point FormLocation;

//    public Bishop(Player playerColor, Point position)
//    {
//        PlayerColor = playerColor;
//        Position = position;
//        Image = playerColor == Player.White ? WhiteSprites.Bishop : BlackSprites.Bishop;
//        FormLocation = new Point(position.Y * 50, position.X * 50);
//    }
//}

//public class Rook : Figure
//{
//    public Bitmap Image;
//    public Player PlayerColor;
//    public Point Position;
//    public Point FormLocation;

//    public Rook(Player playerColor, Point position)
//    {
//        PlayerColor = playerColor;
//        Position = position;
//        Image = playerColor == Player.White ? WhiteSprites.Rook : BlackSprites.Rook;
//        FormLocation = new Point(position.Y * 50, position.X * 50);
//    }
//}

//public class Queen : Figure
//{
//    public Bitmap Image;
//    public Player PlayerColor;
//    public Point Position;
//    public Point FormLocation;

//    public Queen(Player playerColor, Point position)
//    {
//        PlayerColor = playerColor;
//        Position = position;
//        Image = playerColor == Player.White ? WhiteSprites.Queen : BlackSprites.Queen;
//        FormLocation = new Point(position.Y * 50, position.X * 50);
//    }
//}

//public class King : Figure
//{
//    public Bitmap Image;
//    public Player PlayerColor;
//    public Point Position;
//    public Point FormLocation;

//    public King(Player playerColor, Point position)
//    {
//        PlayerColor = playerColor;
//        Position = position;
//        Image = playerColor == Player.White ? WhiteSprites.King : BlackSprites.King;
//        FormLocation = new Point(position.Y * 50, position.X * 50);
//    }
//}

//if (PlayerColor == Player.White)
//{
//    if (GetFigureFromPosition(-1,1).FigureName != Pieces.Empty)
//        PossibleMoves.Add(Move(1,-1));
//    if (GetFigureFromPosition(-1, -1).FigureName != Pieces.Empty)
//        PossibleMoves.Add(Move(-1,-1));

//    if (GameCode.GameField[Position.Y - 1, Position.X].FigureName == Pieces.Empty)
//        PossibleMoves.Add(Move(0,-1));
//    if (Position.Y == 6)
//        if (GameCode.GameField[Position.Y - 2, Position.X].FigureName == Pieces.Empty)
//            PossibleMoves.Add(Move(0, -2));
//}
//else
//{

//var temp = curFigure.Position;
//var temp2 = oldFigure.Position;
//curFigure.Position =
//    oldFigure.Position;
//oldFigure.Position = curFigure.Position;

//if (GetFigureFromPosition(1, 1).FigureName != Pieces.Empty)
//    PossibleMoves.Add(Move(1, 1));
//if (GetFigureFromPosition(1, -1).FigureName != Pieces.Empty)
//    PossibleMoves.Add(Move(1, -1));

//if (GetFigureFromPosition(1, 0).FigureName == Pieces.Empty)
//    PossibleMoves.Add(Move(1, 0));
//if (Position.X == 1 || Position.X == 6)
//    if (GetFigureFromPosition(2, 0).FigureName == Pieces.Empty)
//        PossibleMoves.Add(Move(2, 0));

//var boolList = new bool[4];
//bool oneF = false;
//bool twoF = false;
//bool threeF = false;
//bool fourF = false;
//foreach (var el in new[] { (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7) })
//{
//    if (!oneF)
//    {
//        if (CheckInBounds(el.Item1, -el.Item2))
//        {
//            var figureOnPosition = GetFigureFromPosition(el.Item1, -el.Item2);

//            if (figureOnPosition.PlayerColor == PlayerColor) oneF = true;

//            else if (figureOnPosition.PlayerColor == Player.Empty)
//                PossibleMoves.Add(Move(el.Item1, -el.Item2));
//            else if (figureOnPosition.FigureName != Pieces.King)
//            {
//                PossibleMoves.Add(Move(el.Item1, -el.Item2));
//                oneF = true;
//            }
//        }
//        else
//            oneF = true;
//    }
//    if (!twoF)
//    {
//        if (CheckInBounds(el.Item1, el.Item2))
//        {
//            var figureOnPosition = GetFigureFromPosition(el.Item1, el.Item2);

//            if (figureOnPosition.PlayerColor == PlayerColor) twoF = true;
//            else if (figureOnPosition.PlayerColor == Player.Empty)
//                PossibleMoves.Add(Move(el.Item1, el.Item2));
//            else if (figureOnPosition.FigureName != Pieces.King)
//            {
//                PossibleMoves.Add(Move(el.Item1, el.Item2));
//                twoF = true;
//            }
//        }
//        else
//            twoF = true;
//    }
//    if (!threeF)
//    {
//        if (CheckInBounds(-el.Item1, -el.Item2))
//        {
//            var figureOnPosition = GetFigureFromPosition(-el.Item1, -el.Item2);

//            if (figureOnPosition.PlayerColor == PlayerColor) threeF = true;

//            else if (figureOnPosition.PlayerColor == Player.Empty)
//                PossibleMoves.Add(Move(-el.Item1, -el.Item2));
//            else if (figureOnPosition.FigureName != Pieces.King)
//            {
//                PossibleMoves.Add(Move(-el.Item1, -el.Item2));
//                threeF = true;
//            }
//        }
//        else
//            threeF = true;
//    }

//    if (!boolList[3])
//    {
//        //if (CheckInBounds(-el.Item1, el.Item2))
//        //{

//        //    var figureOnPosition = GetFigureFromPosition(-el.Item1, el.Item2);

//        //    if (figureOnPosition.PlayerColor == PlayerColor) fourF = true;

//        //    else if (figureOnPosition.PlayerColor == Player.Empty)
//        //        PossibleMoves.Add(Move(-el.Item1, el.Item2));
//        //    else if (figureOnPosition.FigureName != Pieces.King)
//        //    {
//        //        PossibleMoves.Add(Move(-el.Item1, el.Item2));
//        //        fourF = true;
//        //    }
//        //}
//        //else
//        //    fourF = true;

//        LinearMove(el.Item1, el.Item2, boolList, 3);
//    }
//}

//if (CurGuess[0] == null)
//{
//    var pos = curFigure.Position;
//        CurGuess[0] = oldfigure.NameToLetter() + XtoString(pos.Y) + (8 - pos.X).ToString();
//        return;
//}
//if (CurGuess[1] == null)
//{
//    var pos = curFigure.Position;
//    CurGuess[0] = oldfigure.NameToLetter() + XtoString(pos.Y) + (8 - pos.X).ToString();
//    return;
//}
//if (CurGuess[2] == null)
//{

//}

//var states = new List<Colors[]> { new Colors[6] };
//var curGuess = new List<string> { "d4", "Nf6", "e6", "c4", "h4", "d3" };

//for (int i = 0; i < 6; i++)
//{
//    if (curGuess[i] == currentVar[i])
//        states[states.Count - 1][i] = Colors.Green;
//    else if (currentVar.Contains(curGuess[i]))
//        states[states.Count - 1][i] = Colors.Yellow;
//    else
//        states[states.Count - 1][i] = Colors.Gray;
//}

//states.Add(new Colors[6]);

//var varPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "variants.txt");
//var fileLines = File.ReadAllLines(varPath);
//Variants = fileLines.Select(s => s.Split()).ToList();
//Played = new List<int>();