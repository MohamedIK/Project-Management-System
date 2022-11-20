using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Project_Management_System.Models;

namespace Project_Management_System.ORM
{
    public interface IORM<T> where T : class
    {
        Result<IEnumerable<T>> GetAll();
        Result<Unit> Add(T entity);
        Result<Unit> Update(T entity);
        Result<Unit> Delete(int id);
    }
}
