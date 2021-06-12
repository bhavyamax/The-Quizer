﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Quizer.Data;

namespace The_Quizer.Models
{
    public class SQLUserExamStore : IUserExamStore
    {
        public SQLUserExamStore(AppDBContext context)
        {
            Context = context;
        }

        public AppDBContext Context { get; private set; }
        public bool AutoSaveChanges { get; set; }

        public async Task<Exam> GetExamResultsAsync(string examId)
        {
            if (string.IsNullOrEmpty(examId))
            {
                throw new ArgumentNullException("examId");
            }
            var exanRes = await Context.Exams.Include(eu => eu.UserExams)
                                             .ThenInclude(eu => eu.ApplicationUser)
                                             .SingleAsync(eu => eu.Id == examId);
            return exanRes;
        }
        public async Task<UserExam> GetUserResultsAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("examId");
            }
            var exanRes = await Context.UserExams.Include(eu => eu.ApplicationUser)
                                                 .Include(eu => eu.Exam)
                                                 .SingleAsync(eu => eu.User_id == userId);
            return exanRes;
        }

        public async Task AddUserExamScoreAsync(UserExam userExam)
        {
            if (userExam == null)
            {
                throw new ArgumentNullException("userExam");
            }
            await Context.AddAsync(userExam);
            await SaveChanges();

        }

        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public async Task<UserExam> GetUserExamRecordAsync(string userId, string examId)
        {
            var _userExam = await Context.UserExams.SingleOrDefaultAsync(ue => ue.User_id == userId && ue.Exam_id == examId);
            return _userExam;
        }

        public async Task<UserExam> SetUserRetestAsync(UserExam userExam)
        {
            userExam.Status = UserExamStatus.Pending;
            Context.Update(userExam);
            await SaveChanges();
            return userExam;
        }

        public async Task<UserExam> AssingUserToExamAsync(UserExam userExam)
        {
            await Context.AddAsync(userExam);
            return userExam;
        }

        public async Task RemoveUserFromExamAsync(UserExam userExam)
        {
            Context.Remove(userExam);
            await SaveChanges();
        }
    }
}
