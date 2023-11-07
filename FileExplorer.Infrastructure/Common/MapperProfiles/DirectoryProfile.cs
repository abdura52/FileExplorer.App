using AutoMapper;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<DirectoryInfo, StorageDirectory>()
            .ForMember(src => src.Name, dest => dest.MapFrom(opt => opt.Name))
            .ForMember(src => src.Path, dest => dest.MapFrom(opt => opt.FullName))
            .ForMember(src => src.ItemsCount, dest => dest.MapFrom(opt => opt.GetFileSystemInfos().Count()));
    }
}
