using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLogic.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorDoublesController : ControllerBase
    {
        private readonly ICalculator<double> _calculator;

        public CalculatorDoublesController(ICalculator<double> calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add(double firstNumber, double secondNumber)
        {
            return Ok(_calculator.Add(firstNumber, secondNumber));
        }

        [HttpGet]
        [Route("Sub")]
        public IActionResult Sub(double firstNumber, double secondNumber)
        {
            return Ok(_calculator.Sub(firstNumber, secondNumber));
        }

        [HttpGet]
        [Route("Multiply")]
        public IActionResult Multiply(double firstNumber, double secondNumber)
        {
            return Ok(_calculator.Multiply(firstNumber, secondNumber));
        }

        [HttpGet]
        [Route("Divide")]
        public IActionResult Divide(double firstNumber, double secondNumber)
        {
            return Ok(_calculator.Divide(firstNumber, secondNumber));
        }
    }
}