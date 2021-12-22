using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VogCodeChallengeTask8;

namespace VogCodeChallenge.Tests
{
    [TestClass]
    public class SwitchStatementClassUnitTests
    {
        [TestMethod]
        public void SwitchStament_GreaterThen1LessThen4_Good()
        {
            var wwitchStatementClass = new SwitchStatementClass();
            var intPut = 3;
            var ret = wwitchStatementClass.TESTModule<int>(ref intPut);
            Assert.AreEqual(ret, 6);
        }
        [TestMethod]
        public void SwitchStament_GreaterThen4_Good()
        {
            var wwitchStatementClass = new SwitchStatementClass();
            var intPut = 8;
            var ret = wwitchStatementClass.TESTModule<int>(ref intPut);
            Assert.AreEqual(ret, 24);
        }
        [TestMethod]
        public void SwitchStament_LessThen1_Good()
        {
            var wwitchStatementClass = new SwitchStatementClass();
            var intPut = -4;
            try
            {
                var ret = wwitchStatementClass.TESTModule<int>(ref intPut);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Exception as value is less then 1");
            }
            
        }

        [TestMethod]
        public void SwitchStament_FloatValue1_Good()
        {
            var wwitchStatementClass = new SwitchStatementClass();
            var intPut = 1.0f;
            
            var ret = wwitchStatementClass.TESTModule<float>(ref intPut);
            Assert.AreEqual(ret, 3.0f);

        }
        [TestMethod]
        public void SwitchStament_FloatValue2_Good()
        {
            var wwitchStatementClass = new SwitchStatementClass();
            var intPut = 2.0f;
            var ret = wwitchStatementClass.TESTModule<float>(ref intPut);
            Assert.AreEqual(ret, 3.0f);

        }

        [TestMethod]
        public void SwitchStament_StringValue_Good()
        {
            var wwitchStatementClass = new SwitchStatementClass();
            var intPut = $"Unit test to test switch statment";

            var ret = wwitchStatementClass.TESTModule<string>(ref intPut);
            Assert.AreEqual(ret, "UNIT TEST TO TEST SWITCH STATMENT");
        }
    }
}
