using UnityEngine;
using NUnit.Framework;
using Paps.Maybe;
using System;
using System.Collections.Generic;
using NSubstitute;

namespace Tests
{
    public class MaybeShould
    {
        [Test]
        public void Have_No_Value_If_Nothing_Or_Default_Constructor_Is_Used()
        {
            Maybe<string> maybe = new Maybe<string>();

            Assert.IsFalse(maybe.HasValue);

            maybe = Maybe<string>.Nothing;

            Assert.IsFalse(maybe.HasValue);
        }

        [Test]
        public void Throw_An_Exception_If_User_Tries_To_Get_Value_And_This_Is_Not_Present()
        {
            Maybe<string> maybe = Maybe<string>.Nothing;

            Assert.Throws<InvalidOperationException>(() => Debug.Log(maybe.Value));
        }

        [Test]
        public void Match_Equality()
        {
            Maybe<string> maybe1 = Maybe<string>.Nothing;
            Maybe<string> maybe2 = new Maybe<string>();

            Assert.IsTrue(maybe1 == maybe2);

            maybe1 = new Maybe<string>("hello");
            maybe2 = new Maybe<string>("hello");

            Assert.IsTrue(maybe1 == maybe2);

            maybe2 = new Maybe<string>("bye");

            Assert.IsFalse(maybe1 == maybe2);
        }

        [Test]
        public void Use_Provided_Equality_Comparer()
        {
            IEqualityComparer<string> equalityComparer = Substitute.For<IEqualityComparer<string>>();

            equalityComparer.Equals(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

            Maybe<string> maybe1 = new Maybe<string>("hello", equalityComparer);
            Maybe<string> maybe2 = new Maybe<string>("hello", equalityComparer);

            maybe1.Equals(maybe2);

            equalityComparer.Received().Equals(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void Generate_Same_Hash_Code_If_Has_Same_Values()
        {
            Maybe<string> maybe1 = new Maybe<string>("hello");
            Maybe<string> maybe2 = new Maybe<string>("hello");

            Assert.AreEqual(maybe1.GetHashCode(), maybe2.GetHashCode());
        }

        [Test]
        public void Return_Empty_When_Value_Is_Null()
        {
            string someString = null;

            Maybe<string> maybe1 = new Maybe<string>(someString);

            Assert.IsFalse(maybe1.HasValue);
        }
    }
}