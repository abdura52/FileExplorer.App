using AutoMapper;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<FileInfo, StorageFile>()
            .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Name))
            .ForMember(src => src.Path, opt => opt.MapFrom(dest => dest.FullName))
            .ForMember(src => src.DirectoryPath, opt => opt.MapFrom(dest => dest.Directory))
            .ForMember(src => src.Size, opt => opt.MapFrom(dest => dest.Length))
            .ForMember(src => src.Extension, opt => opt.MapFrom(dest => dest.Extension));
    }
}
