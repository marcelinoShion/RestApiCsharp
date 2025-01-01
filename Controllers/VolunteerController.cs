using Microsoft.EntityFrameworkCore;
using volunteer.Data;
using volunteer.Model;

namespace volunteer.Controllers;

public static class VolunteerController
{
    public static void Router(this WebApplication application)
    {
        var app = application.MapGroup("volunteers");
        app.MapPost("", async (VolunteerRequest request , VolunteerContext context) =>
        {
            var volunteer = new VolunteerModel(request.Name, request.DateOfBirth);
            await context.AddAsync(volunteer);
            await context.SaveChangesAsync();
            return Results.Ok(volunteer);
        });
        app.MapGet("", async (VolunteerContext context) =>
        {
            var volunteer = await context.Volunteers.ToListAsync();
            return Results.Ok(volunteer);
        });
        app.MapGet("{id:long}", async (long id,VolunteerContext context) =>
        {
            var volunteer = await context.Volunteers.FirstOrDefaultAsync(volunteer => volunteer.Id == id);
            if (volunteer == null)
            {
                return Results.NotFound("Volunteer not found");
            }

            return Results.Ok(volunteer);
        });
        
        app.MapPut("{id:long}", async (long id, VolunteerRequest request, VolunteerContext context) =>
        {
            var volunteer = await context.Volunteers.FirstOrDefaultAsync(volunteer => volunteer.Id == id);
            if (volunteer == null)
            {
                return Results.NotFound("Volunteer not found");
            }
            volunteer.SetName(request.Name);
            volunteer.SetDateOfBirth(request.DateOfBirth);
            await context.SaveChangesAsync();
            return Results.Ok(volunteer);
        });
        app.MapDelete("{id:long}", async (long id , VolunteerContext context) =>
        {
            var volunteer = await context.Volunteers.FirstOrDefaultAsync(volunteer => volunteer.Id == id);
            if (volunteer == null)
            {
                return Results.NotFound("Volunteer not found");
            }

            context.Volunteers.Remove(volunteer);
            await context.SaveChangesAsync();
            return Results.Ok("Volunteer removed sucessfully");
        });
    }
}