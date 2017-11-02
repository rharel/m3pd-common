using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections.Tests
{
    [TestFixture]
    public sealed class CollectionViewTest
    {
        private static readonly List<int> LIST = new List<int> { 0, 1, 2, 1 };

        private CollectionView<int> _view;

        [SetUp]
        public void Setup()
        {
            _view = new CollectionView<int>(LIST);
        }

        [Test]
        public void Test_Constructor_WithInvalidArgs()
        {
            Assert.Throws<ArgumentNullException>(
                () => new CollectionView<int>(null)
            );
        }

        [Test]
        public void Test_Count()
        {
            Assert.AreEqual(LIST.Count, _view.Count);
        }

        [Test]
        public void Test_Contains()
        {
            Assert.IsFalse(_view.Contains(-1));
            foreach (int item in LIST)
            {
                Assert.IsTrue(_view.Contains(item));
            }
        }

        [Test]
        public void Test_GetEnumerator()
        {
            var a = LIST.GetEnumerator();
            var b = _view.GetEnumerator();

            while (a.MoveNext())
            {
                b.MoveNext();
                Assert.AreEqual(a.Current, b.Current);
            }
        }
    }
}
