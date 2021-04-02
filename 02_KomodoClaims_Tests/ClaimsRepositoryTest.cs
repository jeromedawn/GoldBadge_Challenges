using _02_KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KomodoClaims_Tests
{
    [TestClass]
    public class ClaimsRepositoryTest
    {
        private ClaimsRepository _repo;
        private Claims _claims;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _claims = new Claims();
        }
        [TestMethod]
        public void CreateNewClaim_ShouldNotGetNull()
        {
            //Arrange
            //Act 
            _repo.EnterNewClaim(_claims);
            //Assert 
            Assert.IsNotNull(_claims);
        }
        [TestMethod]
        public void GetAllClaims_ShouldNotGetNull()
        {
            //Arrange
            //Act 
            _repo.SeeAllClaims();
            //Assert 
            Assert.IsNotNull(_claims);
        }
        [TestMethod]
        public void RemoveClaim()
        {
            //Arrange 
            _repo.EnterNewClaim(_claims);
            //Act
            bool testBool = _repo.ProcessClaim();
            //Assert 
            Assert.IsTrue(testBool);
        }
    }
}
