using BuildHub.domain;
using BuildHub.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class CompaniesIndexModel : PageModel
{
    private readonly DataService _db;
    public CompaniesIndexModel(DataService db) => _db = db;

    public List<Company> Companies { get; set; } = new();

    public void OnGet() => Companies = _db.GetAllCompany();
}
