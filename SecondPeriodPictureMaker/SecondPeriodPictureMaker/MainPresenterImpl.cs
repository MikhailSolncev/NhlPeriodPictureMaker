using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondPeriodPictureMaker
{
    class MainPresenterImpl : MainPresenter
    {
        private MainView mView;
        private Model mModel;

        public MainPresenterImpl()
        {
            mModel = DataManager.getInstance();
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
            List<Game> gameList = mModel.lookForSchedule(date);

            if (mView != null)
            {
                mView.showMatches(gameList);
                mView.hideProgress();
            }
        }

    }
}
