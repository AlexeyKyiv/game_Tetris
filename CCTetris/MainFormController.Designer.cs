namespace CCTetris
{
    partial class MainFormController
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureGreenMove = new System.Windows.Forms.PictureBox();
            this.pictureGreenBtnStartPause = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreenMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreenBtnStartPause)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureGreenMove
            // 
            this.pictureGreenMove.Image = global::CCTetris.Properties.Resources.return_2;
            this.pictureGreenMove.Location = new System.Drawing.Point(378, 408);
            this.pictureGreenMove.Name = "pictureGreenMove";
            this.pictureGreenMove.Size = new System.Drawing.Size(59, 62);
            this.pictureGreenMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureGreenMove.TabIndex = 7;
            this.pictureGreenMove.TabStop = false;
            this.pictureGreenMove.Click += new System.EventHandler(this.pictureGreenMove_Click);
            // 
            // pictureGreenBtnStartPause
            // 
            this.pictureGreenBtnStartPause.BackColor = System.Drawing.SystemColors.Control;
            this.pictureGreenBtnStartPause.Image = global::CCTetris.Properties.Resources.BUTTON_4_png_;
            this.pictureGreenBtnStartPause.Location = new System.Drawing.Point(346, 178);
            this.pictureGreenBtnStartPause.Name = "pictureGreenBtnStartPause";
            this.pictureGreenBtnStartPause.Size = new System.Drawing.Size(130, 123);
            this.pictureGreenBtnStartPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureGreenBtnStartPause.TabIndex = 6;
            this.pictureGreenBtnStartPause.TabStop = false;
            this.pictureGreenBtnStartPause.Click += new System.EventHandler(this.pictureGreenBtnStartPause_Click);
            this.pictureGreenBtnStartPause.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureGreenBtn_PreviewKeyDown);
            // 
            // MainFormController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(505, 510);
            this.Controls.Add(this.pictureGreenMove);
            this.Controls.Add(this.pictureGreenBtnStartPause);
            this.MaximumSize = new System.Drawing.Size(521, 548);
            this.MinimumSize = new System.Drawing.Size(521, 548);
            this.Name = "MainFormController";
            this.Text = "TETRIS - © Alexey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormController_FormClosing);
            this.Load += new System.EventHandler(this.MainFormController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreenMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreenBtnStartPause)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureGreenBtnStartPause;
        private System.Windows.Forms.PictureBox pictureGreenMove;
    }
}

