using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System.Diagnostics;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoApi.Tests
{
    public class TodoTasksControllerTest
    {
        private readonly TodoTasksController _controller;
        private Mock<ITodoTasksService> _mockTodoTasks;

        public TodoTasksControllerTest()
        {
            _mockTodoTasks = new Mock<ITodoTasksService>();
            _controller = new TodoTasksController(_mockTodoTasks.Object);
        }

        [Fact]
        public async Task Get_ReturnListTodoTasks_Success()
        {
            _mockTodoTasks.Setup(mockService => mockService.GetAsync())
                .Returns(Task.FromResult(new List<TodoTask>() { new TodoTask(), new TodoTask() }));

            var result = await _controller.Get();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Post_ActionExecuted_Success()
        {
            TodoTask todoTask = new TodoTask();
            _mockTodoTasks.Setup(mockService => mockService.CreateAsync(todoTask))
                .Returns(Task.FromResult(todoTask));

            var result = await _controller.Post(todoTask);

            Assert.NotNull(result);
        }
    }
}