using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLogic.Interfaces;
using ServiceLogic.Implementations;
using DataAccess.Interfaces;
using DataAccess.Implementations;

namespace UnitTest
{
    [TestClass]
    public class TestCalculatorForIntegers
    {
        private ICalculator<int> _calculator;

        public TestCalculatorForIntegers()
        {
            ILog _log = new Log() ;
            _calculator = new CalculatorIntegers(_log);
        }
        public TestCalculatorForIntegers(ICalculator<int> intergerCalculator)
        {
            _calculator = intergerCalculator;
        }
        
        #region Add tests
        [TestMethod]
        public void Add_TwoPositive()
        {         
            //Act
            var actual = _calculator.Add(5, 6);

            //Assert
            Assert.AreEqual(11, actual);
        }

        [TestMethod]
        public void Add_TwoNegative()
        {
            //Act
            var actual = _calculator.Add(-1, -5);

            //Assert
            Assert.AreEqual(-6, actual);
        }

        [TestMethod]
        public void Add_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Add(3, -11);

            //Assert
            Assert.AreEqual(-8, actual);
        }
        #endregion

        #region Sub tests
        [TestMethod]
        public void Sub_TwoPositive()
        {
            //Act
            var actual = _calculator.Sub(5, 6);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void Sub_TwoNegative()
        {
            //Act
            var actual = _calculator.Sub(-1, -5);

            //Assert
            Assert.AreEqual(4, actual);
        }

        [TestMethod]
        public void Sub_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Sub(3, -11);

            //Assert
            Assert.AreEqual(14, actual);
        }
        #endregion

        #region Multiply tests
        [TestMethod]
        public void Multiply_TwoPositive()
        {
            //Act
            var actual = _calculator.Multiply(5, 6);

            //Assert
            Assert.AreEqual(30, actual);
        }

        [TestMethod]
        public void Multiply_TwoNegative()
        {
            //Act
            var actual = _calculator.Multiply(-1, -5);

            //Assert
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void Multiply_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Multiply(3, -11);

            //Assert
            Assert.AreEqual(-33, actual);
        }
        #endregion

        #region Divide tests
        [TestMethod]
        public void Divide_TwoPositive()
        {
            //Act
            var actual = _calculator.Divide(5, 6);

            //Assert
            Assert.AreEqual((double)5/6, actual);
        }

        [TestMethod]
        public void Divide_TwoNegative()
        {
            //Act
            var actual = _calculator.Divide(-1, -5);

            //Assert
            Assert.AreEqual(0.2, actual);
        }

        [TestMethod]
        public void Divide_OnePositiveOneNegative()
        {
            //Act
            var actual = _calculator.Divide(3, -11);

            //Assert
            Assert.AreEqual((double)-3/11, actual);
        }

        [TestMethod]
        public void Divide_DivideByZero()//Currently the service would return a zero value, and log the exception.
        {
            //Act
            var actual = _calculator.Divide(-3, 0);

            //Assert
            Assert.AreEqual(0, actual);
        }

        #endregion
    }
}
