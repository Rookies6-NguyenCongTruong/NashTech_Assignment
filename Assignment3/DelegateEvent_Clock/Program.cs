namespace DelegateEvent_Clock
{
    public class Program1
    {
        static void Main(String[] args)
        {
            Clock clock = new Clock();
            DisplayClock displayClock = new DisplayClock();

            displayClock.Subcribe(clock);
            clock.Run();
        }
    }
}
