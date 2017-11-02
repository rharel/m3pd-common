using NUnit.Framework;
using System;

namespace rharel.M3PD.Common.DesignPatterns.Tests
{
    [TestFixture]
    public sealed class ObjectBuilderTest
    {
        private sealed class MockObjectBuilder: ObjectBuilder<bool>
        {
            protected override bool CreateObject()
            {
                return true;
            }
        }

        private MockObjectBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new MockObjectBuilder();
        }

        [Test]
        public void Test_InitialState()
        {
            Assert.IsFalse(_builder.IsBuilt);
        }

        [Test]
        public void Test_Build()
        {
            Assert.IsTrue(_builder.Build());
            Assert.IsTrue(_builder.Object.Contains(true));
            Assert.IsTrue(_builder.IsBuilt);
        }
        [Test]
        public void Test_Build_OnAnAlreadyBuiltObject()
        {
            _builder.Build();

            Assert.Throws<InvalidOperationException>(() => _builder.Build());
        }
    }
}
