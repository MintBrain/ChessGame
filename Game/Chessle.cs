using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Game
{
    public partial class Chessle : Form
    {
        private Figure[,] Map;
        private Button[,] ButtonMap;
        private Button[,] GuessButtonMap;
        private Button OldPressedButton;
        private bool FigurePressed = false;
        private Player CurPlayer;
        private List<Point> OldPosMoves;
        private bool HintOn = false;
        private int CurMoves => GameCode.CurGuess[GameCode.CurrentAttempt].Count;
        private Stack<(Figure,Figure)> PrevMoves;
        private Label ansLabel;

        public Chessle()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            CurPlayer = Player.White;
            GameCode.NewGame();
            Map = GameCode.GameField;
            ButtonMap = new Button[8, 8];
            GuessButtonMap = new Button[6, 6];
            DrawMap();
            GuessButtonsInit(0);
            PrevMoves = new Stack<(Figure, Figure)>();
            VictoryLabel.Visible = false;
            LoseLabel.Visible = false;
            MoreMovesLabel.Visible = false;
            //ShowAnswer();  //Debug
        }

        private void DrawMap()
        {
            foreach (var el in GameCode.GameField)
            {
                var figureButton = new Button
                {
                    Size = new Size(50, 50),
                    Location = el.FormLocation,
                    Image = el.Image,
                    FlatStyle = FlatStyle.Flat,
                    Name = "MapButton",
                };
                figureButton.BackColor = GetFColor(el.Position.X, el.Position.Y);
                figureButton.Tag = el;
                figureButton.FlatAppearance.BorderColor = Color.White;
                figureButton.FlatAppearance.BorderSize = 0;
                figureButton.Click += new EventHandler(OnFigurePress);
                ButtonMap[el.Position.X, el.Position.Y] = figureButton;
                this.Controls.Add(figureButton);
            }
        }

        private void OnFigurePress(object sender, EventArgs e)
        {
            var curPressedBut = sender as Button;
            var curFigure = curPressedBut.Tag as Figure;
            Figure oldFigure = null;

            if (OldPressedButton != null)
            {
                oldFigure = OldPressedButton.Tag as Figure;
                if (HintOn) HideOldPossibleMoves();

                OldPressedButton.FlatAppearance.BorderSize = 0;
            }

            if (curFigure.FigureName != 0 && curFigure.PlayerColor == CurPlayer)
            {
                if (HintOn) ShowPossibleMoves(curFigure);

                curPressedBut.FlatAppearance.BorderSize = 2;
                FigurePressed = true;
            }
            else
                MoveFigure(oldFigure, curPressedBut);
            
            OldPressedButton = curPressedBut;
        }

        private void MoveFigure(Figure oldFigure, Button curPressedBut)
        {
            if (oldFigure == null) return;
            var curFigure = curPressedBut.Tag as Figure;
            oldFigure.FindPossibleMoves();

            if (FigurePressed && 
                oldFigure.PossibleMoves.Contains(curFigure.Position) && 
                CurMoves != 6 && 
                oldFigure.PlayerColor == CurPlayer)
            {
                PrevMoves.Push((new Figure(oldFigure), new Figure(curFigure)));
                GameCode.AddMove(oldFigure, curFigure);
                AddToGuessedButtons();
                var oldPos = oldFigure.Position;
                var newPos = curFigure.Position;
                oldFigure.MoveFigureTo(curFigure);

                curPressedBut.Image = OldPressedButton.Image;
                OldPressedButton.Image = null;
                curPressedBut.Tag = Map[newPos.X, newPos.Y];
                OldPressedButton.Tag = Map[oldPos.X, oldPos.Y];
                FigurePressed = false;
                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            CurPlayer = CurPlayer == Player.White ? Player.Black : Player.White;
        }

        private Color GetFColor(int x, int y)
        {
             return ((x + y) % 2) switch
            {
                0 => Color.FromArgb(240, 217, 181),
                1 => Color.FromArgb(181, 135, 96),
                _ => default
            };
        }

        private void ShowPossibleMoves(Figure curFigure)
        {
            curFigure.FindPossibleMoves();
            OldPosMoves = curFigure.PossibleMoves;
            foreach (var move in OldPosMoves)
                ButtonMap[move.X, move.Y].BackColor = Color.Gold;
        }

        private void HideOldPossibleMoves()
        {
            if (OldPosMoves == null) return;
            foreach (var move in OldPosMoves)
                ButtonMap[move.X, move.Y].BackColor = GetFColor(move.X, move.Y);
        }

        private void GuessButtonsInit(int row)
        {
            for (var column = 0; column < 6; column++)
            {
                var newBut = new Button
                {
                    Text = "",
                    BackColor = Color.BlanchedAlmond,
                    Enabled = false,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(60,55),
                    Font = new Font("Microsoft Sans Serif", 13F),
                    ForeColor = Color.Black,
                    Padding = new Padding(0),
                    Location = new Point(6 + 60*column + column*6, 408 + row*55 + row*6)
                };
                GuessButtonMap[row, column] = newBut;
                this.Controls.Add(newBut);

            }
        }

        private void AddToGuessedButtons()
        {
            GuessButtonMap[GameCode.CurrentAttempt, CurMoves - 1].Text = 
                GameCode.CurGuess[GameCode.CurrentAttempt].Last();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(NewGame);
            this.Controls.Add(Hint);
            this.Controls.Add(Check);
            this.Controls.Add(VictoryLabel);
            this.Controls.Add(LoseLabel);
            this.Controls.Add(MoreMovesLabel);
            this.Controls.Add(Undo);
            this.Controls.Add(Rules);
            this.Controls.Add(RulePic);
            Init();
        }

        private void Hint_Click(object sender, EventArgs e)
        {
            if (HintOn)
            {
                HintOn = false;
                Hint.BackColor = SystemColors.ControlLight;
            }
            else
            {
                HintOn = true;
                Hint.BackColor = Color.Aquamarine;
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (CurMoves != 6)
            {
                new Action(DoMoreMoves).BeginInvoke(null, null);
                return;
            }
            if (CheckForWin())
            {
                return;
            }
            NewGuess();
        }

        private void NewGuess()
        {
            GameCode.CurrentAttempt++;
            GuessButtonsInit(GameCode.CurrentAttempt);
            GameCode.CurGuess.Add(new List<string>());
            for (var i = 0; i < 6; i++)
            {
                var btn = GuessButtonMap[GameCode.CurrentAttempt - 1, i];
                btn.BackColor = GuessColor(i);
            }
            for (var i = 0; i < 64;i++)
                this.Controls.RemoveByKey("MapButton");
            CurPlayer = Player.White;
            GameCode.CreateField();
            Map = GameCode.GameField;
            ButtonMap = new Button[8, 8];
            DrawMap();
            PrevMoves = new Stack<(Figure, Figure)>();
        }

        private Color GuessColor(int i)
        {
            if (GameCode.CurGuess[GameCode.CurrentAttempt - 1][i] == GameCode.CurVariant[i])
                return Color.Green;
            else if (GameCode.CurVariant.Contains(GameCode.CurGuess[GameCode.CurrentAttempt - 1][i]))
                return Color.Yellow;
            else
                return Color.Gray;
        }

        private bool CheckForWin()
        {
            for (int i = 0; i < 6; i++)
            {
                if (GameCode.CurGuess[GameCode.CurrentAttempt][i] !=
                    GameCode.CurVariant[i])
                {
                    if (GameCode.CurrentAttempt + 1 == 6)
                    {
                        LoseMsg();
                        return true;
                    }
                    return false;
                }
            }
            VictoryMsg();
            return true;
        }

        private void VictoryMsg() => VictoryLabel.Visible = true;

        private void LoseMsg() => LoseLabel.Visible = true;

        private void DoMoreMoves()
        {
            BeginInvoke(new Action(() => MoreMovesLabel.Visible = true));
            Thread.Sleep(3000);
            BeginInvoke(new Action(() => MoreMovesLabel.Visible = false));
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (PrevMoves.Count == 0)
                return;

            GameCode.CurGuess[GameCode.CurrentAttempt].RemoveAt(CurMoves - 1);
            GuessButtonMap[GameCode.CurrentAttempt, CurMoves].Text = "";
            var temp = PrevMoves.Pop();
            var oldPlace = temp.Item1;
            var newPlace = temp.Item2;

            Map[oldPlace.Position.X, oldPlace.Position.Y] = oldPlace;
            Map[newPlace.Position.X, newPlace.Position.Y] = newPlace;
            var oldB = ButtonMap[oldPlace.Position.X, oldPlace.Position.Y];
            oldB.Tag = oldPlace;
            oldB.Image = oldPlace.Image;
            var newB = ButtonMap[newPlace.Position.X, newPlace.Position.Y];
            newB.Tag = newPlace;
            newB.Image = newPlace.Image;
            SwitchPlayer();
            HideOldPossibleMoves();
        }

        private void ShowAnswer()
        {
            var showAnswerBtn = new Button
            {
                Location = new Point(410, 230),
                Name = "AnsButton",
                Size = new Size(67, 39),
                Text = "Show\r\nAnswer\r\n"
            };
            showAnswerBtn.Click += OnShowAnswerClick;
            this.Controls.Add(showAnswerBtn);

            var curVar = GameCode.CurVariant;
            var labelText = $"1. {curVar[0]} {curVar[1]}\r\n2. {curVar[2]} {curVar[3]}\r\n3. {curVar[4]} {curVar[5]}";
            ansLabel = new Label
            {
                Name = "AnsLabel",
                Location = new Point(409, 280),
                Size = new Size(35, 13),
                AutoSize = true,
                Text = labelText,
                Visible = false,
                Font = new Font("Microsoft Sans Serif", 10F)
            };
            this.Controls.Add(ansLabel);
        }

        private void OnShowAnswerClick(object sender, EventArgs e)
        {
            ansLabel.Visible = !ansLabel.Visible;
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            RulePic.Visible = !RulePic.Visible;
            var rulePicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "rules.png");
            RulePic.Image =  new Bitmap(Image.FromFile(rulePicPath),RulePic.Size);
        }
    }
}
