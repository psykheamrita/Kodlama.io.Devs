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

namespace Application.Features.ProgrammingLanguages.Commands.UpdatedProgramminLanguage
{
    public class UpdatedProgrammingLanguageCommandHandler : IRequestHandler<UpdatedProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        public UpdatedProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }
        public async Task<UpdatedProgrammingLanguageDto> Handle(UpdatedProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(pL => pL.Id == request.Id);
            
            _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
           
            programmingLanguage.Name = request.Name;
            
            ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
            UpdatedProgrammingLanguageDto updatedProgramminLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage); ;

            return updatedProgramminLanguageDto;
        }
    }
}
