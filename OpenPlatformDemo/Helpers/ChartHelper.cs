using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
using OpenPlatformDemo.Models.Music;
using System.Drawing;
namespace OpenPlatformDemo
{
    public class ChartHelper
    {
        public static void PopulateChart(Chart chart, Dictionary<string, int> data)
        {
            var series = chart.Series["Series1"];

            foreach (var date in data)
            {
                series.Points.AddXY( date.Key, date.Value);
            }
        }
		protected static Series GetNewSeries(string name, Color colour)
		{
			return new Series
			{
				Name = name,
				XValueType = ChartValueType.String,
				IsValueShownAsLabel = true,
				ChartType = SeriesChartType.Spline,
				IsXValueIndexed = true,
				BorderColor = colour,
				YValueType = ChartValueType.Int32, AxisLabel=name
				
			};
		}
		public static void PopulateChart(Chart chart, IEnumerable<MusicModel> data)
		{
			var pop = chart.Series["PopAndRock"]; 
			var classical = chart.Series["Classical"];
			var electronic = chart.Series["Electronic"];
			var urban = chart.Series["Urban"];
			var folk = chart.Series["Folk"];
			var world = chart.Series["WorldMusic"];
			var all = chart.Series["Total"];
			string formatString = "ddd d MMM";
			foreach (var day in data)
			{
				pop.Points.AddXY(day.Day.ToString(formatString), day.PopAndRock.Count());
				classical.Points.AddXY(day.Day.ToString(formatString), day.Classical.Count());
				electronic.Points.AddXY(day.Day.ToLongDateString(), day.Electronic.Count());
				urban.Points.AddXY(day.Day.ToLongDateString(), day.Urban.Count());
				folk.Points.AddXY(day.Day.ToLongDateString(), day.Folk.Count());
				world.Points.AddXY(day.Day.ToLongDateString(), day.WorldMusic.Count());
				all.Points.AddXY(day.Day.ToString(formatString), day.All.Count());
			}
		}

    }
}
