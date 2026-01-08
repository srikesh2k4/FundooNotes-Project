using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Rules;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs.Labels;

namespace BusinessLayer.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;

        public LabelService(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<LabelResponseDto> CreateAsync(CreateLabelDto dto, int userId)
        {
            LabelRules.ValidateName(dto.Name);

            var label = new Label
            {
                Name = dto.Name,
                UserId = userId
            };

            await _labelRepository.AddAsync(label);
            await _labelRepository.SaveAsync();

            return new LabelResponseDto
            {
                Id = label.Id,
                Name = label.Name
            };
        }

        public async Task<IEnumerable<LabelResponseDto>> GetByUserAsync(int userId)
        {
            var labels = await _labelRepository.GetByUserAsync(userId);

            return labels.Select(label => new LabelResponseDto
            {
                Id = label.Id,
                Name = label.Name
            });
        }

        public async Task DeleteAsync(int labelId, int userId)
        {
            var label = await _labelRepository.GetByIdAsync(labelId)
                ?? throw new NotFoundException("Label not found");

            if (label.UserId != userId)
                throw new UnauthorizedException("Access denied");

            await _labelRepository.DeleteAsync(label);
            await _labelRepository.SaveAsync();
        }
    }
}
