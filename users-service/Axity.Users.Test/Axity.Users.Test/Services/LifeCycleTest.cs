// <summary>
// <copyright file="LifeCycleTest.cs" company="Axity">
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
    using Axity.Users.Resources.Enums;
    using NUnit.Framework;

    /// <summary>
    /// LifeCycleTest class.
    /// </summary>
    [TestFixture]
    public class LifeCycleTest
    {
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Método para inicializar.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            Console.WriteLine("Se inicializa la prueba");
        }

        /// <summary>
        /// Método para limpiar.
        /// </summary>
        [OneTimeTearDown]
        public void End()
        {
            Console.WriteLine("Se terminaron las pruebas");
        }

        /// <summary>
        /// Método before.
        /// </summary>
        [SetUp]
        public void Before()
        {
            Console.WriteLine("Antes del test");
        }

        /// <summary>
        /// Método tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Después del test");
        }

        /// <summary>
        /// Método test1.
        /// </summary>
        [Test]
        public void Test1()
        {
            Console.WriteLine("Test1");
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Método test2.
        /// </summary>
        [Test]
        public void Test2()
        {
            Console.WriteLine("Test2");
            Assert.IsFalse(false);
        }

        /// <summary>
        /// A simple test.
        /// </summary>
        [Test]
        public void Add1()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        /// <summary>
        /// A test with a description property.
        /// </summary>
        [Test(Description = "My really cool test")]
        public void Add2()
        {
            Assert.AreEqual(4, 2 + 2);
        }

        /// <summary>
        /// Alternate way to specify description as a separate attribute.
        /// </summary>
        [Test]
        [Description("My really really cool test")]
        public void Add3()
        {
            Assert.AreEqual(8, 4 + 4);
        }

        /// <summary>
        /// A simple async test .
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task AddAsync()
        {
            // Agregar llamado asíncrono
            var result = await Client.GetAsync("https://restcountries.com/v3.1/all");
            Assert.NotNull(result);
            Assert.AreEqual(16, 8 + 8);
        }

        /// <summary>
        /// Test with an expected result.
        /// </summary>
        /// <returns>A value.</returns>
        [Test(ExpectedResult = 4)]
        public int TestAdd()
        {
            Assert.IsTrue(true);
            return 2 + 2;
        }

        /// <summary>
        /// DivideTest.
        /// </summary>
        /// <param name="n">The numerator.</param>
        /// <param name="d">The denominator.</param>
        /// <param name="q">The result.</param>
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        /// <summary>
        /// DivideTestWithResult.
        /// </summary>
        /// <param name="n">The numerator.</param>
        /// <param name="d">The denominator.</param>
        /// <returns>The result.</returns>
        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTestWithResult(int n, int d)
        {
            return n / d;
        }

        /// <summary>
        /// My test.
        /// </summary>
        /// <param name="x">X.</param>
        /// <param name="s">S.</param>
        [Test]
        public void MyTest([Values(1, 2, 3)] int x, [Values("A", "B")] string s)
        {
            Console.WriteLine($"x: {x}, s: {s}");
        }

        /// <summary>
        /// MyEnumTest.
        /// </summary>
        /// <param name="value">The enum value.</param>
        [Test]
        public void MyEnumTest([Values] MyEnumType value)
        {
            Console.WriteLine($"enum: {value}, value: {(int)value}");
        }

        /// <summary>
        /// MyBoolTest.
        /// </summary>
        /// <param name="value">The bool.</param>
        [Test]
        public void MyBoolTest([Values] bool value)
        {
            Console.WriteLine($"bool: {value}");
            Assert.True(true);
            Assert.IsNotNull("a");
        }

        /// <summary>
        /// Method SomeIteratorTest.
        /// </summary>
        /// <param name="n">The limit.</param>
        [TestCase(-2)]
        /*[TestCase(-1)]*/
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void SomeIteratorTest(int n)
        {
            if (n == 0)
            {
                Assert.Ignore("Valor n = 0");
            }

            /*
            if (n < 0)
            {
                Assert.Fail($"El valor límite debe ser mayor a 0, n = {n}");
            }
            */

            for (int i = 0; i < n; i++)
            {
                if (i > 5)
                {
                    Assert.Pass("Se cumple condición de salida.");
                }

                Console.WriteLine($"i={i}");
            }
        }
    }
}
