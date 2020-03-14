using System;

namespace Yatsyshyn.Exceptions
{
    public class TooOldExc : Exception
    {
        public TooOldExc() : base(message: "You can not be older than 135")
        {
        }
    }
}