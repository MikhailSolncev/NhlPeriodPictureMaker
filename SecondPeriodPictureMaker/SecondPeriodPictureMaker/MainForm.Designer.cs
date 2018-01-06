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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonLoadSchedule = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.buttonCreatePictures = new System.Windows.Forms.Button();
            this.checkBoxPlayoff = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Name = "dateTimePicker";
            // 
            // buttonLoadSchedule
            // 
            resources.ApplyResources(this.buttonLoadSchedule, "buttonLoadSchedule");
            this.buttonLoadSchedule.Name = "buttonLoadSchedule";
            this.buttonLoadSchedule.UseVisualStyleBackColor = true;
            this.buttonLoadSchedule.Click += new System.EventHandler(this.ButtonLoadSchedule_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxGames, "listBoxGames");
            this.listBoxGames.MultiColumn = true;
            this.listBoxGames.Name = "listBoxGames";
            // 
            // buttonCreatePictures
            // 
            resources.ApplyResources(this.buttonCreatePictures, "buttonCreatePictures");
            this.buttonCreatePictures.Name = "buttonCreatePictures";
            this.buttonCreatePictures.UseVisualStyleBackColor = true;
            this.buttonCreatePictures.Click += new System.EventHandler(this.buttonCreatePictures_Click);
            // 
            // checkBoxPlayoff
            // 
            resources.ApplyResources(this.checkBoxPlayoff, "checkBoxPlayoff");
            this.checkBoxPlayoff.Name = "checkBoxPlayoff";
            this.checkBoxPlayoff.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxPlayoff);
            this.Controls.Add(this.buttonCreatePictures);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonLoadSchedule);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonLoadSchedule;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.Button buttonCreatePictures;
        private System.Windows.Forms.CheckBox checkBoxPlayoff;
    }
}

