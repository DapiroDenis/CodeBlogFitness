using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingContollerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingControler = new EatingContoller(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50,500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            //Act
            eatingControler.Add(food,100);

            //Assert
            Assert.AreEqual(food.Name, eatingControler.Eating.Foods.First().Key.Name);
        }
    }
}