using System;
using System.Collections.Generic;
using System.Text;

namespace AppUtilities.Helpers
{
     public static class ResponseStatus
    {

        public static ResponseWrapper<string> GetDeleteStatus(int result)
        {
            return result switch
            {
                0 => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.NotFound,
                    Code = (int)Constants.StatusCode.BadRequest
                },
                var _ when (result > 0) => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.Success,
                    Code = (int)Constants.StatusCode.OK
                },
                _ => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.NotFound,
                    Code = (int)Constants.StatusCode.BadRequest
                }

            };
        }

        public static ResponseWrapper<string> GetUpdateStatus(int result)
        {
            return result switch
            {
                0 => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.NotFound,
                    Code = (int)Constants.StatusCode.BadRequest
                },
                var _ when (result > 0) => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.Success,
                    Code = (int)Constants.StatusCode.OK
                },
                _ => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.NotFound,
                    Code = (int)Constants.StatusCode.BadRequest
                }
            };
        }

        public static ResponseWrapper<string> GetCreateStatus(int result)
        {
            return result switch
            {
                0 => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.NotFound,
                    Code = (int)Constants.StatusCode.BadRequest
                },
                var _ when (result > 0) => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.Success,
                    Code = (int)Constants.StatusCode.OK
                },
                _ => new ResponseWrapper<string>
                {
                    Status = Constants.MessageStatus.NotFound,
                    Code = (int)Constants.StatusCode.BadRequest
                }
            };
        }
    }
}
