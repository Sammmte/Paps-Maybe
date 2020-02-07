using System;
using NUnit.Framework;
using Paps.Maybe;

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
        public void Get_Or_Else()
        {
            Maybe<string> maybe = Maybe<string>.Nothing;

            string hello = "hello";

            Assert.AreEqual(hello, maybe.GetOrElse(() => hello));
        }

        [Test]
        public void Return_Empty_If_Value_If_Is_Null()
        {
            string someString = null;

            Maybe<string> maybe1 = someString.ToMaybeEmptyIfNull();

            Assert.IsFalse(maybe1.HasValue);

            string someOtherString = "hello";

            Maybe<string> maybe2 = someOtherString.ToMaybeEmptyIfNull();

            Assert.IsTrue(maybe2.HasValue);
        }

        [Test]
        public void Return_Empty_If_Value_Is_Matches_Some_Value()
        {
            string nothingValue = "nothing";

            Maybe<string> maybe1 = nothingValue.ToMaybeEmptyIfMatches(nothingValue);

            Assert.IsFalse(maybe1.HasValue);

            string relevantValue = "relevant";

            Maybe<string> maybe2 = relevantValue.ToMaybeEmptyIfMatches(nothingValue);

            Assert.IsTrue(maybe2.HasValue);
        }
    }
}
