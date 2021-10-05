using System;
using AngularAsyncValidator.Api.Models;

namespace AngularAsyncValidator.Api.Features
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new ()
            {
                ProfileId = profile.ProfileId
            };
        }
        
    }
}
