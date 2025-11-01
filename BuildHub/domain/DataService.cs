using BuildHub.Models;

namespace BuildHub.domain
{
    public class DataService
    {
        private readonly List<User> users = new();
        private readonly List<Project> projects = new();

        private readonly List<Company> companies = new();
        private readonly List<CompanyProject> companyProjects = new();

        private readonly List<BrokerRequest> brokerRequests = new();
        private readonly List<BrokerBid> brokerBids = new();
        private readonly List<Contract> contracts = new();




        private int userIdCounter = 1;
        private int projectIdCounter = 1;
        private int companyIdCounter = 1;

        private int companyProjectIdCounter = 1;
        private int brokerRequestIdCounter = 1;
        private int brokerBidIdCounter = 1;

        private int contractIdCounter = 1;

        public User AddUser(string email, string password, string userType)
        {
            var user = new User
            {
                Id = userIdCounter++,
                Email = email,
                Password = password,
                UserType = userType
            };
            users.Add(user);
            return user;
        }


        public List<User> GetAllUsers()
        {
            return users;
        }

        //////////////////////////////////// PRojects (homeowner) CRUD ///////////////////////////////////////

        public List<Project> GetAllProjects()
        {
            return projects;
        }

        public Project AddProject(string status, string location, int floors, string krokiNumber, int userId, string? imagePath)
        {
            var project = new Project
            {
                Id = projectIdCounter++,
                status = status,
                Location = location,
                Floors = floors,
                KrokiNumber = krokiNumber,
                UserId = userId,
                ImagePath = imagePath,
                CreatedAt = DateTime.Now
            };
            projects.Add(project);

            // add project to the user list
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Projects.Add(project);
            }
            return project;
        }

        public Project? UpdateProject(int projectId, string status, string location, int floors, string krokiNumber, int userId, string? imagePath)
        {
            var projectIndex = projects.FindIndex(p => p.Id == projectId);
            if (projectIndex < 0) return null;

            var project = projects[projectIndex];
            project.status = status;
            project.ImagePath = imagePath;
            project.Location = location;
            project.Floors = floors;
            project.KrokiNumber = krokiNumber;
            project.UserId = userId;

            projects[projectIndex] = project;
            return project;
        }

        public void DeleteProject(int projectId)
        {
            var project = projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                projects.Remove(project);
                var user = users.FirstOrDefault(u => u.Id == project.UserId);
                if (user != null)
                {
                    user.Projects.Remove(project);
                }
            }
        }


        //////////////////////////////////// COMPANIES (brokers) CRUD ///////////////////////////////////////

        public Company AddCompany(string name, string? tier = null, string type = "broker")
        {
            var company = new Company
            {
                Id = companyIdCounter++,
                Name = name,
                Tier = tier,
                Type = type,
                CreatedAt = DateTime.Now
            };
            companies.Add(company);
            return company;
        }

        public Company? UpdateCompany(int companyId, string name, string? tier = null, string type = "broker")
        {
            var companyIndex = companies.FindIndex(c => c.Id == companyId);
            var company = companies[companyIndex];
            if (company != null)
            {
                company.Name = name;
                company.Tier = tier;
                company.Type = type;
                companies[companyIndex] = company;
                return company;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCompany(int companyId)
        {
            var company = companies.FirstOrDefault(c => c.Id == companyId);
            if (company != null)
            {
                companies.Remove(company);
            }
        }

        public List<Company> GetAllCompany()
        {
            return companies;
        }


        ///////////////////////////////////// COMPANY PAST PROJECTS (portfolio) CRUD ///////////////////////////////////////

        public CompanyProject AddCompanyProject(int companyId, string title, string location, int floors, string? description, string? imagePath)
        {
            var companyProject = new CompanyProject
            {
                Id = companyProjectIdCounter++,
                CompanyId = companyId,
                Title = title,
                Location = location,
                Floors = floors,
                Description = description,
                ImagePath = imagePath,
                CreatedAt = DateTime.Now
            };
            companyProjects.Add(companyProject);

            // add project to the company list
            var company = companies.FirstOrDefault(c => c.Id == companyId);
            if (company != null)
            {
                company.PastProjects.Add(companyProject);
            }
            return companyProject;

        }

        public List<CompanyProject> GetCompanyProjects(int companyId)
        {
            return companyProjects.Where(p => p.CompanyId == companyId).ToList();
        }

        public void DeleteCompanyProject(int companyProjectId)
        {
            var companyProject = companyProjects.FirstOrDefault(cp => cp.Id == companyProjectId);
            if (companyProject != null)
            {
                companyProjects.Remove(companyProject);
                var company = companies.FirstOrDefault(c => c.Id == companyProject.CompanyId);
                if (company != null)
                {
                    company.PastProjects.Remove(companyProject);
                }
            }
        }

        public CompanyProject? UpdateCompanyProject(int companyProjectId, int companyId, string title, string location, int floors, string? description, string? imagePath)
        {
            var companyProjectIndex = companyProjects.FindIndex(cp => cp.Id == companyProjectId);
            var companyProject = companyProjects[companyProjectIndex];
            if (companyProject != null)
            {
                companyProject.CompanyId = companyId;
                companyProject.Title = title;
                companyProject.Location = location;
                companyProject.Floors = floors;
                companyProject.Description = description;
                companyProject.ImagePath = imagePath;
                companyProjects[companyProjectIndex] = companyProject;
                return companyProject;
            }
            else
            {
                return null;
            }
        }

        ///////////////////////////////////// BROKER REQUESTS AND BIDS CRUD ///////////////////////////////////////
        public BrokerRequest OpenBrokerRequest(int projectPublicId, bool hasPlans = false, string? tierFilter = null)
        {
            var request = new BrokerRequest
            {
                Id = brokerRequestIdCounter++,
                ProjectId = projectPublicId,
                HasPlans = hasPlans,
                TierFilter = tierFilter,
                Status = "open",
                CreatedAt = DateTime.Now
            };
            brokerRequests.Add(request);
            return request;
        }

        public List<BrokerRequest> GetBrokerRequestsByProject(string projectPublicId)
        {
            return brokerRequests.Where(r => r.ProjectId.ToString() == projectPublicId).ToList();
        }

        ///////////////////////////////////// PlaceBrokerBid  ///////////////////////////////////////


        public BrokerBid PlaceBrokerBid(long requestId, int companyId, decimal priceTotal, int? durationDays = null, string? tierSnapshot = null, string? message = null)
        {
            var bid = new BrokerBid
            {
                Id = brokerBidIdCounter++,
                RequestId = requestId,
                CompanyId = companyId,
                PriceTotal = priceTotal,
                DurationDays = durationDays,
                TierSnapshot = tierSnapshot,
                Message = message,
                CreatedAt = DateTime.Now
            };
            brokerBids.Add(bid);

            // add bid to the request list
            var request = brokerRequests.FirstOrDefault(r => r.Id == requestId);
            if (request != null)
            {
                request.Bids.Add(bid);
            }
            return bid;
        }




        ///////////////////////////////////// SELECT BID  ///////////////////////////////////////

        public (BrokerBid? bud, Contract? contract, string? error) SelectBid(int bidId, string terms)
        {
            var bid = brokerBids.FirstOrDefault(b => b.Id == bidId);
            if (bid == null) return (null, null, "Bid not found.");

            var req = brokerRequests.FirstOrDefault(r => r.Id == bid.RequestId);
            if (req == null) return (null, null, "Request not found.");

            if (req.Status != "open") return (null, null, "Request is not open.");


            foreach (var b in brokerBids.Where(b => b.RequestId == req.Id))
            {
                b.Selected = false;
                bid.Selected = true;
                req.Status = "awarded";
            }

            var contract = new Contract
            {
                Id = contractIdCounter++,
                ProjectId = req.ProjectId,
                CompanyId = bid.CompanyId,
                BrokerBidId = bid.Id,
                Terms = "Standard turnkey contract v1",
                CreatedAt = DateTime.Now
            };
            contracts.Add(contract);

            return (bid, contract, null);

        }

        ///////////////////////////////////// CONTRACTS  BID  ///////////////////////////////////////



        public List<Contract> GetContractsByProject(string projectPublicId)
        {
            return contracts.Where(c => c.ProjectId.ToString() == projectPublicId).ToList();
        }

    }
}

    
