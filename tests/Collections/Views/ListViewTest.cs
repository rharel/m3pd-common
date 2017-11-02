using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections.Tests
{
    [TestFixture]
    public sealed class ListViewTest
    {
        private static readonly List<int> LIST = new List<int> { 0, 1, 2, 1 };

        private ListView<int> _view;

        [SetUp]
        public void Setup()
        {
            _view = new ListView<int>(LIST);
        }

        [Test]
        public void Test_Constructor_WithInvalidArgs()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ListView<int>(null)
            );
        }

        [Test]
        public void Test_IndexAccessor()
        {
            for (int i = 0; i < LIST.Count; ++i)
            {
                Assert.AreEqual(LIST[i], _view[i]);
            }
        }

        [Test]
        public void Test_Index()
        {
            for (int i = 0; i < LIST.Count; ++i)
            {
                var item = LIST[i];
                Assert.AreEqual
                (
                    LIST.IndexOf(item), 
                    _view.IndexOf(item)
                );
            }
        }
    }
}
