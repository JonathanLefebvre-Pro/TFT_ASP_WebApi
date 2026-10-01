using System;
using AppCore.Interfaces.Commands;

namespace AppCore.Features.Commands;

public record DeleteTaskCommand(int Id) : ICommandDefinition;
