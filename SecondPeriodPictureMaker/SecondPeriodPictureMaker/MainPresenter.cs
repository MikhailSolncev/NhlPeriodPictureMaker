using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPeriodPictureMaker
{
    interface MainPresenter
    {
        void lookForSchedule(DateTime date);
        void attach(MainView mainForm);
        void detach();
    }
}
