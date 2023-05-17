﻿using AutoMapper;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Logging;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;

namespace SchoolRegister.Services.ConcreteServices
{
    public class SubjectSevice : BaseService, ISubjectService
    {
        public SubjectSevice(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                    throw new ArgumentException($"View model parameter is null");
                var subjectEntity = Mapper.Map<Subject>(addOrUpdateVm);
                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                    DbContext.Subjects.Add(subjectEntity);
                else
                    DbContext.Subjects.Update(subjectEntity);
                DbContext.SaveChanges();
                var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public SubjectVm GetSubject(Expression<Func<Subject, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var subjectEntity = DbContext.Subjects.FirstOrDefault(filterExpression);
                var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public SubjectVm GetSubject(Expression<Func<ISubjectService, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterExpression = null)
        {
            try
            {
                var subjectEntitites = DbContext.Subjects.AsQueryable();
                if (filterExpression != null)
                    subjectEntitites = subjectEntitites.Where(filterExpression);
                var subjectVms = Mapper.Map<IEnumerable<SubjectVm>>(subjectEntitites);
                return subjectVms;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
