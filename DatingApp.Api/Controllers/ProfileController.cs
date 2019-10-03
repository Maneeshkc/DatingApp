using DatingApp.Api.Dto;
using DatingApp.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MyDatingapp.Api.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IUserRepository _profileRepo;
        public ProfileController(IUserRepository repo)
        {
            _profileRepo = repo;
        }

        [HttpGet("GetMembers")]
        public async Task<ActionResult> GetMembers()
        {
            var members = await _profileRepo.GetUsers();

            var membersDto = members.Select(x => new ProfileDTO()
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Country = x.Country,
                Created = x.Created,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                Interests = x.Interests,
                Introduction = x.Introduction,
                KnownAs = x.KnownAs,
                LastActive = x.LastActive,
                LookingFor = x.LookingFor,
                ProfileUrl = x.TuserPhoto.FirstOrDefault(y => y.IsMain == true) == null ? "" : x.TuserPhoto.FirstOrDefault(y => y.IsMain == true).Url


            }).ToList();
            return Ok(membersDto);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var x = await _profileRepo.GetTuser(id);
            if (x != null)
            {
                var userDto = new ProfileDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    Country = x.Country,
                    Created = x.Created,
                    DateOfBirth = x.DateOfBirth,
                    Gender = x.Gender,
                    Interests = x.Interests,
                    Introduction = x.Introduction,
                    KnownAs = x.KnownAs,
                    LastActive = x.LastActive,
                    LookingFor = x.LookingFor,
                    Photo=x.TuserPhoto.Select(p=>p.Url).ToList(),
                    ProfileUrl = x.TuserPhoto.FirstOrDefault(y => y.IsMain == true) == null ? "" : x.TuserPhoto.FirstOrDefault(y => y.IsMain == true).Url
                };
                return Ok(userDto);
            }
            return NotFound("id not found!");

        }
    }
}