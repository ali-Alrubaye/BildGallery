using System;
using AutoMapper;
using BusinessLayer.Models;
using DatalagerTow.Models;

namespace BusinessLayer.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {

            CreateMap<AlbumViewModel, Album>()
                .ForMember(dto => dto.Photos, opt => opt.MapFrom(scr => scr.PhotosAView))
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(scr => scr.CommentsAView))
                .ForMember(dto => dto.User, opt => opt.MapFrom(scr => scr.UserAView));
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