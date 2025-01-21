namespace apec4_sledManagement.Library.TransferOfDataModels;

public class RepoResult
{
    public RepoResult()
    {
        Successful = null;
        Message = "";
    }

    /// <summary>
    /// true = Task Succeded; 
    /// false = Task failed; 
    /// null = No task has been run
    /// </summary>
    public bool? Successful { get; set; }
    public string Message { get; set; }
}

