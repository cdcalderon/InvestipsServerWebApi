using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
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
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.WidgetShapes, opt => opt.MapFrom(sec => sec.WidgetShapes
                .Select(w => new SecurityWidgetShape{ WidgetShape = w})))
                .ForMember(s => s.WidgetMultipointShapes, opt => opt.MapFrom(sec => sec.WidgetMultipointShapes
                .Select(w => new SecurityWidgetMultipointShape() { WidgetMultipointShape = w })));

            CreateMap<Security, WidgetShapesResource>()
                .ForMember(wsr => wsr.SinglePointShapes, opt => opt.MapFrom(s => s.WidgetShapes
                    .Select(x => new ShapeResource()
                    {
                        ShapePoint = x.WidgetShape.ShapePoint,
                        ShapeType = x.WidgetShape.ShapeDefinition.Shape
                    })))
               .ForMember(wsr => wsr.MultipointShapes, opt => opt.MapFrom(s => s.WidgetMultipointShapes
                .Select(x => new MultipointShapeResource
                {
                    ShapePoints = x.WidgetMultipointShape.WidgetShapePoints,
                    ShapeType = x.WidgetMultipointShape.ShapeDefinition.Shape
                })));




            //CreateMap<SecurityWidgetShape, ShapeResource>()
            //    .ForMember(sr => sr, opt => opt.MapFrom(ws => new ShapeResource
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
