namespace FileExplorer.Application.Common.Models.Filtering;

public class FileFilterModel : FilterModelBase
{
    public bool IncludeMediaFiles { get; set; } = true;

    public bool IncludeCodes { get; set; } = true;

    public bool IncludeDocuments { get; set; } = true;

    public int PageSize { get; set; } = 20;

    public int PageToken { get; set; } = 1;
}