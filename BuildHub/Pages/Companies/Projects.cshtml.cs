using BuildHub.domain;
using BuildHub.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BuildHub.Pages.Companies
{
    public class ProjectsModel : PageModel
    {
        private readonly DataService _db;
        public ProjectsModel(DataService db) => _db = db;

        public Company? Company { get; set; }
        public List<CompanyProject> Projects { get; set; } = new();

        public void OnGet(int companyId)
        {
            Company = _db.GetAllCompany().FirstOrDefault(c => c.Id == companyId);
            Projects = _db.GetCompanyProjects(companyId);
        }
    }
}
