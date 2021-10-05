using System.Collections.Generic;

namespace AngularAsyncValidator.Api.Core
{
    public class ResponseBase
    {
        public List<string> ValidationErrors { get; set; }
    }
}
