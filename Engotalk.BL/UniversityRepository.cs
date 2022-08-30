using Engotalk.Data;
using Engotalk.IBL;
using Engotalk.Model;
using Engotalk.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.BL
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly EngotalkDbContext db;
        public UniversityRepository(EngotalkDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddUniversity(UniversityM university)
        {
            db.Universities.Add(university);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteUniversity(int id)
        {
            var university = db.Universities.Find(id);

            if (university != null)
            {
                university.IsDeleted = true;
                db.Universities.Update(university);
            }

            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CollegeVM>> GetCollegesByCountryIdAndCourse(int cid, string course)
        {
            var model = await db.Courses
              .Where(i => i.IsDeleted == false && i.department.university.IsDeleted == false && i.department.university.CountryId == cid && i.Course == course && i.department.university.UniversityType == "College")
              .Select(g => new CollegeVM
              {
                  College = g.department.university.University,
                  IELTSBand = g.IELTSBand,
                  Rank = g.department.university.Rank,
                  Cost = g.Cost,
                  Duration = g.CourseDuration,
                  GREScore = g.GREScore,
                  TOEFLlScore = g.TOEFLScore,
                  SATScore = g.SATScore
              })
              .ToListAsync();

            return model;
        }

        public async Task<IEnumerable<InstituteVM>> GetInstituteByCountryIdAndCourse(int cid, string course)
        {
            var model = await db.Courses
                .Where(i => i.IsDeleted == false && i.department.university.country.IsDeleted == false && i.department.university.CountryId == cid && i.Course == course)
                .Select(g => new InstituteVM
                {
                    University = g.department.university.University,
                    Location = g.department.university.Location,
                    Country = g.department.university.country.CountryName,
                    Established = g.department.university.Established,
                    Type = g.department.university.Type,
                    Cost = g.Cost,
                    Duration = g.CourseDuration,
                    ExamsAccepted = g.department.university.ExamsAccepted,
                    IELTSBand = g.IELTSBand,
                    GREScore = g.GREScore,
                    TOEFLlScore = g.TOEFLScore,
                    SATScore = g.SATScore
                })
                .ToListAsync();

            return model;
        }

        public async Task<IEnumerable<UniversityM>> GetUniversities()
        {
            return await db.Universities
                .Where(u => u.IsDeleted == false && u.country.IsDeleted == false)
                .Include(m => m.country)
                .ToListAsync();
        }

        public async Task<IEnumerable<UniversityM>> GetUniversitiesByCountryId(int cid)
        {
            return await db.Universities
                .Where(z => z.CountryId == cid && z.IsDeleted == false && z.country.IsDeleted == false).ToListAsync();
        }

        public async Task<IEnumerable<UniversityVM>> GetUniversitiesByCountryIdAndCourse(int cid, string course)
        {
            var model = await db.Courses
                .Where(i => i.IsDeleted == false && i.department.university.country.IsDeleted == false && i.department.university.CountryId == cid && i.Course == course && i.department.university.UniversityType == "University")
                .Select(g => new UniversityVM
                {
                   University = g.department.university.University,
                   Band = g.IELTSBand,
                   Rank = g.department.university.Rank,
                   Location = g.department.university.Location,
                   Established = g.department.university.Established,
                   Type = g.department.university.Type,
                   Cost = g.Cost,
                   Duration = g.CourseDuration,
                   ExamsAccepted = g.department.university.ExamsAccepted
                })
                .ToListAsync();

            return model;
        }

        public async Task<UniversityM> GetUniversitiesByUniversityId(int id)
        {
            return await db.Universities.Where(i => i.IsDeleted == false).FirstOrDefaultAsync(i => i.UniversityId == id);
        }

        public async Task<IEnumerable<UniversityM>> GetUniversitiesOrderByLastAdded()
        {
            return await db.Universities
                .Where(u => u.IsDeleted == false && u.country.IsDeleted == false)
                .Include(m => m.country)
                .OrderByDescending(u => u.UniversityId)
                .ToListAsync();
        }
        public async Task<string> GetUniversityTypeByUniversityId(int id)
        {
            return await db.Universities
                .Where(u => u.IsDeleted == false && u.UniversityId == id)
                .Select(i => i.UniversityType)
                .SingleOrDefaultAsync();
        }

        public async Task<int> UpdateUniversity(UniversityM university)
        {
            db.Universities.Update(university);
            return await db.SaveChangesAsync();
        }
    }
}
