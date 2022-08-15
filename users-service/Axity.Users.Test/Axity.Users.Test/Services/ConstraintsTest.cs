// <summary>
// <copyright file="ConstraintsTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>
namespace Axity.Users.Test.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// Class ConstraintsTest.
    /// </summary>
    [TestFixture]
    public class ConstraintsTest
    {
        /// <summary>
        /// Method AllItemsConstraintTest.
        /// </summary>
        [Test]
        public void AllItemsConstraintTest()
        {
            int[] iarray = new int[] { 1, 2, 3 };
            string[] sarray = new string[] { "a", "b", "c" };

            Assert.That(iarray, Is.All.Not.Null);
            Assert.That(sarray, Is.All.InstanceOf<string>());
            Assert.That(iarray, Is.All.GreaterThan(0));
            Assert.That(iarray, Has.All.GreaterThan(0));
        }

        /// <summary>
        /// Method AnyOfConstraintTest.
        /// </summary>
        [Test]
        public void AnyOfConstraintTest()
        {
            var myarray = new object[] { 0, -1, 42, 100 };

            Assert.That(0, Is.AnyOf(myarray));
            Assert.That(-1, Is.AnyOf(myarray));
            Assert.That(42, Is.AnyOf(myarray));
            Assert.That(100, Is.AnyOf(myarray));

            Assert.That(42, Is.AnyOf(40, 41, 42, 43));
        }

        /// <summary>
        /// Method CollectionContainsTest.
        /// </summary>
        [Test]
        public void CollectionContainsTest()
        {
            int[] iarray = new int[] { 1, 2, 3 };
            string[] sarray = new string[] { "a", "b", "c" };
            Assert.That(iarray, Has.Member(3));
            Assert.That(sarray, Has.Member("b"));
            Assert.That(sarray, Contains.Item("c"));
            Assert.That(sarray, Has.No.Member("x"));
            Assert.That(iarray, Does.Contain(3));
        }

        /// <summary>
        /// Method BooleanConstraintTest.
        /// </summary>
        [Test]
        public void BooleanConstraintTest()
        {
            Assert.That(2.3, Is.GreaterThan(2.0).And.LessThan(3.0));
            Assert.That(3, Is.LessThan(5).Or.GreaterThan(10));
            Assert.That(2 + 2, Is.Not.EqualTo(5));
            Assert.That(true, Is.True);
            Assert.That(false, Is.False);
        }

        /// <summary>
        /// Method NullConstraintTest.
        /// </summary>
        [Test]
        public void ObjectConstraintTest()
        {
            object obj = null;
            var str = "a1";
            var s = str;
            Assert.That(obj, Is.Null);
            Assert.That(str, Is.Not.Null);

            Assert.That(str, Is.SameAs(s));
            Assert.That(str, Is.Not.SameAs($"a{1}"));
        }

        /// <summary>
        /// Method EqualsConstraintTest.
        /// </summary>
        [Test]
        public void EqualsConstraintTest()
        {
            Assert.That(2 + 2, Is.EqualTo(4.0));
            Assert.That(2 + 2 == 4);
            Assert.That(2 + 2, Is.Not.EqualTo(5));
            Assert.That(2 + 2 != 5);
            Assert.That(5.0, Is.EqualTo(5));
            Assert.That(5.5, Is.EqualTo(5).Within(0.55));
            Assert.That(5.5, Is.EqualTo(5.45).Within(1.5).Percent);
            Assert.That(2.1 + 1.2, Is.EqualTo(3.3).Within(.0005));

            Assert.That("Hello!", Is.Not.EqualTo("HELLO!"));
            Assert.That("Hello!", Is.EqualTo("HELLO!").IgnoreCase);

            DateTime now = DateTime.Now;
            DateTime later = now + TimeSpan.FromHours(1.0);

            Assert.That(now, Is.EqualTo(now));
            Assert.That(later, Is.EqualTo(now).Within(TimeSpan.FromHours(3.0)));
            Assert.That(later, Is.EqualTo(now).Within(3).Hours);
        }

        /// <summary>
        /// Method ThrowsConstraintTest.
        /// </summary>
        [Test]
        public void ThrowsConstraintTest()
        {
            Assert.That(() => this.DivisionBy(0), Throws.Exception);
            Assert.That(() => this.DivisionBy(0), Throws.TypeOf<DivideByZeroException>());
        }

        private decimal DivisionBy(int n)
        {
            return 1.0m / n;
        }
    }
}
