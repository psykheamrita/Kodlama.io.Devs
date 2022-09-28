﻿using Application.Features.ProgrammingLanguages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeletedProgramminLanguage
{
    public class DeletedProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }
    }
}