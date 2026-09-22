using System;
using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

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
    /// AutoMapper 15 configuration. The MapperConfiguration constructor now
    /// requires an ILoggerFactory, so a no-op factory is passed.
    /// </summary>
    public class LegacyMapping
    {
        private readonly IMapper _mapper;

        public LegacyMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportDto, ReportViewModel>()
                   .ForMember(d => d.DisplayName, o => o.MapFrom(s => (s.Name ?? string.Empty).ToUpperInvariant()));
            }, NullLoggerFactory.Instance);

            _mapper = config.CreateMapper();
        }

        public ReportViewModel Map(ReportDto dto)
        {
            return _mapper.Map<ReportViewModel>(dto);
        }
    }
}
