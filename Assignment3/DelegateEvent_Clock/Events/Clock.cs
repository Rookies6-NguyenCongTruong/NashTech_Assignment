namespace DelegateEvent_Clock
{
    public class Clock
    {
        private readonly int _second;

        public delegate void ClockTickHandler(object clock, ClockEventArgs eventArgs);

        public event ClockTickHandler? clockTickEvent;

        protected void OnTick(object clock, ClockEventArgs eventArgs)
        {
            if (clockTickEvent != null)
            {
                clockTickEvent(clock, eventArgs);
            }

        }

        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                var time = DateTime.Now;

                if (time.Second != _second)
                {
                    var eventArgs = new ClockEventArgs(time.Hour, time.Minute, time.Second);
                    OnTick(this, eventArgs);
                }
            }
        }
    }
}