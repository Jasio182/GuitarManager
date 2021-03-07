using GuitarManager.DataAccess;
using GuitarManager.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuitarManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoundsController
    {
        private readonly IRepository<Sound> soundRepository;

        public SoundsController(IRepository<Sound> soundRepository)
        {
            this.soundRepository = soundRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Sound> GetAllSounds() => this.soundRepository.GetAll();
    }
}
