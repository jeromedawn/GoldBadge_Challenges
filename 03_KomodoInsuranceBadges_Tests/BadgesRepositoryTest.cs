using _03_KomodoInsuranceBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_KomodoInsuranceBadges_Tests
{
    [TestClass]
    public class BadgesRepositoryTest
    {
        private BadgesRepository _repo;
        private Badges _badges;
        //Arrange
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            _badges = new Badges(new List<string> { "A1", "A3", "A6" });
            _repo.AddABadge(_badges);
        }
        [TestMethod]
        public void AddABadge_ShouldNotGetNull()
        {
           //Act 
            _repo.AddABadge(_badges);
            //Assert
            Assert.IsNotNull(_badges);
        }
        [TestMethod]
        public void RemoveDoor_ShouldGetTrue()
        {
            //Act
            Badges badges = _repo.GetDictionaryBadgesById(1);
            //Assert
            Assert.IsTrue(_repo.RemoveDoor("A1",badges.BadgeID));
        }
        [TestMethod]
        public void AddDoor_ShouldGetTrue()
        {
            //Act 
            Badges badges = _repo.GetDictionaryBadgesById(1);
            //Assert 
            Assert.IsTrue(_repo.AddDoor("A2", badges.BadgeID));
        }
        [TestMethod]
        public void GetAllBadges_ShouldNotGetNull()
        {
            //Arrange
            //Act 
            _repo.GetDictionaryAllBadges();
            //Assert
            Assert.IsNotNull(_badges);
        }
    }
}
