using Microsoft.VisualStudio.TestTools.UnitTesting;
using COMP123Assignment4;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProduct()
        {
            //given
            string name = "Air Conditioner";
            decimal price = 450;
            Department dept = Department.Electronics;
            Product product = new Product();
            product.Name = name;
            product.Department = dept;
            product.Price = price;

            //when
            string prodName = product.Name;
            Department prodDepartment = product.Department;
            decimal prodPrice = product.Price;

            //then
            Assert.AreEqual("Air Conditioner", prodName);
            Assert.AreEqual(450, prodPrice);
            Assert.AreEqual(Department.Electronics, prodDepartment);

        }
        //Catalog Class 
        [TestMethod]
        public void TestGetAllProductsMethod()
        {
            //given

            Product product = new Product();
            product.Name = "Air Conditioner";
            product.Price = 300;
            product.Department = Department.Electronics;
            Catalog catalog = new Catalog();
            List<Product> list = new List<Product>();

            //when
            catalog.Add(product);
            list.Add(product);

            //then
            CollectionAssert.AreEqual(list, (System.Collections.ICollection)catalog.GetAllProducts());
        }
        
    }
}

