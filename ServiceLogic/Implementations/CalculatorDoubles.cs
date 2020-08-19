using System;
using System.Collections.Generic;
using System.Text;
using ServiceLogic.Interfaces;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ServiceLogic.Implementations
{
    public class CalculatorDoubles : ICalculator<double>
    {
        private readonly ILog _log;
        private readonly IConfiguration _configuration;

        public CalculatorDoubles(ILog log, IConfiguration configuration)
        {
            _configuration = configuration;
            _log = log;
        }

        public double Add(double firstNmumber, double secondNumber)
        {
            try
            {
                var value = firstNmumber + secondNumber;
                _log.Info($"Add (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Add (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }

        public double Divide(double firstNmumber, double secondNumber)
        {
            try
            {
                double value = 0;
                if (secondNumber != 0)
                {
                    value = (double)firstNmumber / secondNumber;
                    _log.Info($"Divide (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                    return value;
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

        public double Multiply(double firstNmumber, double secondNumber)
        {
            try
            {
                var value = firstNmumber * secondNumber;
                _log.Info($"Multiply (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Multiply (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }

        public double Sub(double firstNmumber, double secondNumber)
        {
            try
            {
                var value = firstNmumber - secondNumber;
                _log.Info($"Sub (Doubles) method for {firstNmumber} and {secondNumber} with result {value}, was called at {DateTime.Now}{Environment.NewLine}");
                return value;
            }
            catch (Exception ex)
            {
                _log.Error($"Exception has occured with method Sub (Doubles) at {DateTime.Now}{Environment.NewLine}{ex.Message}{Environment.NewLine}");
                return 0;
            }
        }
    }
}
