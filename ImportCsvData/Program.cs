using System;
using Fclp;

namespace ImportCsvData
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandLineArgs = ParseCommandLineArguments(args);
            
            ImportManager manager = new ImportManager();
            manager.Import(commandLineArgs);
        } 
        
        private static CommandLineArgs ParseCommandLineArguments(string[] args)
        {
            var commandLineParser = new FluentCommandLineParser<CommandLineArgs>();
            
            commandLineParser
                .Setup(arg => arg.OverviewPath)
                .As('o', "overview")
                .WithDescription("Add new sample overviews to the database.");

            commandLineParser
                .Setup(arg => arg.PetrographyPath)
                .As('p', "petrography")
                .WithDescription("Add new petrography data.");
            
            commandLineParser
                .Setup(arg => arg.GrainSizePath)
                .As('g', "grainSize")
                .WithDescription("Add new grain size data.");
            
            commandLineParser
                .Setup(arg => arg.XrdMineralogyPath)
                .As('x', "xrdMineralogy")
                .WithDescription("Add new xrd mineralogy data.");
            
            commandLineParser
                .Setup(arg => arg.XrfMainElementsPath)
                .As('a', "xrfMainElements")
                .WithDescription("Add new xrf main elements data.");
            
            commandLineParser
                .Setup(arg => arg.XrfMinorElementsPath)
                .As('i', "xrfMinorElements")
                .WithDescription("Add new xrf minor elements data.");

            commandLineParser.SetupHelp("?", "help")
                .Callback(text => Console.WriteLine(text));
            
            ICommandLineParserResult result = commandLineParser.Parse(args);

            if (result.HelpCalled)
            {
                Environment.Exit(0);
            }
            
            if (result.HasErrors)
            {
                Environment.Exit(1);
            }

            if (commandLineParser.Object.NoPathsSet())
            {
                commandLineParser.HelpOption.ShowHelp(commandLineParser.Options);
                
                Environment.Exit(1);
            }

            return commandLineParser.Object;
        }
    }
}
