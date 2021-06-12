using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLCourseStore : ICourseStore
    {
        public SQLCourseStore(AppDBContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            AutoSaveChanges = true;
        }

        public bool AutoSaveChanges { get; set; }
        public AppDBContext Context { get; private set; }


        public async Task<string> CreateAsync(Course course, string teacherId)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            else if (string.IsNullOrWhiteSpace(teacherId))
            {
                throw new ArgumentNullException(nameof(teacherId));
            }
            else if (await Context.Users.AnyAsync(a => a.Id == teacherId))
            {
                await Context.AddAsync<Course>(course);
                await Context.AddAsync<UserCourse>(new UserCourse
                {
                    Course_id = course.Id,
                    User_id = teacherId,
                    Type = UserCourseType.Teacher
                });
            }
            await SaveChanges();
            return course.Id;
        }

        public async Task DeleteAsync(Course course)
        {
            Context.Remove(course);
            await SaveChanges();
        }

        public async Task<Course> FindByIdAsync(string courseId)
        {
            var course = await Context.Courses
                .FirstOrDefaultAsync(m => m.Id == courseId);
            return course;
        }

        public Task<Course> FindByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = from course in Context.Courses
                        select course;
            return await courses.ToListAsync();
        }

        public async Task<List<Course>> GetAllForUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }
            var userCourses = await Context.UserCourses.Where(i => i.User_id == userId).Select(d => d.Course_id).ToListAsync();
            var courses = from course in Context.Courses
                        where userCourses.Contains(course.Id)
                        select course;
            return await courses.ToListAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            Context.Update(course);
            await Context.SaveChangesAsync();
        }

        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }
    }
}
