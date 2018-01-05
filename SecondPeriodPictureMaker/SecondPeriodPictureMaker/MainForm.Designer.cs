namespace SecondPeriodPictureMaker
{
    partial class MainForm
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonLoadSchedule = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(13, 13);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // buttonLoadSchedule
            // 
            this.buttonLoadSchedule.Location = new System.Drawing.Point(13, 39);
            this.buttonLoadSchedule.Name = "buttonLoadSchedule";
            this.buttonLoadSchedule.Size = new System.Drawing.Size(144, 23);
            this.buttonLoadSchedule.TabIndex = 1;
            this.buttonLoadSchedule.Text = "Load schedule";
            this.buttonLoadSchedule.UseVisualStyleBackColor = true;
            this.buttonLoadSchedule.Click += new System.EventHandler(this.ButtonLoadSchedule_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 68);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(144, 23);
            this.progressBar.TabIndex = 2;
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.IntegralHeight = false;
            this.listBoxGames.Location = new System.Drawing.Point(12, 97);
            this.listBoxGames.MultiColumn = true;
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.Size = new System.Drawing.Size(145, 95);
            this.listBoxGames.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 202);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonLoadSchedule);
            this.Controls.Add(this.dateTimePicker);
            this.MinimumSize = new System.Drawing.Size(185, 240);
            this.Name = "MainForm";
            this.Text = "Period picture maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonLoadSchedule;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBoxGames;
    }
}

