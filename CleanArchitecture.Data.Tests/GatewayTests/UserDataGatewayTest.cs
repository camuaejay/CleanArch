namespace CleanArchitecture.Data.Tests.DataGatewayTests
{
    using CleanArchitecture.Data.Gateways.Users;
    using CleanArchitecture.Data.Models.Responses;
    using CleanArchitecture.Data.SqlCommandFactories.Users;
    using CleanArchitecture.Data.Tests.DataAccess;
    using CleanArchitecture.Data.Tests.Gateways;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestClass]
    public class UserDataGatewayTest
    {
        private IUserDataGateway target;

        [TestInitialize]
        public void Setup()
        {
            this.target = new StubUserDataGateway();
        }

        [TestMethod]
        public void GetUser_ExistingUser_EqualUsername()
        {
            var input = "Test";
            var actual = this.target.GetUserByUsername(input);
            Assert.AreEqual(input, actual.Result.Username);
        }

        [TestMethod]
        public void GetUser_ResultIsNull_EqualUsername()
        {
            var input = "TestNonExisting";
            var actual = this.target.GetUserByUsername(input);
            Assert.IsNull(actual.Result);
        }
    }
}
