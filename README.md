# OxyPlot.Viewer

Library to create plots while working in C# Interactive.

Work is in the very early stages.

The basic idea is that inside the C# Interactive Window in Visual Studio you can do this:

```csharp
#r "OxyPlot.WindowsForms.dll";
#r "OxyPlot.Viewer.WinForms.dll"

using OxyPlot.Viewer.WinForms;
using OxyPlot;

var client = new InProcessClient();
client.Start();

var plot = Any_OxyPlot_PlotModel();

client.Plot(plot);

```

The last line will cause a window to open up outside of Visual Studio that will display the plot you defined in the ```Any_OxyPlot_PlotModel``` method.

You can open new windows with the ```NewWindow``` method. You can add panes to a window using the ```NewPane``` method. Panes can be dragged and docked so that the containing window is subdivided. If you right click drag you can move a pane between different windows.
