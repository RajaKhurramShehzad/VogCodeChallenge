using Microsoft.VisualStudio.TestTools.UnitTesting;
using VogCodeChallengeTask7;

namespace VogCodeChallenge.Tests
{
    [TestClass]
    public class QuestionClassUnitTests
    {
        [TestMethod]
        public void IterateList_Good()
        {
            var questionClass = new QuestionClass();
            var ret = questionClass.IterateList();
            Assert.AreEqual(ret.Count, 3);
            Assert.AreEqual(ret[0], "Jimmy");
            Assert.AreEqual(ret[1], "Jeffrey");
            Assert.AreEqual(ret[2], "John");

        }
    }
}
