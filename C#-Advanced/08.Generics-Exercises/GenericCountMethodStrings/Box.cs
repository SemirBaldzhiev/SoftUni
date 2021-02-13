using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T: IComparable
    {
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }
}
