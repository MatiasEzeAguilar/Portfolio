namespace PersonalPortfolio
{
    public class SkillRepository
    {
        private readonly PortfolioContext _context;
        public SkillRepository(PortfolioContext context)
        {
            _context = context;
        }
        public List<Skill> Get()
        {
            return _context.Skills.Where(a => a.State == "Active").ToList();
        }
        public int AddSkill(Skill newSkill)
        {
            _context.Skills.Add(newSkill);
            _context.SaveChanges();
            return newSkill.Id;
        }
        public bool DeleteSkill(int id)
        {
            var skillToDelete = _context.Skills.FirstOrDefault(a => a.Id == id);
            if (skillToDelete is not null)
            {
                skillToDelete.State = "Deleted";
                _context.Skills.Update(skillToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}