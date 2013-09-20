using System;

namespace Gravyframe.Service.Calendar
{
    public class CalendarService : Service<CalendarRequest, CalendarResponce>
    {
        public override CalendarResponce Get(CalendarRequest request)
        {
            if(request == null)
                throw new NullCalendarRequestException();

            return new CalendarResponce();
        }


        [Serializable]
        public class NullCalendarRequestException : NullRequestException
        {
        }
    }
}
