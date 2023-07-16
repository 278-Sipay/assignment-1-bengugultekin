using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace SipayApi.Controllers;

public class Person
{
    public string Name { get; set; }


    public string Lastname { get; set; }


    public string Phone { get; set; }


    public int AccessLevel { get; set; }


    public decimal Salary { get; set; }
}

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(5).WithMessage("Name can not be less than 5 characters.")
            .MaximumLength(100).WithMessage("Name can not be greather than 100 characters.");

        RuleFor(p => p.Lastname)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty().WithMessage("Lastname is required")
            .MinimumLength(5).WithMessage("Lastame can not be less than 5 characters.")
            .MaximumLength(100).WithMessage("Lastname can not be greather than 100 characters.");

        RuleFor(p => p.Phone)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
           .NotNull().WithMessage("Phone Number is required.")
           .MinimumLength(10).WithMessage("PhoneNumber can not be less than 10 characters.")
           .MaximumLength(20).WithMessage("PhoneNumber can not exceed 20 characters.")
           .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3} ))?\d{3} \d{2} \d{2}")).WithMessage("Please type your phone number in this format: 555 555 55 55 ");

        RuleFor(p => p.AccessLevel)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty().WithMessage("Access level is required.")
            .GreaterThanOrEqualTo(1).WithMessage("Access level must be greater than or equal to 1")
            .LessThan(5).WithMessage("Access level can be less than to 5");

        RuleFor(p => p.Salary)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull().WithMessage("Salary is required")
            .GreaterThanOrEqualTo(5000).WithMessage("Salary can be greater than or equal to 5000")
            .LessThanOrEqualTo(50000).WithMessage("Salary can be less than or equal to 50000")

            .Custom((salary, context) =>
            {
                var person = context.InstanceToValidate as Person;
                decimal comparisonValue = GetComparisonValue(person.AccessLevel);

                if (salary > comparisonValue)
                {
                    context.AddFailure($"Salary can not be greater than {comparisonValue}");
                }
            });
    }

    private decimal GetComparisonValue(int accessLevel)
    {
        switch (accessLevel)
        {
            case 1:
                return 10000;
            case 2:
                return 20000;
            case 3:
                return 30000;
            case 4:
                return 40000;
            default:
                return 0;
        }
    }
}


[ApiController]
[Route("sipy/api/[controller]")]
public class PersonController : ControllerBase
{

    public PersonController() { }


    [HttpPost]
    public Person Post([FromBody] Person person)
    {
        return person;
    }
}
