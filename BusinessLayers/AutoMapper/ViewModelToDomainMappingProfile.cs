﻿using System;
using AutoMapper;
using BusinessLayers.Models;
using Repositories.Models;

namespace BusinessLayers.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        public ViewModelToDomainMappingProfile()
        {
            Configure();
        }
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected  void Configure()
        {

            CreateMap<AlbumViewModel, Album>()
                .ForMember(dto => dto.Photos, opt => opt.MapFrom(scr => scr.PhotosAView))
                 .ForMember(dest => dest.Photos, opt => opt.Ignore())
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(scr => scr.CommentsAView))
                .ForMember(dto => dto.User, opt => opt.MapFrom(scr => scr.UserAView));
            //Mapper.AssertConfigurationIsValid();
            CreateMap<PhotoViewModel, Photo>()
            .ForMember(dto => dto.Album, opt => opt.MapFrom(scr => scr.AlbumPView))
            .ForMember(dto => dto.Comments, opt => opt.MapFrom(scr => scr.CommentsPView));
            CreateMap<CommentViewModel, Comment>()
                .ForMember(dto => dto.Photo, opt => opt.MapFrom(scr => scr.PhotoCView))
                .ForMember(dto => dto.User, opt => opt.MapFrom(scr => scr.UserCView))
                .ForMember(dto => dto.Album, opt => opt.MapFrom(scr => scr.AlbumCView));
            CreateMap<UserViewModel, User>()
                .ForMember(dto => dto.Albums, opt => opt.MapFrom(scr => scr.AlbumsUView))
                .ForMember(dto => dto.Photos, opt => opt.MapFrom(scr => scr.PhotosUView))
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(scr => scr.CommentsUView));
        }
    }
}