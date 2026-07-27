using ix.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ix.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class V1(
    ITimeScaleEngine _engine
    ) : ControllerBase
{
    // receiveCSV -> domain::SaveCSVAsync
}
