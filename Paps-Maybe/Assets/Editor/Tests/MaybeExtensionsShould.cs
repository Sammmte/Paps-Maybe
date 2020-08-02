using System;
using NUnit.Framework;
using Paps.Maybe;
using NSubstitute;

namespace Tests
{
    public class MaybeExtensionsShould
    {
        [Test]
        public void Transform_To_Maybe_Any_Object()
        {
            Test("hello");
            Test(1);
            Test(new object());

            void Test<T>(T value)
            {
                Maybe<T> maybe = value.ToMaybe();

                Assert.IsTrue(maybe.HasValue);
                Assert.AreEqual(maybe.Value, value);
            }
        }

        [Test]
        public void Return_Value_Or_Default()
        {
            Maybe<string> maybe = Maybe<string>.Nothing;

            string hello = "hello";

            Assert.AreEqual(hello, maybe.GetOrDefault(hello));
        }

        [Test]
        public void Execute_Action_When_Has_Value()
        {
            //Given
            string someValue = "value";
            var action = Substitute.For<Action<string>>();

            //When
            someValue.ToMaybe().Do(action);

            //Then
            action.Received(1).Invoke(someValue);
        }

        [Test]
        public void Execute_Action_When_Does_Not_Has_Value()
        {
            //Given
            string someValue = null;
            var action = Substitute.For<Action>();

            //When
            someValue.ToMaybe().OrElse(action);

            //Then
            action.Received(1).Invoke();
        }

        [Test]
        public void Create_Nothing_When_Condition_Returns_True()
        {
            //Given
            string someValue = "value";

            //When
            var maybe = someValue.AsNothingWhen(() => true);

            //Then
            Assert.That(maybe.IsNothing(), "Is nothing");
        }

        [Test]
        public void Return_Value_As_Maybe_When_Condition_Returns_False()
        {
            //Given
            string someValue = "value";

            //When
            var maybe = someValue.AsNothingWhen(() => false);

            //Then
            Assert.That(maybe.IsSomething(), "Is something");
        }
    }
}
