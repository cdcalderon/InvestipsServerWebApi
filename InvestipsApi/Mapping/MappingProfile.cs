using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using Investips.Core.Models;
using InvestipsApi.Controllers.Resources;
using Remotion.Linq.Clauses;

namespace InvestipsApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Portfolio, SavePortfolioResource>()
                .ForMember(pr => pr.Securities, opt => opt.MapFrom(p => p.Securities
                    .Select(s => s.SecurityId)));

            CreateMap<Portfolio, PortfolioResource>()
                .ForMember(pr => pr.Securities, opt => opt.MapFrom(p => p.Securities
                    .Select(s => new SecurityResource
                    {
                        Id = s.SecurityId,
                        Symbol = s.Security.Symbol
                    })));

            CreateMap<SavePortfolioResource, Portfolio>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Securities, opt => opt.Ignore())
                .AfterMap((pr, p) => {

                    // Remove unselected Securities
                    var removedSecurities = p.Securities.Where(s => !pr.Securities.Contains(s.SecurityId));
                    foreach (var s in removedSecurities)
                    {
                        p.Securities.Remove(s);
                    }

                    // Add New Securities
                    var newSecurities = pr.Securities.Where(id => p.Securities
                                                            .All(s => s.SecurityId != id))
                                                            .Select(id => new PortfolioSecurity
                                                            {
                                                                SecurityId = id
                                                            });
                    foreach (var s in newSecurities)
                    {
                        p.Securities.Add(s);
                    }
                });

            
            CreateMap<Security, SecurityResource>().ReverseMap();
            CreateMap<SaveSecurityResource, Security>()
                .ForMember(s => s.Id, opt => opt.Ignore());


            CreateMap<Security, SecurityWidgetResource>();

            CreateMap<WidgetShape, WidgetShapeResource>()
                .ForMember(wr => wr.ShapePoints, opt => opt.MapFrom(w => w.WidgetShapePoints
                .Select(ws => new WidgetShapePointResource
                {
                    Time = ws.Time,
                    Price = ws.Price
                })));

            CreateMap<WidgetShapePoint, WidgetShapePointResource>().ReverseMap();
            CreateMap<Chart, ChartResource>();

            CreateMap<ChartResource, Chart>()
                .ForMember(s => s.Id, opt => opt.Ignore());



            //CreateMap<SecurityWidgetShape, WidgetShapeResource>()
            //    .ForMember(sr => sr, opt => opt.MapFrom(ws => new WidgetShapeResource
            //    {
            //       ShapePoint = ws.WidgetShape.ShapePoint,
            //       ShapeType = ws.WidgetShape.ShapeDefinition.Shape
            //    }));
            //CreateMap<PortfolioResource, Portfolio>()
            //.ForMember(p => p.Id, opt => opt.Ignore())
            //.ForMember(p => p.Securities, opt => opt.MapFrom(pr => pr.Securities
            //.Select(id => new PortfolioSecurity { SecurityId = id })));
        }
    }
}
