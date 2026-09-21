using System;
using AutoMapper;

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
    /// AutoMapper 10 style configuration. The static Mapper facade and the
    /// IMapper created from MapperConfiguration both changed in later majors.
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
            }, Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);

            _mapper = config.CreateMapper();
        }

        public ReportViewModel Map(ReportDto dto)
        {
            return _mapper.Map<ReportViewModel>(dto);
        }
    }
}
