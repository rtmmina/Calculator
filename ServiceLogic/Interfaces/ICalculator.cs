using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLogic.Interfaces
{
    public interface ICalculator<T>
    {
        public abstract T Add(T firstNmumber, T secondNumber);
        public abstract T Sub(T firstNmumber, T secondNumber);
        public abstract T Multiply(T firstNmumber, T secondNumber);
        public abstract double Divide(T firstNmumber, T secondNumber);
    }
}
