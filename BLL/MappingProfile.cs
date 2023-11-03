using AutoMapper;
using BnLog.DLL.Models.Entitys;
using BnLog.DLL.Models.Security;
using BnLog.DLL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnLog.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<RegisterViewModel, User>()
            CreateMap<RegisterRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            //CreateMap<CommentCreateRequest, Comment>();
            //CreateMap<CommentEditRequest, Comment>();
            //CreateMap<PostCreateRequest, Post>();
            //CreateMap<PostEditViewModel, Post>();
            //CreateMap<TagCreateRequest, Tag>();
            //CreateMap<TagEditRequest, Tag>();
            //CreateMap<UserEditRequest, User>();
        }
    }
}
