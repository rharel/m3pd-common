using NUnit.Framework;

namespace rharel.M3PD.Common.Hashing.Tests
{
    [TestFixture]
    public sealed class HashCombinerTest
    {
        private int _hash;

        [SetUp]
        public void Setup()
        {
            _hash = HashCombiner.Initialize();
        }

        [Test]
        public void Test_Hash_WithNumericOverflow()
        {
            Assert.DoesNotThrow(
                () => _hash = HashCombiner.Hash(_hash, int.MaxValue)
            );
        }
    }
}
