
namespace Game
{
    partial class Chessle
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chessle));
            this.NewGame = new System.Windows.Forms.Button();
            this.Hint = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.VictoryLabel = new System.Windows.Forms.Label();
            this.LoseLabel = new System.Windows.Forms.Label();
            this.MoreMovesLabel = new System.Windows.Forms.Label();
            this.Undo = new System.Windows.Forms.Button();
            this.Rules = new System.Windows.Forms.Button();
            this.RulePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RulePic)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(410, 12);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(67, 23);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "NewGame";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Hint
            // 
            this.Hint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Hint.Location = new System.Drawing.Point(410, 42);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(67, 23);
            this.Hint.TabIndex = 1;
            this.Hint.Text = "Move Hint";
            this.Hint.UseVisualStyleBackColor = false;
            this.Hint.Click += new System.EventHandler(this.Hint_Click);
            // 
            // Check
            // 
            this.Check.Location = new System.Drawing.Point(410, 71);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(67, 23);
            this.Check.TabIndex = 2;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // VictoryLabel
            // 
            this.VictoryLabel.AutoSize = true;
            this.VictoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VictoryLabel.Location = new System.Drawing.Point(416, 158);
            this.VictoryLabel.Name = "VictoryLabel";
            this.VictoryLabel.Size = new System.Drawing.Size(61, 20);
            this.VictoryLabel.TabIndex = 3;
            this.VictoryLabel.Text = "Victory!";
            // 
            // LoseLabel
            // 
            this.LoseLabel.AutoSize = true;
            this.LoseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoseLabel.Location = new System.Drawing.Point(416, 158);
            this.LoseLabel.Name = "LoseLabel";
            this.LoseLabel.Size = new System.Drawing.Size(49, 20);
            this.LoseLabel.TabIndex = 4;
            this.LoseLabel.Text = "Lose(";
            // 
            // MoreMovesLabel
            // 
            this.MoreMovesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoreMovesLabel.Location = new System.Drawing.Point(406, 158);
            this.MoreMovesLabel.Name = "MoreMovesLabel";
            this.MoreMovesLabel.Size = new System.Drawing.Size(82, 66);
            this.MoreMovesLabel.TabIndex = 5;
            this.MoreMovesLabel.Text = "You need to make 6 moves!";
            // 
            // Undo
            // 
            this.Undo.Location = new System.Drawing.Point(410, 101);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(67, 23);
            this.Undo.TabIndex = 6;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Rules
            // 
            this.Rules.Location = new System.Drawing.Point(410, 130);
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(67, 23);
            this.Rules.TabIndex = 7;
            this.Rules.Text = "Rules";
            this.Rules.UseVisualStyleBackColor = true;
            this.Rules.Click += new System.EventHandler(this.Rules_Click);
            // 
            // RulePic
            // 
            this.RulePic.Enabled = false;
            this.RulePic.Location = new System.Drawing.Point(0, 0);
            this.RulePic.Name = "RulePic";
            this.RulePic.Size = new System.Drawing.Size(400, 405);
            this.RulePic.TabIndex = 8;
            this.RulePic.TabStop = false;
            this.RulePic.Visible = false;
            // 
            // Chessle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(490, 461);
            this.Controls.Add(this.RulePic);
            this.Controls.Add(this.Rules);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.MoreMovesLabel);
            this.Controls.Add(this.LoseLabel);
            this.Controls.Add(this.VictoryLabel);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.NewGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(530, 650);
            this.Name = "Chessle";
            this.Text = "Chessle";
            ((System.ComponentModel.ISupportInitialize)(this.RulePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button Hint;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Label VictoryLabel;
        private System.Windows.Forms.Label LoseLabel;
        private System.Windows.Forms.Label MoreMovesLabel;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Rules;
        private System.Windows.Forms.PictureBox RulePic;
    }
}

