namespace JADE_BARNACLE_API.Domain.Tests;

using Jade.Barnacle.Domain.Catalog;
using JADE_BARNACLE_API;

[TestClass]
public class RatingTests
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        //Arrange
        var rating = new Rating(1, "Mike", "Great fit!");
        //Act (empty)

        //Assert
        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }
}

[TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Can_Create_New_Item()
        {
            // Arrange
            var item = new Item("Name", "Description", "Brand", 10.00m);

            // Act (no actions needed for this test)

            // Assert
            Assert.AreEqual("Name", item.Name);
            Assert.AreEqual("Description", item.Description);
            Assert.AreEqual("Brand", item.Brand);
            Assert.AreEqual(10.00m, item.Price);
        }
    }

[TestClass]
public class ItemTests
{
    [TestMethod]
    public void Can_Create_Add_Rating()
    {
        // Arrange
        var item = new Item("Name", "Description", "Brand", 10.00m);
        var rating = new Rating(5, "Name", "Review");

        // Act
        item.AddRating(rating);

        // Assert
        Assert.AreEqual(rating, item.Ratings[0]);
    }
}
