using System;
using System.Collections.Generic;
using System.Text;
using ServiceLogic.Interfaces;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace ServiceLogic.Implementations
{
    public class Calculator<T> : ICalculator<T>
    {
        private readonly ILog _log;
        private readonly IConfiguration _configuration;

        public Calculator(ILog log, IConfiguration configuration)
        {
            _configuration = configuration;
            _log = log;
        }

        public T Add(T firstNmumber, T secondNumber)
        {
            try
            {
                var value = Operators.AddObject(firstNmumber, secondNumber);
                _log.Info($"Add (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return (T)value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Add (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                object rVal = 0;
                return (T)rVal;
            }
        }

        public double Divide(T firstNmumber, T secondNumber)
        {
            try
            {                
                if (Convert.ToInt32(secondNumber) != 0)
                {
                    var value = Operators.DivideObject(firstNmumber, secondNumber);
                    _log.Info($"Divide (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                    return (double)value;
                }
                else
                {
                    _log.Error($"User has attempted to Divide by zero at {DateTime.Now}{Environment.NewLine}{Environment.NewLine}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Divide (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }

        public T Multiply(T firstNmumber, T secondNumber)
        {
            try
            {
                var value = Operators.MultiplyObject(firstNmumber, secondNumber);
                _log.Info($"Multiply (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return (T)value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Multiply (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                object rVal = 0;
                return (T)rVal;
            }
        }

        public T Sub(T firstNmumber, T secondNumber)
        {
            try
            {
                var value = Operators.SubtractObject(firstNmumber, secondNumber);
                _log.Info($"Sub (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return (T)value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Sub (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                object rVal = 0;
                return (T)rVal;
            }
        }
    }
}
