using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazingTrails.Shared.Features.ManageTrails.Shared.TrailDto;

namespace BlazingTrails.Shared.Features.ManageTrails.Shared;

public class TrailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int TimeInMinutes { get; set; }
    public int Length { get; set; }
    public List<RouteInstruction> Route { get; set; } = new();
    public string? Image { get; set; }
    public ImageAction ImageAction { get; set; }

    public class RouteInstruction
    {
        public int Stage { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

public enum ImageAction
{
    None,
    Add,
    Remove
}

public class TrailValidator : AbstractValidator<TrailDto>
{
    public TrailValidator()
    {
        RuleFor(t => t.Name).NotEmpty()
            .WithMessage("Please enter a name.");
        RuleFor(t => t.Description).NotEmpty()
            .WithMessage("Please enter a description");
        RuleFor(t => t.Location).NotEmpty()
            .WithMessage("Please enter a location");
        RuleFor(t => t.Route).NotEmpty()
            .WithMessage("Please add a route instruction");
        RuleFor(t => t.Length).GreaterThan(0)
            .WithMessage("Please enter a length");
        RuleFor(t => t.TimeInMinutes).GreaterThan(0)
            .WithMessage("Please enter a time");

        RuleForEach(t => t.Route).SetValidator(new RouteInstructionValidator());
    }
}

public class RouteInstructionValidator : AbstractValidator<RouteInstruction>
{
    public RouteInstructionValidator()
    {
        RuleFor(r => r.Stage).NotEmpty()
            .WithMessage("Please enter a stage");
        RuleFor(r => r.Description).NotEmpty()
            .WithMessage("Please enter a description");
    }
}