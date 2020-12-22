using AppSample.Entities;
using System;
using System.Text.Json;

namespace AppSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User
            {
                Id = 1,
                Name = "Lucas",
                Password = "123"
            };

           var userDTO1 = Mapper.Map<User, UserDTO>(user1);

            Console.WriteLine(JsonSerializer.Serialize(user1));
            Console.WriteLine(JsonSerializer.Serialize(userDTO1));


            var userDTO2 = new UserDTO
            {
                Id = 1,
                Name = "Lucas",
                Password = "123"
            };

            var user2 = Mapper.Map<UserDTO, User>(userDTO2);

            Console.WriteLine(JsonSerializer.Serialize(user2));
            Console.WriteLine(JsonSerializer.Serialize(userDTO2));
        }
    }
}
