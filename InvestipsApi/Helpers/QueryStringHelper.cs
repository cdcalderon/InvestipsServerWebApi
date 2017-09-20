using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investips.Core.Extensions;
using InvestipsApi.Controllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;


namespace InvestipsApi.Helpers
{
    public class QueryStringHelper
    {

        public static int GetChartId(IQueryCollection queryStrings)
        {
            int chart = 0;
            var qsList = new List<string>();

            foreach (var key in queryStrings.Keys)
            {
                if (key == "chart")
                {
                    chart = int.Parse(queryStrings[key]);
                }
                qsList.Add(queryStrings[key]);
            }
            return chart;
        }

        public static ChartResource GetChartResource(string bodyStr)
        {
            var dic = bodyStr.Split('&').Select(x => x.Split('=')).Select(t =>
                new
                {
                    Prop = t[0],
                    Value = t[1]
                }).ToDictionary(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Prop.ToLower()),
                x => x.Value);

            var chartResource = dic.DictionaryToObject<ChartResource>();
            return chartResource;
        }
        
    }
}
