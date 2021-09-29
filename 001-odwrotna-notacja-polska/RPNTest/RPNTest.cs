using NUnit.Framework;
using System;
using RPNCalulator;

namespace RPNTest{
    [TestFixture]
    public class RPNTest{
        private RPN _sut;
        [SetUp]
        public void Setup(){
            _sut = new RPN();
        }
        [Test]
        public void CheckIfTestWorks(){
            Assert.Pass();
        }

        [Test]
        public void CheckIfCanCreateSut(){
            Assert.That(_sut, Is.Not.Null);
        }

        [Test]
        public void SingleDigitOneInputOneReturn(){
            var result = _sut.EvalRPN("1");

            Assert.That(result, Is.EqualTo(1));

        }
        [Test]
        public void SingleDigitOtherThenOneInputNumberReturn(){
            var result = _sut.EvalRPN("2");

            Assert.That(result, Is.EqualTo(2));

        }
        [TestCase(12)]
        [TestCase(120)]
        [TestCase(1201)]
        [TestCase(42)]
        public void MultiDigitsNumberInputNumberReturn(int value){
            var result = _sut.EvalRPN(value.ToString());

            Assert.That(result, Is.EqualTo(value));
        }
        [TestCase("1128046574673265")]
        [TestCase("-1128046574673265")]
        public void BigNumber_ThrowsExcepton(string value){
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN(value));
        }
        [TestCase("1.1")]
        [TestCase("1.0")]
        [TestCase("237462137492136478.1")]
        [TestCase("0.0")]
        public void NonIntNumber_ThrowsExcepton(string value)
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN(value));
        }
        [TestCase("2 1 ")]
        [TestCase("31 4 1")]
        [TestCase("1201 1533")]
        [TestCase("-2 -3")]
        public void TooFewOperators_ThrowsExcepton(string value){
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN(value));
        }
        [TestCase("2 1 + + +")]
        [TestCase("31 | | -")]
        [TestCase("1201 1533 * * !")]
        [TestCase("-2 -3 * / *")]
        public void TooManyOperators_ThrowsExcepton(string value)
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN(value));
        }
        [Test]
        public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult(){
            var result = _sut.EvalRPN("1 2 +");

            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void OperatorTimes_MultiplyingTwoNumbers_ReturnCorrectResult(){
            var result = _sut.EvalRPN("2 2 *");

            Assert.That(result, Is.EqualTo(4));
        }
        [Test]
        public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult(){
            var result = _sut.EvalRPN("2 1 -");

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void OperatorDivide_DividingTwoNumbers_ReturnCorrectResult(){
            var result = _sut.EvalRPN("6 2 /");

            Assert.That(result, Is.EqualTo(3));
        }
        [TestCase("1 0 /")]
        [TestCase("-11 0 /")]
        [TestCase("1 0 | /")]
        [TestCase("1 0 * 0 /")]
        public void OperatorDivide_DividingByZero_ThrowsExcepton(string value){
            Assert.Throws<DivideByZeroException>(() => _sut.EvalRPN(value));
        }
        [Test]
        public void OperatorPower_FirsttoPowerofSecond_ReturnCorrectResult(){
            var result = _sut.EvalRPN("3 2 ^");

            Assert.That(result, Is.EqualTo(9));
        }
        [Test]
        public void OperatorAbsolute_NegativetoPositive_ReturnCorrectResult(){
            var result = _sut.EvalRPN("-1 |");

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void OperatorAbsolute_PositivetoPositive_ReturnCorrectResult(){
            var result = _sut.EvalRPN("1 |");

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void OperatorFactorial_FactorializeNumber_ReturnCorrectResult(){
            var result = _sut.EvalRPN("5 !");

            Assert.That(result, Is.EqualTo(120));
        }
        [TestCase("100 !")]
        [TestCase("-100 | !")]
        [TestCase("1000 !")]
        [TestCase("5 10 * !")]
        public void OperatorFactorial_FactorializeBigNumber_ThrowsExcepton(string value){
            Assert.Throws<OverflowException>(() => _sut.EvalRPN(value));
        }
        [TestCase("-10 !")]
        [TestCase("-18412 !")]
        [TestCase("121843 -1 * !")]
        [TestCase("110 -310 *!")]
        public void OperatorFactorial_NegativeNumberFactorial_ThrowsExcepton(string value){
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN(value));
        }
        [Test]
        public void OperatorSemifactorial_SemifactorializeNumber_ReturnCorrectResult(){
            var result = _sut.EvalRPN("5 !!");

            Assert.That(result, Is.EqualTo(15));
        }
        [Test]
        public void ComplexExpression(){
            var result = _sut.EvalRPN("1 2 ^ 1 1 7 15 + - / | * 3 * 1 1 -20 + + - | !!");

            Assert.That(result, Is.EqualTo(185794560));
        }
    }
}