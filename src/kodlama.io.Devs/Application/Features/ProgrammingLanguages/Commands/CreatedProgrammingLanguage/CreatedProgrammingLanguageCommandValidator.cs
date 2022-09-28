using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreatedProgrammingLanguage
{
    public class CreatedProgrammingLanguageCommandValidator : AbstractValidator<CreatedProgrammingLanguageCommand>
    {
        public CreatedProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c=>c.Name).MinimumLength(1);
        }
    }
}
