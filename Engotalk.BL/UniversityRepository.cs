﻿using Engotalk.Data;
using Engotalk.IBL;
using Engotalk.Model;
using Engotalk.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<CollegeVM>> GetCollegesByCountryIdAndCourse(int cid, string course)
        {
            var model = await db.Courses.Where(i => i.department.university.CountryId == cid && i.Course == course && i.department.university.UniversityType == "College")
              .Select(g => new CollegeVM
              {
                  College = g.department.university.University,
                  Band = g.Band,
                  Rank = g.department.university.Rank,
                  Cost = g.Cost,
                  Duration = g.CourseDuration,
                  IELTSRequirment = g.IELTSRequirment,
                  ListeningBand = g.ListeningBand,
                  ReadingBand = g.ReadingBand ,
                  WritingBand = g.WritingBand,
                  SpeakingBand = g.SpeakingBand
              })
              .ToListAsync();

            return model;
        }

        public async Task<IEnumerable<UniversityM>> GetUniversities()
        {
            return await db.Universities
                .Include(m => m.country)
                .ToListAsync();
        }

        public async Task<IEnumerable<UniversityM>> GetUniversitiesByCountryId(int cid)
        {
            return await db.Universities.Where(z => z.CountryId == cid).ToListAsync();
        }

        public async Task<IEnumerable<UniversityVM>> GetUniversitiesByCountryIdAndCourse(int cid, string course)
        {
            var model = await db.Courses.Where(i => i.department.university.CountryId == cid && i.Course == course && i.department.university.UniversityType == "University")
               .Select(g => new UniversityVM
               {
                   University = g.department.university.University,
                   Band = g.Band,
                   Rank = g.department.university.Rank,
                   Cost = g.Cost,
                   Duration = g.CourseDuration
               })
               .ToListAsync();

            return model;
        }

        public async Task<IEnumerable<UniversityM>> GetUniversitiesOrderByLastAdded()
        {
            return await db.Universities
               .Include(m => m.country)
               .OrderByDescending(u =>u.UniversityId)
               .ToListAsync();
        }
    }
}