using ModelLayer.DTOs.Labels;

namespace BusinessLayer.Interfaces.Services
{
    public interface ILabelService
    {
        Task<LabelResponseDto> CreateAsync(CreateLabelDto dto, int userId);
        Task<IEnumerable<LabelResponseDto>> GetByUserAsync(int userId);
        Task DeleteAsync(int labelId, int userId);
    }
}
