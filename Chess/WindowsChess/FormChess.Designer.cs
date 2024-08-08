namespace WindowsChess
{
	partial class FormChess
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
			this.board = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// board
			// 
			this.board.BackColor = System.Drawing.Color.LightGreen;
			this.board.Location = new System.Drawing.Point(30, 25);
			this.board.Name = "board";
			this.board.Size = new System.Drawing.Size(450, 450);
			this.board.TabIndex = 0;
			this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.board_MouseClick);
			// 
			// FormChess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 508);
			this.Controls.Add(this.board);
			this.Name = "FormChess";
			this.Text = "Windows Chess";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel board;
	}
}

