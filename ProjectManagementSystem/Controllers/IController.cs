using System.Collections.Generic;

namespace ProjectManagementSystem.Controllers
{
    public interface IController<T> where T : class
    {
        Result<Unit> Add(T entity);
        Result<Unit> Update(T entity);
        Result<Unit> Delete(int id);
    }
}