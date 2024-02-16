using System;
using ClassesInterfaces;

namespace ClassesInterFaces
{
    public abstract class HeirArray:IHeirArray
    {
        public HeirArray(bool input_mode = false)
        {
            if (input_mode)
            {
                InputUser();
            }
            else
            {
                InputRandom();
            }
        }
        protected abstract void InputUser();
        protected abstract void InputRandom();
        public abstract void Print();
        public abstract float Average();
    }
}