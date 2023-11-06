﻿using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Security;
using BnLog.DAL.Request.Entity;
using BnLog.DAL.Request.Security;

namespace BnLog.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Security
            CreateMap<UserRegisterRequest, User>()
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
