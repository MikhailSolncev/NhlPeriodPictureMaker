using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondPeriodPictureMaker
{
    public partial class MainForm : Form, MainView
    {
        private MainPresenter presenter;
        private Thread progressThread;
        int difference;

        public MainForm()
        {
            InitializeComponent();


        }

        public void hideProgress()
        {
            BeginInvoke((Action)(() =>
            {
                progressBar.Hide();

                listBoxGames.Location = new Point(listBoxGames.Location.X, listBoxGames.Location.Y - difference);
                listBoxGames.Height = listBoxGames.Height + difference;
            }));

            if (progressThread != null && progressThread.IsAlive)
                progressThread.Abort();
            progressThread = null;
        }

        public void showProgress()
        {
            BeginInvoke((Action)(() =>
            {
                progressBar.Show();

                listBoxGames.Location = new Point(listBoxGames.Location.X, listBoxGames.Location.Y + difference);
                listBoxGames.Height = listBoxGames.Height - difference;
            }));

            progressThread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            BeginInvoke((Action)(() =>
                            {
                                progressBar.Value = progressBar.Value >= progressBar.Maximum ? 0 : progressBar.Value + 1;
                            }));
                        }
                        catch (Exception ex)
                        {

                        }
                        Thread.Sleep(20);
                    }
                });
            progressThread.Start();
        }

        public void showMatches(List<Game> list)
        {
            BeginInvoke((Action)(() =>
            {
                listBoxGames.Items.Clear();

                foreach (Game game in list)
                {
                    String item = "guest: " + game.TeamGuest + " / host: " + game.TeamHost;
                    listBoxGames.Items.Add(item);
                }
            }));
        }

        private void ButtonLoadSchedule_Click(object sender, EventArgs e)
        {
            presenter.lookForSchedule(this.dateTimePicker.Value);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            presenter.detach();

            hideProgress();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            presenter = new MainPresenterImpl();
            presenter.attach(this);

            difference = listBoxGames.Location.Y - progressBar.Location.Y;

            hideProgress();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            listBoxGames.Height = this.Height - 115;
            listBoxGames.Width = this.Width - 40;
        }

        private void buttonCreatePictures_Click(object sender, EventArgs e)
        {
            presenter.createPictures(checkBoxPlayoff.Checked);
        }
    }
}
