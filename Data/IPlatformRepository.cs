using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        void CreatePlatform(Platform platform);
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
    }
}