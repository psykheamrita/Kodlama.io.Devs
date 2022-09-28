﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeletedProgramminLanguage
{
    public class DeletedProgrammingLanguageCommandValidator : AbstractValidator<DeletedProgrammingLanguageCommand>
    {
        public DeletedProgrammingLanguageCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
