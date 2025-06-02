using System;

namespace backend_pairing_interview_project.Orders
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() { }
        public OrderNotFoundException(string message) : base(message)
        {
            Console.Error.WriteLine($"[ERROR] {message}");
        }

        public OrderNotFoundException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            Console.Error.WriteLine($"[ERROR] {string.Format(format, args)}");
        }
    }
}