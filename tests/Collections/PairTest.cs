using NUnit.Framework;

namespace rharel.M3PD.Common.Collections.Tests
{
    [TestFixture]
    public sealed class PairTest
    {
        private static readonly int FIRST = 1;
        private static readonly int SECOND = 2;

        private Pair<int> _pair;

        [SetUp]
        public void Setup()
        {
            _pair = new Pair<int>(FIRST, SECOND);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(FIRST, _pair.First);
            Assert.AreEqual(SECOND, _pair.Second);
        }

        [Test]
        public void Test_Equality()
        {
            var original = _pair;
            var good_copy = new Pair<int>(original.First, original.Second);
            var flawed_first_copy = new Pair<int>(
                original.First + 1, 
                original.Second
            );
            var flawed_second_copy = new Pair<int>(
                original.First,
                original.Second + 1
            );

            Assert.AreNotEqual(original, null);
            Assert.AreNotEqual(original, "incompatible type");
            Assert.AreNotEqual(original, flawed_first_copy);
            Assert.AreNotEqual(original, flawed_second_copy);

            Assert.AreEqual(original, original);
            Assert.AreEqual(original, good_copy);
        }
    }
}
