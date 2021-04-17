using System;
using System.Collections.Generic;
using System.Text;

namespace AppUtilities.Helpers
{
    public static class Constants
    {
        public enum StatusCode 
        { 
            /// <summary>
            /// The Request has Succeeded
            /// </summary>
            OK=200,
            /// <summary>
            /// Some thing happens wrong
            /// </summary>
            BadRequest =400
        
        }

        public static class MessageStatus 
        { 
            public static string Success
            {
                get { return "success"; }
            }

            public static string NotFound
            {
                get { return "Record not found"; }
            }
        }
    }
}
