using AppSample;
using AppSample.Entities;
using System;
using Xunit;

namespace ManualMapUtil.Test
{
    public class MapperBuilderTest
    {

        [Fact]
        public void ShouldMap()
        {
            var builder = new MapperBuilder();
            builder.AddMap<User, UserDTO>(UserToUserDTO);
            var user = new User()
            {
                Id = 1,
                Name = "Lucas"
            };

            var userDTO = builder.Invoke<User, UserDTO>(user);
            Assert.Equal(user.Id, userDTO.Id);
            Assert.Equal(user.Name, userDTO.Name);
        }

        [Fact]
        public void ShouldThrowError()
        {
            var builder = new MapperBuilder();
            builder.AddMap<User, UserDTO>(UserToUserDTO);
            var user = new UserDTO()
            {
                Id = 1,
                Name = "Lucas"
            };

            Assert.Throws<MapNotDefinedException>(() => builder.Invoke<UserDTO, User>(user));
        }

        [Fact]
        public void ShouldReturnDefaultValue()
        {
            var builder = new MapperBuilder();
            builder.AddMap<User, UserDTO>(UserToUserDTO);

            var userDTO = builder.Invoke<User, UserDTO>(null);
            Assert.Null(userDTO);
        }

        [Fact]
        public void MapFunctionShouldThrowError()
        {
            var builder = new MapperBuilder();
            builder.AddMap<UserDTO, User>(BrokenMap);

            Assert.Throws<MapFunctionException>(() => builder.Invoke<UserDTO, User>(new UserDTO()));
        }

        [Fact]
        public void ShouldThrowErrorForNullMapFunction()
        {
            var builder = new MapperBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.AddMap<UserDTO, User>(null));
        }

        internal static UserDTO UserToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        internal static User BrokenMap(UserDTO userdto)
        {
            throw new Exception();
        }
    }
}
