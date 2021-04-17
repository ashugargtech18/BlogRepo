using System;
using System.Collections.Generic;
using System.Text;

namespace AppUtilities.Helpers
{
    public class ResponseWrapper<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }

        public string Status { get; set; }
        public ResponseWrapper() { }

        public ResponseWrapper(T Response) 
        {
            Data = Response;
        }
    }
}
