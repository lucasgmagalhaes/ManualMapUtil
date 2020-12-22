using AppSample.Entities;

namespace AppSample
{
    public static class Maps
    {
        public static User UserDTOToUser(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Password = userDTO.Password
            };
        }

        public static UserDTO UserToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }
    }
}
