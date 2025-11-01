using BuildHub.domain;
using BuildHub.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BuildHub.Pages.Projects
{
    public class ProjectsIndexModel : PageModel
    {
        private readonly DataService _db;
        public ProjectsIndexModel(DataService db) => _db = db;

        public List<Project> Projects { get; private set; } = new();

        public void OnGet() => Projects = _db.GetAllProjects();
    }
}
