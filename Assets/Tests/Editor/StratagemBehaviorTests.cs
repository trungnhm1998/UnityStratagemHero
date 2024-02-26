using NUnit.Framework;
using StratagemHero.Gameplay;
using StratagemHero.ScriptableObjects;
using UnityEngine;

namespace Tests.Editor
{
    [TestFixture]
    public class StratagemBehaviorTests
    {
        private StratagemBehavior _behavior;
        private MockCodeProvider _codeProvider;

        [SetUp]
        public void Setup()
        {
            var gameObject = new GameObject();
            _behavior = gameObject.AddComponent<StratagemBehavior>();
            _codeProvider = gameObject.AddComponent<MockCodeProvider>();
        }

        [Test]
        public void Init_WithSingleCode_ShouldHaveAtLeastOneCode()
        {
            _codeProvider.Code = new[] { EDirection.Up };
            _behavior.Init();

            Assert.AreEqual(1, _behavior.Code.Length);
        }

        [Test]
        public void Input_WithUpCode_ShouldActivated()
        {
            bool activated = false;
            _behavior.Activated += () => activated = true;
            _codeProvider.Code = new[] { EDirection.Up };
            _behavior.Init();

            _behavior.Input(EDirection.Up);

            Assert.IsTrue(activated);
        }

        [Test]
        public void Input_WithWrongCode_ShouldNotActivate()
        {
            bool activateFailed = false;
            _behavior.ActivateFailed += () => activateFailed = true;
            _codeProvider.Code = new[] { EDirection.Up };
            _behavior.Init();

            _behavior.Input(EDirection.Down);

            Assert.IsTrue(activateFailed);
        }

        [Test]
        public void Input_WithMultipleCode_ShouldActivatedWhenAllIsCorrect()
        {
            bool activated = false;
            _behavior.Activated += () => activated = true;
            var code = new[]
                { EDirection.Up, EDirection.Down, EDirection.Right, EDirection.Left, EDirection.Up };
            _codeProvider.Code = code;
            _behavior.Init();

            foreach (var direction in code)
            {
                _behavior.Input(direction);
            }

            Assert.IsTrue(activated);
        }

        [Test]
        public void Input_WithMultipleCode_ShouldNotActivateWhenOneIsWrong()
        {
            bool activateFailed = false;
            _behavior.ActivateFailed += () => activateFailed = true;
            var code = new[]
                { EDirection.Up, EDirection.Down, EDirection.Right, EDirection.Left, EDirection.Up };
            
            var wrongCode = new[]
                { EDirection.Up, EDirection.Down, EDirection.Right, EDirection.Left, EDirection.Left };
            _codeProvider.Code = code;
            _behavior.Init();

            foreach (var direction in wrongCode)
            {
                _behavior.Input(direction);
            }

            Assert.IsTrue(activateFailed);
        }
    }

    public class MockCodeProvider : MonoBehaviour, IStratagemCodeProvider
    {
        public EDirection[] Code;
        public EDirection[] GetCode() => Code;
    }
}