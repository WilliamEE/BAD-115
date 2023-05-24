using AmazonApi.Models;
using AmazonApi.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApi.Utilities
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model,BD_AmazonContext context);
    }
}
