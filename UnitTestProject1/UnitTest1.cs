using BusinessProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BankAccount account = new BankAccount();
            account.Owner.Value = "Anders";

            account.Balance.Value = 100;
            //account.Balance.BusinessRules.Add(balance => balance >= 0);

            Assert.AreEqual("Anders", account.Owner.Value);
            Assert.AreEqual(100, account.Balance.Value);

            // TODO null check på add
            // TODO dis-allow duplicates
            // TODO += and -= syntax
            account.Owner.BusinessRules.Add((oldValue, newValue) => newValue != null && newValue.Length >= 2);
            try
            {
                account.Owner.Value = "A";
                Assert.Fail();
            }
            catch (BusinessException ex)
            {
                // TODO assert something about ex
            }

            account.Owner.Value = "An";

            account.Balance.BusinessRules.Add(
                (oldBalance, newBalance) => newBalance >= 0);
            try
            {
                account.Balance.Value = -1;
                Assert.Fail();
            }
            catch (BusinessException) { }

            account.Balance.BusinessRules.Add(
                (oldBalance, newBalance) => oldBalance - newBalance <= 100);
            account.Balance.Value = 700;

            account.Balance.Value = 600;
            try
            {
                account.Balance.Value = 499;
            }
            catch (BusinessException) { }

            account.BusinessRules.Add((oldState, newState) => newState.Owner.Value.Equals("Anders") || newState.Balance.Value >= 0);
        }
    }
}
