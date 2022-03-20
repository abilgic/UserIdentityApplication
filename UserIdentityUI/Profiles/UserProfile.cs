using AutoMapper;
using UserIdentityDAL.Models;
using UserIdentityUI.Models;

namespace UserIdentityUI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            //CreateMap<UserModel, User>();

        }
    }
}
