using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeletedProgramminLanguage
{
    public class DeletedProgrammingLanguageCommandHandler : IRequestHandler<DeletedProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programminLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programminLanguageBusinessRules;

        public DeletedProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programminLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programminLanguageRepository = programminLanguageRepository;
            _mapper = mapper;
            _programminLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<DeletedProgrammingLanguageDto> Handle(DeletedProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programminLanguageRepository.GetAsync(pL => pL.Id == request.Id);
            _programminLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
            ProgrammingLanguage deletedProgrammingLanguage = await _programminLanguageRepository.DeleteAsync(programmingLanguage);
            DeletedProgrammingLanguageDto deletedProgramminLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

            return deletedProgramminLanguageDto;
        }
    }
}
