using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface ISubjectService
    {
        SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm);
        SubjectVm GetSubject(Expression<Func<ISubjectService, bool>> filterExpression);
        IEnumerable<SubjectVm> GetSubjects(Expression<Func<ISubjectService, bool>> filterExpression = null);
    }
}
