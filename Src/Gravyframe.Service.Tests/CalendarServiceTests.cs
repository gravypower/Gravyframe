using Gravyframe.Service.Calendar;
using NUnit.Framework;

namespace Gravyframe.Service.Tests
{
    [TestFixture]
    public class CalendarServiceTests : ServiceTests<CalendarRequest, CalendarResponce, CalendarService, CalendarService.NullCalendarRequestException>
    {
        protected override void ServiceSetUp()
        {
            Sut = new CalendarService();
        }
    }
}
