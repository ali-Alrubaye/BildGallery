
using AutoMapper;
using BusinessLayers.Models;
using Repositories.Models;

namespace BusinessLayers.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            CreateMap<Album, AlbumViewModel>()
                .ForMember(dto => dto.PhotosAView, opt => opt.MapFrom(scr => scr.Photos))
                .ForMember(dto => dto.CommentsAView, opt => opt.MapFrom(scr => scr.Comments))
                .ForMember(dto => dto.UserAView, opt => opt.MapFrom(scr => scr.User));
            CreateMap<Photo, PhotoViewModel>()
            .ForMember(dto => dto.AlbumPView, opt => opt.MapFrom(scr => scr.Album))
            .ForMember(dto => dto.CommentsPView, opt => opt.MapFrom(scr => scr.Comments));
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dto => dto.PhotoCView, opt => opt.MapFrom(scr => scr.Photo))
                .ForMember(dto => dto.UserCView, opt => opt.MapFrom(scr => scr.User))
                .ForMember(dto => dto.AlbumCView, opt => opt.MapFrom(scr => scr.Album));
            CreateMap<User, UserViewModel>()
                .ForMember(dto => dto.AlbumsUView, opt => opt.MapFrom(scr => scr.Albums))
                .ForMember(dto => dto.PhotosUView, opt => opt.MapFrom(scr => scr.Photos))
                .ForMember(dto => dto.CommentsUView, opt => opt.MapFrom(scr => scr.Comments));

        }
    }
}
