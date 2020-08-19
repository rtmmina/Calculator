using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLogic.Interfaces;
using ServiceLogic.Implementations;
using System.Transactions;
using DataAccess.Interfaces;
using DataAccess.Implementations;
using Microsoft.Extensions.Configuration;

namespace UnitTest
{
    [TestClass]
    public class TestCalculatorGenericsForDoubles
    {
        private ICalculator<double> _calculator;
        private readonly IConfiguration _configuration;

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
        public TestCalculatorGenericsForDoubles()
        {
            _configuration = InitConfiguration();
            ILog _log = new Log(_configuration);
            _calculator = new Calculator<double>(_log, _configuration);
        }

        public TestCalculatorGenericsForDoubles(ICalculator<double> doubleCalculator)
        {
            _configuration = InitConfiguration();
            _calculator = doubleCalculator;
        }

        #region Add tests
        [TestMethod]
        public void Add_TwoPositive()
        {
            //Act
            var actual = _calculator.Add(5.2, 6.33);
            var expected = (double)5.2 + 6.33;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_TwoNegative()
        {
            //Act
            var actual = _calculator.Add(-1.13, -5.37);
            var expected = (double)-1.13 + (-5.37);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Add(3.97, -11.75);
            var expected = (double)3.97 + (-11.75);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Sub tests
        [TestMethod]
        public void Sub_TwoPositive()
        {
            //Act
            var actual = _calculator.Sub(5.13, 6.21);
            var expected = (double)5.13 - 6.21;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sub_TwoNegative()
        {
            //Act
            var actual = _calculator.Sub(-1.85, -5.78);
            var expected = (double)-1.85 - (-5.78);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sub_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Sub(3.45, -11.55);
            var expected = (double)3.45 - (-11.55);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Multiply tests
        [TestMethod]
        public void Multiply_TwoPositive()
        {
            //Act
            var actual = _calculator.Multiply(5.16, 6.89);
            var expected = (double)5.16 * 6.89;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_TwoNegative()
        {
            //Act
            var actual = _calculator.Multiply(-1.99, -5.67);
            var expected = (double)-1.99 * (-5.67);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Multiply(3.96, -11.14);
            var expected = (double)3.96 * (-11.14);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Divide tests
        [TestMethod]
        public void Divide_TwoPositive()
        {
            //Act
            var actual = _calculator.Divide(5.11, 6.77);
            var expected = (double)5.11 / 6.77;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide_TwoNegative()
        {
            //Act
            var actual = _calculator.Divide(-1.37, -5.97);
            var expected = (double)-1.37 / -5.97;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Divide(3.39, -11.93);
            var expected = (double)3.39 / -11.93;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Divide_DivideByZero()//Currently the service would return a zero value, and log the exception.
        {
            //Act
            var actual = _calculator.Divide(-3.69, 0.0);

            //Assert
            Assert.AreEqual(0, actual);
        }

        #endregion
    }
}
