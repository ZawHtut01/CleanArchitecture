﻿namespace CleanArchitecture.API.Common
{
    public class CommonResponse<T>
    {
        public bool Success { get; set; }
        public string Message {  get; set; }
        public T? Data {  get; set; }
    }
}
