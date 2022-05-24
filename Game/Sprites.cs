using System;
using System.Drawing;
using System.IO;

namespace Game
{
    public static class BlackSprites
    {
        private static readonly string BlackSpritesFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "pieces", "black");

        private static readonly Size SpriteSize = new Size(50, 50);

        public static Bitmap BlackFig(int i)
        {
            return i switch
            {
                1 => Pawn,
                2 => Knight,
                3 => Bishop,
                4 => Rook,
                5 => Queen,
                _ => King
            };
        }

        public static readonly Bitmap Pawn =
            new Bitmap(Image.FromFile(Path.Combine(BlackSpritesFolder, "bP.png")), SpriteSize);
        public static readonly Bitmap Knight =
            new Bitmap(Image.FromFile(Path.Combine(BlackSpritesFolder, "bN.png")), SpriteSize);
        public static readonly Bitmap Bishop =
            new Bitmap(Image.FromFile(Path.Combine(BlackSpritesFolder, "bB.png")), SpriteSize);
        public static readonly Bitmap Queen =
            new Bitmap(Image.FromFile(Path.Combine(BlackSpritesFolder, "bQ.png")), SpriteSize);
        public static readonly Bitmap King =
            new Bitmap(Image.FromFile(Path.Combine(BlackSpritesFolder, "bK.png")), SpriteSize);
        public static readonly Bitmap Rook =
            new Bitmap(Image.FromFile(Path.Combine(BlackSpritesFolder, "bR.png")), SpriteSize);
    }

    public static class WhiteSprites
    {
        private static readonly string WhiteSpritesFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "pieces", "white");

        private static readonly Size SpriteSize = new Size(50, 50);
        public static Bitmap WhiteFig(int i)
        {
            return i switch
            {
                1 => Pawn,
                2 => Knight,
                3 => Bishop,
                4 => Rook,
                5 => Queen,
                _ => King
            };
        }

        public static readonly Bitmap Pawn =
            new Bitmap(Image.FromFile(Path.Combine(WhiteSpritesFolder, "wP.png")), SpriteSize);
        public static readonly Bitmap Knight =
            new Bitmap(Image.FromFile(Path.Combine(WhiteSpritesFolder, "wN.png")), SpriteSize);
        public static readonly Bitmap Bishop =
            new Bitmap(Image.FromFile(Path.Combine(WhiteSpritesFolder, "wB.png")), SpriteSize);
        public static readonly Bitmap Queen =
            new Bitmap(Image.FromFile(Path.Combine(WhiteSpritesFolder, "wQ.png")), SpriteSize);
        public static readonly Bitmap King =
            new Bitmap(Image.FromFile(Path.Combine(WhiteSpritesFolder, "wK.png")), SpriteSize);
        public static readonly Bitmap Rook =
            new Bitmap(Image.FromFile(Path.Combine(WhiteSpritesFolder, "wR.png")), SpriteSize);
    }
}
