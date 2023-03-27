using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities.Contracts;
using MentorshipProject.Converters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalCA.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : Controller
{
    IDoctorService doctorService;
    private Guid _doctorId => Guid.Parse(User.Claims.Single(c=>c.Type == ClaimTypes.NameIdentifier).Value);

    public DoctorController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }

    [HttpGet(Name = "GetAllDoctors")]
    [Authorize]
    public IEnumerable<DoctorContract> Get()
    {
        return doctorService.Get().ToDoctorContracrs();
    }

    [HttpGet("{id}", Name = "GetDoctor")]
    [Authorize]
    public IActionResult Get(int id)
    {
        DoctorContract doctor = doctorService.Get(id).ToDoctorContract();

        if (doctor == null)
            return NotFound();

        return new ObjectResult(doctor);
    }

    [HttpPost]
    [Authorize (Roles = "Admin")]
    public IActionResult Create([FromBody] DoctorContract doctor)
    {
        if(doctor == null)
            return BadRequest();

        doctorService.Create(doctor.ToDoctor());

        return CreatedAtRoute("GetDoctor", new { id = doctor.Id }, doctor);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update(int id, [FromBody] DoctorContract updatedDoctor)
    {
        if (updatedDoctor == null)
            return BadRequest();

        var doctor = doctorService.Get(id);

        if (doctor == null)
            return NotFound();

        doctorService.Update(id, updatedDoctor.ToDoctor());
        return RedirectToRoute("GetAllDoctors");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var deletedDoctor = doctorService.Delete(id);

        if (deletedDoctor == null)
            return BadRequest();

        return new ObjectResult(deletedDoctor.ToDoctorContract());
    }
}
