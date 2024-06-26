﻿using Domain;
using ExceptionList;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Data.Common;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;
        public CourseRepository(CourseDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _context.Courses
            .Include(c => c.User)
            .Select(c => new CourseDTO
        {
            Id = c.Id,
            Name = c.Name,
            LevelName = c.LevelName,
            Schedule = c.Schedule,
            Username = c.User.Username,
            Description = c.Description
        })
        .ToList();
        }
        public CourseDTO? Get(int id)
        {
            return _context.Courses
                .Where(c => c.Id == id)
                .Include(c => c.User)
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    LevelName = c.LevelName,
                    Schedule = c.Schedule,
                    Username = c.User.Username,
                    UserId = c.UserId,
                    Description = c.Description
                })
                .FirstOrDefault();
        }

        public Course? GetCourseForUpdate(int id)
        {
            return _context.Courses
                           .Include(c => c.User)
                           .FirstOrDefault(c => c.Id == id);
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

        }
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
        public void UpdateCourse(Course course)
        {  
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public List<CourseDTO> GetCoursesByTeacherId(int Id)
        {
            return _context.Courses
                .Where(c => c.UserId == Id)
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    LevelName = c.LevelName,
                    Schedule = c.Schedule,
                    Username = c.User.Username,
                    UserId = c.UserId,
                    Description = c.Description
                })
                .ToList();
        }
        public bool IsTeacherInCourse(int userId)
        {
            return _context.Courses.Any(c => c.UserId == userId);
        }
        public bool CourseExists(string name, string levelName)
        {
            return _context.Courses.Any(c => c.Name == name && c.LevelName == levelName);
        }

    }
}