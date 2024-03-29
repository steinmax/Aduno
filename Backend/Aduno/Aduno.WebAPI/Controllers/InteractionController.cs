﻿using Microsoft.AspNetCore.Mvc;
using Aduno.Database.Logic.Entities;
using Aduno.Database.Logic.Enumerations;
using Aduno.WebAPI.Models;
using Aduno.Common.Logic.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Aduno.WebAPI.Controllers
{
    /// <summary>
    /// A generic one for the standard CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity</typeparam>
    /// <typeparam name="TModel">The type of model</typeparam>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : GenericController<Database.Logic.Entities.Interaction, InteractionEdit, InteractionModel>
    {
        public InteractionController(Database.Logic.Controllers.InteractionController controller) : base(controller)
        {
        }

        [HttpGet("absencelist/{classId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserModel>> GetAbsenceList(int classId)
        {
            using var classCtrl = new Database.Logic.Controllers.ClassController();
            using var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            var users = await classCtrl.GetUsersOfClassByIdAsync(classId);

            var userModels = users?.ToList().Select(u =>
            {
                var user = new UserModel();
                user.CopyFrom(u);

                return user;
            });


            return Ok(userModels);
        }


        [HttpGet("latest/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<InteractionModel>> GetLastInteractionOfTodayAsync(int id)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            if (ctrl == null)
                throw new Exception("Controller null");

            var entity = await ctrl.GetLastInteractionOfTodayAsync(id);

            if (entity == null)
                return NoContent();

            return Ok(ToModel(entity));
        }


        [HttpPost("{userId}/{roomId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InteractionModel>> ToggleCheckState(int userId, int roomId)
        {
            var ctrl = EntityController as Database.Logic.Controllers.InteractionController;

            if (ctrl == null)
                throw new Exception("Controller null");

            var toggleResult = await ctrl.TogglePresenceState(userId, roomId);

            if (toggleResult == null)
                return NotFound("Something went wrong! Check user- and room-Id specified.");


            return CreatedAtAction("Get", new { Id = toggleResult.Id }, ToModel(toggleResult));
        }

        protected override void CheckEntity(Interaction entity, ActionType type)
        {
            var claim = User.FindFirst("userId");
            int userId = -1;

            if (claim == null)
                throw new Exception();

            userId = Convert.ToInt32(claim.Value);

            var temp = Common.GetUserRoleFromUser(User);
            Role userRole = (Role)(temp == null ? throw new Exception() : temp);

            //admins are allowed to manipulate every interaction
            if (userRole.HasFlag(Role.Admin))
                return;

            if ((type == ActionType.Create || type == ActionType.Read) && userRole == Role.Member)
            {
                if (userId != entity.UserId)
                    throw new Exception("Memebers are not allowed to Change or Read other users interactions");

                //everything is fine
                return;
            }
            else
                throw new Exception("Members are not allow to update or delete interactions");
        }
    }
}
