using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class MenuRepositoryTest
    {
        private MenuRepository _repo;
        private Menu _item;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _item = new Menu();
            _item.ItemName = "Orange Bliss";
        }
        //Create & Read Menu Item Method Test 
        [TestMethod]
        public void CreateNewMenuItem_ShouldNotGetNull()
        {
            //Arrange
            //Act 
            _repo.CreateMenuItem(_item);
            Menu itemFromMenu = _repo.ReadMenuItemByName("Orange Bliss");
            //Assert
            Assert.IsNotNull(itemFromMenu);
            Console.WriteLine(_item.ItemName);
        }
        //Delete Menu Item Method Test 
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //Arragne 
            _repo.CreateMenuItem(_item);
            //Act 
            bool deleteResult = 
            _repo.DeleteMenuItem("Orange Bliss");
            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
