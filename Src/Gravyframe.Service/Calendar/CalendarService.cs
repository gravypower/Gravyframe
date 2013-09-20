using System;

namespace Gravyframe.Service.Calendar
{
    public class CalendarService : Service<CalendarRequest, CalendarResponce, CalendarService.NullCalendarRequestException>
    {
        [Serializable]
        public class NullCalendarRequestException : NullRequestException
        {
        }

        protected override CalendarResponce CreateResponce(CalendarRequest request, CalendarResponce responce)
        {
            return responce;
        }

        protected override CalendarResponce ValidateRequest(CalendarRequest request)
        {
            return new CalendarResponce();
        }
    }
}
