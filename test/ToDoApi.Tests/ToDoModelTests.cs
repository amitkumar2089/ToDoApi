using ToDoApi.Models;

namespace ToDoApi.Tests
{
    public class ToDoModelTests
    {
        [Fact]
        public void ToDoModel_CanChangeName()
        {
            //Arrange
            var toDoModel = new ToDoItem
            {
                Id = 1,
                Name = "complete unit tests"
            };

            //Act
            toDoModel.Name = "complete azure devops";

            //Assert
            Assert.Equal("complete azure devops", toDoModel.Name);
        }
    }
}