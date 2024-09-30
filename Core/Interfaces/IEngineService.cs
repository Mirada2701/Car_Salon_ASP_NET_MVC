using Core.Dtos;

namespace Core.Interfaces
{
    public interface IEngineService
    {
        List<EngineDto> GetEngines();
        void Create(EngineDto engine);
    }
}
