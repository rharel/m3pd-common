using Moq;
using NUnit.Framework;
using System;

namespace rharel.M3PD.Common.Collections.Tests
{
    [TestFixture]
    public sealed class ImmutableCollectionExtensionsTest
    {
        private Mock<ImmutableCollection<int>> _collection;

        [SetUp]
        public void Setup()
        {
            _collection = new Mock<ImmutableCollection<int>>();
        }

        [Test]
        public void Test_IsEmpty_WithInvalidArgs()
        {
            Assert.Throws<ArgumentNullException>(
                () => ((ImmutableCollection<int>)null).IsEmpty()
            );
        }
        [Test]
        public void Test_IsEmpty_OnNonEmptyCollection()
        {
            _collection.SetupGet(c => c.Count)
                       .Returns(1);

            Assert.IsFalse(_collection.Object.IsEmpty());
        }
        [Test]
        public void Test_IsEmpty_OnEmptyCollection()
        {
            _collection.SetupGet(c => c.Count)
                       .Returns(0);

            Assert.IsTrue(_collection.Object.IsEmpty());
        }
    }
}
