using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Entity;
using BnLog.VAL.Request.Security;
using BnLog.VAL.Response.Account;

namespace BnLog.VAL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Security
            CreateMap<UserRegisterRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));
            CreateMap<User,AccountInfo>();
            CreateMap<AccountInfo,User>();
            CreateMap<UserEditRequest, User>();
            // Entity
            CreateMap<PostCreateRequest, Post>();
            CreateMap<PostEditRequest, Post>();
            CreateMap<PostInfo, Post>();
            CreateMap<Post, PostInfo>();
            //Entity - comment
            CreateMap<Comment, CommentRequest>();
            CreateMap<CommentRequest, Comment>();
            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentRequest, CommentCreateRequest>(); //API Create
            //Entity - tag
            //CreateMap<CommentEditRequest, Comment>();
            CreateMap<TagCreateRequest, Tag>();
            CreateMap<TagEditRequest, Tag>(); 
            CreateMap<TagSelectInfo, Tag>();
            CreateMap<Tag, TagEditRequest>();
            //CreateMap<TagInfo, Tag>();

            // Item

            }
    }
}
