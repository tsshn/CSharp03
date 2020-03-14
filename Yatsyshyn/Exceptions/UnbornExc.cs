using System;

namespace Yatsyshyn.Exceptions
{
    public class UnbornExc : Exception
    {
        public UnbornExc() : base(message: "You can not be unborn")
        {
        }
    }
}