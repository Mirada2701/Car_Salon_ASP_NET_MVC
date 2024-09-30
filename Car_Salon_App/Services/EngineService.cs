using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Car_Salon_App.Services
{
    public class EngineService : IEngineService
    {
        private readonly IMapper mapper;
        private readonly CarSalonDbContext context;

        public EngineService(IMapper mapper, CarSalonDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public void Create(EngineDto engine)
        {
           

            var entity = mapper.Map<Engine>(engine);

            context.Engines.Add(entity);
            context.SaveChanges();
        }

        public List<EngineDto> GetEngines()
        {
            var engines = context.Engines.ToList();
            return mapper.Map<List<EngineDto>>(engines);
        }
    }
}
