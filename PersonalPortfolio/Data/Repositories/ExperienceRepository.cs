using Microsoft.EntityFrameworkCore;

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
            return _context.Experiences.Include(a => a.Skills).Where(a => a.State == "Active").ToList();
        }

        public Experience? Get(int Id)
        {
            return _context.Experiences.Include(a => a.Skills).Where(a => a.State == "Active").FirstOrDefault(a => a.Id == Id);
        }

        public List<Experience> GetBySearchParameters(string searchParameters)
        {
            return _context.Experiences.Include(a => a.Skills).Where(a => a.Title.Contains(searchParameters) || a.Summary.Contains(searchParameters)).ToList();
        }
        public int AddExperience(Experience newExperience)
        {
            _context.Experiences.Add(newExperience);
            _context.Skills.AddRange(newExperience.Skills);
            _context.SaveChanges();
            return newExperience.Id;
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
    }
}