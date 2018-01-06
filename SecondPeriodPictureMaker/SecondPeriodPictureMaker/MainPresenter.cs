using System;


namespace SecondPeriodPictureMaker
{
    interface MainPresenter
    {
        void lookForSchedule(DateTime date);
        void attach(MainView mainForm);
        void detach();
        void createPictures(bool playoff);
    }
}
