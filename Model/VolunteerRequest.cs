namespace volunteer.Model;

public class VolunteerRequest
{
    public string Name { get; private set; }
    public DateOnly DateOfBirth { get; private set; }

    public VolunteerRequest(string name, DateOnly dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
    }
}