﻿using System;

namespace GenericBox
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
            => $"{typeof(T)}: {Value}";
    }
}
