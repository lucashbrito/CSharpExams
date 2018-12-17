using System;

namespace Chapter2
{
    public struct NullableStruct<T> where T : struct
    {
        private bool hasValue;
        private T value;

        public NullableStruct(T value)
        {
            hasValue = true;
            this.value = value;
        }

        public bool HasValue
        {
            get { return hasValue; }
        }

        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new ArgumentException();
                }

                return value;
            }
        }

        public T GetValueOrDefault()
        {
            return value;
        }
    }

    public struct ProductStruct
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
