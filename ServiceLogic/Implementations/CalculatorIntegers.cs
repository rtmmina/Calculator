using System;
using System.Collections.Generic;
using System.Text;
using ServiceLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Implementations;
using Microsoft.Extensions.Configuration;

namespace ServiceLogic.Implementations
{
    public class CalculatorIntegers : ICalculator<int>
    {
        private readonly ILog _log;
        private readonly IConfiguration _configuration;

        public CalculatorIntegers(ILog log, IConfiguration configuration)
        {
            _configuration = configuration;
            _log = log;
        }
        public int Add(int firstNmumber, int secondNumber)
        {
            try
            {
                var value = firstNmumber + secondNumber;
                _log.Info($"Add (Integers) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return value;
            }
            catch(Exception ex)
            {
                _log.Error($"Exception has occured with method Add (Integers) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }

        public double Divide(int firstNmumber, int secondNumber)
        {
            try
            {
                double value = 0;
                if (secondNumber != 0)
                {
                    value = (double)firstNmumber / secondNumber;
                    _log.Info($"Divide (Integers) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                    return value;
                }
                else
                {
                    _log.Error($"User has attempted to divide by zero at {DateTime.Now}{Environment.NewLine}{Environment.NewLine}");
                    return 0; //will think about best return to the users/
                }
            }
            catch(Exception ex)
            {
                _log.Error($"Exception has occured with method Add (Integers) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }

        public int Multiply(int firstNmumber, int secondNumber)
        {
            try
            {
                var value = firstNmumber * secondNumber;
                _log.Info($"Multiply (Integers) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Multiply (Integers) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }

        public int Sub(int firstNmumber, int secondNumber)
        {
            try
            {
                var value = firstNmumber - secondNumber;
                _log.Info($"Sub (Integers) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Sub (Integers) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }
    }
}
