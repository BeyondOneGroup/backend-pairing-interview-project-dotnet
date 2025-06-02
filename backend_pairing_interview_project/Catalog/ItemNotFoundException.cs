using System;

namespace backend_pairing_interview_project.catalog
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() { }
        public ItemNotFoundException(string message, params object[] args)
            : base(string.Format(message, args))
        {
            Console.Error.WriteLine($"[ERROR] {string.Format(message, args)}");
        }
    }
}