﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Shared.Models
{
    public class ApiResult<T>
    {
        private ApiResult()
        { }

        private ApiResult(bool succeeded, T result, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; set; }
        public T Result { get; set; }
        public bool Succeeded { get; set; }

        public static ApiResult<T> Failure(IEnumerable<string> errors)
        {
            return new ApiResult<T>(false, default, errors);
        }

        public static ApiResult<T> Success(T result)
        {
            return new ApiResult<T>(true, result, []);
        }
    }
}