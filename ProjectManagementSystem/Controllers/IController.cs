using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.ORM
{
    public interface IController<T> where T : class
    {
        Result<IEnumerable<T>> GetAll();
        Result<Unit> Add(T entity);
        Result<Unit> Update(T entity);
        Result<Unit> Delete(int id);
    }
}
