using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPeriodPictureMaker
{
    interface Model
    {
        List<Game> lookForSchedule(DateTime date);

    }
}
