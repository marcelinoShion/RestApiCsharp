using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace volunteer.Model;

public class VolunteerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; private set; }
    public string Name { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Boolean AgeMajority { get; private set; }

    public VolunteerModel(string name, DateOnly dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        AgeMajority = IsOver18(dateOfBirth);
    }
    public static bool IsOver18(DateOnly dateOfBirth)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        int age = today.Year - dateOfBirth.Year;
        if (today < dateOfBirth.AddYears(age))
        {
            age--;
        }
        return age >= 18;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetDateOfBirth(DateOnly dob)
    {
        DateOfBirth = dob;
        AgeMajority = IsOver18(dob);
    }
}