using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Business_Back.Tests.Security
{
    public class RolBusinessTests
    {
        private readonly Mock<IRolData> _mockRolData;
        private readonly RolBusiness _rolBusiness;

        public RolBusinessTests()
        {
            // Arrange (simulación de dependencias)
            _mockRolData = new Mock<IRolData>();

            var configuration = new ConfigurationBuilder().Build(); // config vacío
            var logger = NullLogger<RolBusiness>.Instance;

            _rolBusiness = new RolBusiness(configuration, _mockRolData.Object, logger);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfRoles()
        {
            // Arrange
            var roles = new List<Rol>
            {
                new Rol { Id = 1, Name = "Admin" },
                new Rol { Id = 2, Name = "User" }
            };

            _mockRolData.Setup(r => r.GetAll()).ReturnsAsync(roles);

            // Act
            var result = await _rolBusiness.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, r => r.Name == "Admin");
        }

        [Fact]
        public async Task Save_ShouldReturnCreatedRole()
        {
            // Arrange
            var rolDto = new RolCreatedDto { Name = "NewRole" };
            var rolEntity = new Rol { Id = 10, Name = "NewRole" };

            _mockRolData.Setup(r => r.Save(It.IsAny<Rol>())).ReturnsAsync(rolEntity);

            // Act
            var result = await _rolBusiness.Save(rolDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Id);
            Assert.Equal("NewRole", result.Name);
        }

        [Fact]
        public async Task GetById_ShouldReturnRole_WhenExists()
        {
            // Arrange
            var rolEntity = new Rol { Id = 5, Name = "Manager" };
            _mockRolData.Setup(r => r.GetById(5)).ReturnsAsync(rolEntity);

            // Act
            var result = await _rolBusiness.GetById(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Manager", result.Name);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrue_WhenRoleExists()
        {
            // Arrange
            _mockRolData.Setup(r => r.Delete(3)).ReturnsAsync(true);

            // Act
            var result = await _rolBusiness.Delete(3);

            // Assert
            Assert.True(result);
        }
    }
}
