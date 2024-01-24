namespace Event
{
    public class MyEventArgs : EventArgs
    {
        public string? Message { get; set; }
    }

    public delegate void MeEventHandler (object sender, MyEventArgs args);

    class ClassWithEvents
    {
        public event MeEventHandler SomeEvent;

        protected void OnSomeEvent(MyEventArgs args)
        {
            SomeEvent?.Invoke(this, args);
        }

        public void DoSomeWork()
        {
            new Thread(
                () =>
                {
                    Thread.Sleep(2000);
                    OnSomeEvent(new MyEventArgs { Message = "Всё!" });
                }
                ).Start();

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassWithEvents newEvent = new ClassWithEvents();

            newEvent.SomeEvent += NewEvent_SomeEvent;

            newEvent.DoSomeWork();

            Console.WriteLine("Запустили на выполнение");

            Console.ReadLine();

            newEvent.SomeEvent -= NewEvent_SomeEvent;

        }

        private static void NewEvent_SomeEvent(object sender, MyEventArgs args)
        {
            Console.WriteLine("Событие от класса " + sender + "Сообщающее " + args.Message);
        }
    }
}
