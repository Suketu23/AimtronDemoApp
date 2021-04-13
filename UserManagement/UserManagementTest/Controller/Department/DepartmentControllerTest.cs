using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Controller.BaseResponseModel;
using UserManagement.Controller.Department;
using UserManagement.Database.Entities.Department;
using UserManagement.Database.Models;

namespace UserManagementTest.Controller.Department
{
    [TestClass]
    public class DepartmentControllerTest
    {
        private DepartmentController _sut;
        private IDepartmentRepository _departmentRepository;

        private Guid _departmentId1 = Guid.NewGuid();
        private Guid _departmentId2 = Guid.NewGuid();
        private Guid _departmentId3 = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            _departmentRepository = A.Fake<IDepartmentRepository>();
            _sut = new DepartmentController(_departmentRepository);

            A.CallTo(() => _departmentRepository.GetByIdAsync(_departmentId1)).Returns(new DepartmentDto(_departmentId1, "Department1"));

            A.CallTo(() => _departmentRepository.IndexAsync())
                            .Returns(new List<DepartmentDto>
                            {
                                new DepartmentDto(_departmentId1, "Department1"),
                                new DepartmentDto(_departmentId2, "Department2")
                            });

            A.CallTo(() => _departmentRepository.SaveAsync(A<DepartmentDto>._)).Returns(_departmentId3);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            // Act
            var response = await _sut.GetAsync(_departmentId1);

            // Assert
            Assert.IsNotNull(response);
            //Assert.AreEqual(_departmentId1, response.Id);
            //Assert.AreEqual("Department1", response.Name);
        }

        [TestMethod]
        public async Task IndexAsync()
        {
            // Act
            var response = await _sut.IndexAsync();

            // Assert
            Assert.IsNotNull(response);
            //Assert.IsNotNull(response.Departments);
            //Assert.AreEqual(2, response.Departments.Count());
            //Assert.AreEqual(_departmentId1, response.Departments.First().Id);
            //Assert.AreEqual("Department1", response.Departments.First().Name);
        }

        [TestMethod]
        public async Task SaveAsync()
        {
            // Act
            var response = await _sut.SaveAsync(new UserManagement.Controller.Department.Post.Request
            {
                Id = Guid.Empty,
                Name = "DepartmentNew"
            }) as BaseResponse<UserManagement.Controller.Department.Post.Response>;

            // Assert
            Assert.IsNotNull(response);
            //Assert.AreEqual(_departmentId3, response);
        }
    }
}
