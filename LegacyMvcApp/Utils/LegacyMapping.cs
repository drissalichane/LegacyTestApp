using System;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace LegacyMvcApp.Utils
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ReportViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
    }

    /// <summary>
    /// Builds an IMapper from a MapperConfiguration constructed with a
    /// MapperConfigurationExpression and an ILoggerFactory, as required since AutoMapper 13.
    /// </summary>
    public class LegacyMapping
    {
        private readonly IMapper _mapper;

        public LegacyMapping()
        {
            // AutoMapper 13+ removed the MapperConfiguration(Action<IMapperConfigurationExpression>)
            // constructor; configure the expression first, then pass it in together with a logger factory.
            var configExpression = new MapperConfigurationExpression();
            configExpression.CreateMap<ReportDto, ReportViewModel>()
               .ForMember(d => d.DisplayName, o => o.MapFrom(s => (s.Name ?? string.Empty).ToUpperInvariant()));
            var config = new MapperConfiguration(configExpression, new LoggerFactory());

            _mapper = config.CreateMapper();
        }

        public ReportViewModel Map(ReportDto dto)
        {
            return _mapper.Map<ReportViewModel>(dto);
        }
    }
}
