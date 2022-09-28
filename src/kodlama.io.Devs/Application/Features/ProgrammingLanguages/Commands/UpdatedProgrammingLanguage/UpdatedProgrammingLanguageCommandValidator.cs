using Application.Features.ProgrammingLanguages.Commands.DeletedProgramminLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdatedProgramminLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdatedProgrammingLanguage
{
    public class UpdatedProgrammingLanguageCommandValidator : AbstractValidator<UpdatedProgrammingLanguageCommand>
    {
        public UpdatedProgrammingLanguageCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Name).NotEmpty();
            RuleFor(d => d.Name).MinimumLength(1);
        }
    }
}
