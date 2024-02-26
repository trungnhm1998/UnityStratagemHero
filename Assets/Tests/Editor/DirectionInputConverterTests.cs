using NUnit.Framework;
using StratagemHero.Gameplay;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace Tests.Editor
{
    [TestFixture]
    public class DirectionInputConverterTests
    {
        private IInputConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new DirectionInputConverter();
        }

        [Test]
        public void Convert_WhenInputIsPositiveXAxis_ReturnsRight()
        {
            var result = _converter.Convert(new Vector2(1, 0));
            Assert.AreEqual(EDirection.Right, result);
        }

        [Test]
        public void Convert_WhenInputIsNegativeXAxis_ReturnsLeft()
        {
            var result = _converter.Convert(new Vector2(-1, 0));
            Assert.AreEqual(EDirection.Left, result);
        }

        [Test]
        public void Convert_WhenInputIsPositiveYAxis_ReturnsUp()
        {
            var result = _converter.Convert(new Vector2(0, 1));
            Assert.AreEqual(EDirection.Up, result);
        }

        [Test]
        public void Convert_WhenInputIsNegativeYAxis_ReturnsDown()
        {
            var result = _converter.Convert(new Vector2(0, -1));
            Assert.AreEqual(EDirection.Down, result);
        }

        [Test]
        public void Convert_WhenInputIsZero_ReturnsInvalid()
        {
            var result = _converter.Convert(new Vector2(0, 0));
            Assert.AreEqual(EDirection.Invalid, result);
        }

        [Test]
        public void Convert_WhenInputIsPositiveXAxisAndYAxis_ReturnsRight()
        {
            var result = _converter.Convert(new Vector2(1, 1));
            Assert.AreEqual(EDirection.Right, result);
        }

        [Test]
        public void Convert_WhenInputIsNegativeXAxisAndYAxis_ReturnsLeft()
        {
            var result = _converter.Convert(new Vector2(-1, -1));
            Assert.AreEqual(EDirection.Left, result);
        }
    }
}