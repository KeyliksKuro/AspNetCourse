using Microsoft.AspNetCore.Mvc;

namespace AspNetCourse.Examples.Example10.ViewComponents
{
    public class TimerViewComponent : ViewComponent
    {
        //внедрение зависимости
        ITimeService timeService;
        public TimerViewComponent(ITimeService service)
        {
            timeService = service;
        }

        //в классе должен быть определён один из методов Invok или InvokeAsync
        public async Task<string> InvokeAsync(bool longTime)
        {
            if (longTime)
            {
                return $"Текущее время: {DateTime.Now.ToLongTimeString()}";
            }
            else
            {
                return $"Текущее время: {DateTime.Now.ToShortTimeString()}";
            }

        }
    }
}
