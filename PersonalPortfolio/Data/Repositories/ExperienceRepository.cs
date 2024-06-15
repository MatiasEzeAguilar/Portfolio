using System.Reflection.PortableExecutable;

namespace PersonalPortfolio
{
    public class ExperienceRepository
    {
        private readonly PortfolioContext _context;
        public ExperienceRepository(PortfolioContext context)
        {
            _context = context;
        }

        public List<Experience> GetAll()
        {
            return _context.Experiences.Where(a => a.State == "Active").ToList();
        }

        public Experience? Get(int Id)
        {
            return _context.Experiences.Where(a => a.State == "Active").FirstOrDefault(a => a.Id == Id);
        }

        public List<Experience> GetBySearchParameters(string searchParameters)
        {
            return _context.Experiences.Where(a => a.Title.Contains(searchParameters) || a.Summary.Contains(searchParameters)).ToList();
        }

        public bool Delete(int id)
        {
            var experienceToDelete = _context.Experiences.FirstOrDefault(a => a.Id == id);
            if (experienceToDelete is not null)
            {
                experienceToDelete.State = "Deleted";
                _context.Experiences.Update(experienceToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public int AddExperience(Experience newExperience)
        {
            _context.Experiences.Add(newExperience);
            _context.SaveChanges();
            return newExperience.Id;
        }
    }
}