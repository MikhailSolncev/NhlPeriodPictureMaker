using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Media.Imaging;

namespace SecondPeriodPictureMaker
{
    class MainPresenterImpl : MainPresenter
    {
        private MainView mView;
        private Model mModel;
        private List<Game> mGameList;
            
        public MainPresenterImpl()
        {
            mModel = DataManager.getInstance();
            mGameList = null;
            mView = null;
        }

        public void attach(MainView mainForm)
        {
            mView = mainForm;
        }

        public void detach()
        {
            mView = null;
        }

        public void lookForSchedule(DateTime date)
        {
            if (mView != null)
                mView.showProgress();
            
            Thread childThread = new Thread(() => lookForScheduleInBackground(date));
            childThread.Start();
            
        }

        private void lookForScheduleInBackground(DateTime date)
        {
            mGameList = mModel.lookForSchedule(date);

            if (mView != null)
            {
                mView.showMatches(mGameList);
                mView.hideProgress();
            }
        }

        public void createPictures(bool playoff)
        {
            if (mGameList == null) return;

            List<Game> copyList = new List<Game>(mGameList);

            if (mView != null)
                mView.showProgress();

            Thread childThread = new Thread(() => createPicturesInBackground(copyList, playoff));
            childThread.Start();
        }

        private void createPicturesInBackground(List<Game> copyList, bool playoff)
        {
            foreach (Game game in copyList)
            {
                // 1. найти файлы команд
                string fileGuest = "sourcepics/" + game.TeamGuest.Name + ".png";
                string fileHost = "sourcepics/" + game.TeamHost.Name + ".png";
                string fileRGB = "sourcepics/" + game.TeamGuest.Name + ".rgb";

                // 1.2. подготовить логотипы по размеру
                Bitmap logoGuest = mModel.resizeLogo(fileGuest);
                Bitmap logoHost = mModel.resizeLogo(fileHost);

                string text = System.IO.File.ReadAllText(fileRGB);
                int guestArgb = int.Parse(text.Substring(1), System.Globalization.NumberStyles.HexNumber);

                for (int period = 1; period < 4; period ++)
                {
                    string bacgroundFileName = "sourcepics/" + "BckgrndRegular" + ".png";
                    if (playoff) bacgroundFileName = "sourcepics/" + "BckgrndPlayoff" + ".png";
                    // 2. создать подложку, раскрасить её
                    Bitmap backgroung = (Bitmap) Image.FromFile(bacgroundFileName);

                    Bitmap result = new Bitmap(backgroung.Width, backgroung.Height, PixelFormat.Format32bppArgb);
                    var graphics = Graphics.FromImage(result);
                    graphics.CompositingMode = CompositingMode.SourceOver; // this is the default, but just to be clear
                    graphics.DrawImage(backgroung, 0, 0);

                    mModel.changeGuestColor(result, Color.FromArgb(255, Color.FromArgb(guestArgb)));

                    int top = 47;
                    // 3. добавить логотип гостя // координаты -10, 47
                    graphics.DrawImage(logoGuest, -10, top);

                    // 4. добавить логотип хозяина // координаты 322, 47
                    graphics.DrawImage(logoHost, 322, top);

                    // 5. добавить надпись периода // координаты 0, 0
                    string periodFileName = "sourcepics/" + period + "period.png";
                    Bitmap periodImage = (Bitmap)Image.FromFile(periodFileName);
                    graphics.DrawImage(periodImage, 0, 0);

                    // 6. сохранить файл
                    string filename = game.TeamGuest + " - " + game.TeamHost + " period " + period + ".png";
                    mModel.saveImageToFile(result, filename);
                    
                }
            }

            if (mView != null)
            {
                mView.showMatches(mGameList);
                mView.hideProgress();
            }
        }
    }
}
