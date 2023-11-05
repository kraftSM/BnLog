using AutoMapper;
using BnLog.DLL.Models.Security;
using BnLog.DLL.Request.Security;
using BnLog.DLL.Request.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnLog.DLL.Models.Entity;

namespace BnLog.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Security
            CreateMap<RegisterRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));
            CreateMap<UserEditRequest, User>();
            // Entity
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostEditRequest, Post>();
            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentEditRequest, Comment>();
            CreateMap<TagCreateRequest, Tag>();
            CreateMap<TagEditRequest, Tag>();
            // Item

        }
    }
}
