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
    public class CalculatorIntegersController : ControllerBase
    {
        private readonly ICalculator<int> _calculator;

        public CalculatorIntegersController(ICalculator<int> calculator)
        {
            _calculator = calculator;
        }


        [HttpGet]
        [Route("Add")]
        public IActionResult Add(int firstNumber, int secondNumber)
        {            
            return Ok(_calculator.Add(firstNumber, secondNumber));
        }

        [HttpGet]
        [Route("Sub")]
        public IActionResult Sub(int firstNumber, int secondNumber)
        {
            return Ok(_calculator.Sub(firstNumber, secondNumber));
        }

        [HttpGet]
        [Route("Multiply")]
        public IActionResult Multiply(int firstNumber, int secondNumber)
        {
            return Ok(_calculator.Multiply(firstNumber, secondNumber));
        }

        [HttpGet]
        [Route("Divide")]
        public IActionResult Divide(int firstNumber, int secondNumber)
        {
            return Ok(_calculator.Divide(firstNumber, secondNumber));
        }
    }
}