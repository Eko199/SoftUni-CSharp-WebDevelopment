﻿namespace HouseRentingSystem.Attributes;

using System.Security.Claims;
using Controllers;
using Core.Services.Contracts.Agent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class IsAgentAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        IAgentService? agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

        if (agentService is null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        else if (!await agentService.ExistsByIdAsync(context.HttpContext.User.Id()!))
        {
            context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
        }
        else
        {
            await next();
        }
    }
}