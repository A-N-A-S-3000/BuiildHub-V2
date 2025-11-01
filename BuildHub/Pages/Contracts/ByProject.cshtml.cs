using BuildHub.domain;
using BuildHub.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class ByProjectModel : PageModel
{
    private readonly DataService _db;
    public ByProjectModel(DataService db) => _db = db;

    public string ProjectPublicId { get; set; } = "";
    public List<Contract> Contracts { get; set; } = new();

    public void OnGet(string projectPublicId)
    {
        ProjectPublicId = projectPublicId;
        Contracts = _db.GetContractsByProject(projectPublicId);
    }
}
