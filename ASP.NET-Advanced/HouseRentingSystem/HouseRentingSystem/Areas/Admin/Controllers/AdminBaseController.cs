namespace HouseRentingSystem.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AdminConstants;

[Area(AreaName)]
[Authorize(Roles = AdminRole)]
public class AdminBaseController : Controller;