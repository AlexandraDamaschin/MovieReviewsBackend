﻿using Microsoft.AspNetCore.Mvc;
using MovieReviewsBackend.ViewModels;
using AutoMapper;
using MovieReviewsBackend.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using MovieReviewsBackend.Models;

namespace MovieReviewsBackend.Controllers.Api
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
                return BadRequest(ModelState);

            //await _appDbContext.Reviewers.AddAsync(new Reviewer { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return Ok("Account created");
        }
    }
}
