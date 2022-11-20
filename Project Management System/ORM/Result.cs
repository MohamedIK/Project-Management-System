using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System.ORM
{
    public sealed class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Value { get; set; }
        public string Error { get; set; } = string.Empty;

        public static Result<T> Success(T value) => new Result<T>() { IsSuccess = true, Value = value };
        public static Result<T> Failure(string error) => new Result<T>() { IsSuccess = false, Error = error };

    }
}
