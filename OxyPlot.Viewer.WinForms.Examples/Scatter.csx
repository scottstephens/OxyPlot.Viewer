// modify the 000_SetWorkingDirectory.csx file to match your environment, then 
// send it's two lines to the interactive window (Ctrl+E,Ctrl+E)
#load "001_Dependencies.csx"

using OxyPlot.Viewer.WinForms;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Linq;

static double RandomNormal(Random rand, double mean = 0, double sd = 1)
{
    double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
    double u2 = 1.0 - rand.NextDouble();
    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                 Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
    double randNormal =
                 mean + sd * randStdNormal; //random normal(mean,stdDev^2)

    return randNormal;
}

static PlotModel getPlot(Random rand, double sd)
{
    var points =
        Enumerable.Range(0, 100)
        .Select(i => RandomNormal(rand))
        .Select(x => new { X = x, Y = 3 * x + 4.0 + RandomNormal(rand, sd: sd) })
        .ToList();

    var model = new PlotModel();
    var series = new ScatterSeries();
    series.Points.AddRange(points.Select(p => new ScatterPoint(p.X, p.Y)));

    model.Series.Add(series);

    return model;
}

var client = new InProcessClient();
client.Start();
client.NewWindow();

var rand = new Random();

var plot = getPlot(rand, 1.0);

client.Plot(plot);

client.Stop();
