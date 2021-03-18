using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest
{
    public class CalculatorTests
    {
        private readonly Calculator _calc;
        private readonly ITestOutputHelper _output;

        public CalculatorTests(ITestOutputHelper output)
        {
            _output = output;
            _calc = new Calculator();
        }

        [Fact]
        public void AddTwoNumbers()
        {
            _output.WriteLine($"AddTwoNumbers {DateTime.Now}");
            Thread.Sleep(2000);

            _calc.Add(10);
            _calc.Add(10);
            Assert.Equal(20, _calc.Value);
        }

        [Fact(Skip = "Test for skip")]
        public void BrokenTest()
        {
            _calc.Add(9999);
            _calc.Add(9999);
            Assert.Equal(10, _calc.Value);
        }

        [Theory]
        [InlineData(20, 10, 10)]
        public void AddTwoNumbersTheory(decimal expected, decimal firstNumber, decimal secondNumber)
        {
            _output.WriteLine($"AddTwoNumbersTheory {DateTime.Now}");
            Thread.Sleep(2000);

            _calc.Add(firstNumber);
            _calc.Add(secondNumber);
            Assert.Equal(expected, _calc.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddSeveralNumbers(decimal expected, params decimal[] valuesToAdd)
        {
            _output.WriteLine($"AddSeveralNumbers {DateTime.Now}");
            Thread.Sleep(2000);

            foreach (var value in valuesToAdd)
            {
                _calc.Add(value);
            }

            Assert.Equal(expected, _calc.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {15, new decimal[] { 10, 5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { 100, new decimal[] { 50, 50 } };
        }

    }
}
