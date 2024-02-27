using NSubstitute;
using NUnit.Framework;
using StratagemHero.Gameplay;
using StratagemHero.ScriptableObjects;

namespace Tests.Editor
{
    [TestFixture]
    public class StratagemBehaviourTests
    {
        private StratagemBehaviour _behaviour;
        private IModel _codeProvider;

        private bool _activated = false;

        [SetUp]
        public void Setup()
        {
            _codeProvider = Substitute.For<IModel>();
            _behaviour = new StratagemBehaviour(_codeProvider);

            _behaviour.Activated += Behaviour_Activated;
            _behaviour.ActivateFailed += Behaviour_ActivateFailed;
        }

        [TearDown]
        public void Teardown()
        {
            _activated = false;
            _behaviour.Activated -= Behaviour_Activated;
            _behaviour.ActivateFailed -= Behaviour_ActivateFailed;
        }

        private void Behaviour_ActivateFailed()
        {
            _activated = false;
        }

        private void Behaviour_Activated() => _activated = true;

        [TestCase(new[] { EDirection.Up })]
        [TestCase(new[] { EDirection.Right })]
        [TestCase(new[] { EDirection.Down })]
        [TestCase(new[] { EDirection.Left })]
        [TestCase(new[] { EDirection.Up, EDirection.Down, EDirection.Right, EDirection.Left, EDirection.Up })]
        public void Input_CorrectCode_ShouldActivate(EDirection[] code)
        {
            _codeProvider.Code.Returns(code);

            foreach (var direction in code)
            {
                _behaviour.Input(direction);
            }

            Assert.IsTrue(_activated);
        }

        [TestCase(new[] { EDirection.Up }, new[] { EDirection.Down })]
        [TestCase(new[] { EDirection.Right }, new[] { EDirection.Invalid })]
        [TestCase(new[] { EDirection.Up, EDirection.Down, EDirection.Right, EDirection.Left, EDirection.Up },
            new[] { EDirection.Up, EDirection.Down, EDirection.Right, EDirection.Left, EDirection.Down })]
        public void Input_WrongCode_ShouldNotActivate(EDirection[] code, EDirection[] codeToInput)
        {
            _activated = true;
            _codeProvider.Code.Returns(code);

            foreach (var direction in codeToInput)
            {
                _behaviour.Input(direction);
            }

            Assert.IsFalse(_activated);
        }
    }
}