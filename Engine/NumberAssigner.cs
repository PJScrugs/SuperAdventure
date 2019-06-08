using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class NumberAssigner
    {
        static int _nextNumber = 0;

        public static int GetNextNumber()
        {
            _nextNumber++;

            return _nextNumber;
        }
    }
}
