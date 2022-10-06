namespace DelegateEvent_Clock
{
    public class DisplayClock
    {
        public void Subcribe(Clock clock)
        {
            clock.clockTickEvent += new Clock.ClockTickHandler(ShowClock);
        }

        public void ShowClock(Object clock, ClockEventArgs eventArgs)
        {
            Console.WriteLine($"{eventArgs.hour}:{eventArgs.minute}:{eventArgs.second}");
        }
    }
}