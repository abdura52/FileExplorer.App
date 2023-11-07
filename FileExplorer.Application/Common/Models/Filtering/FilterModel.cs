namespace FileExplorer.Application.Common.Models.Filtering;

public class FilterModel : FilterPagination
{
    public bool IncludeFiles { get; set; } = true;

    public bool IncludeDirectories { get; set; } = true;
}
