﻿using Living.Shared.Extensions;
using Living.Tools.Templates;

namespace Living.Tools.Commands;
internal static class MigrationCommands
{
    internal static Task NewMigration()
    {
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the name of the migration?")
                .PromptStyle("green"));

        var date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm");

        var file_name = name.ToPascalCase();
        var path = Path.GetFullPath($"../../../../Living.Infraestructure/Migrations/{date}_{file_name}.cs");
        var template = ClassFilesTemplates.Migration(date, file_name);

        File.WriteAllText(path, template);

        AnsiConsole.MarkupLine($"Migration created at [bold]{path}[/]\n\n");

        return Task.CompletedTask;
    }

    internal static Task Up()
    {
        AnsiConsole.MarkupLine("[bold]Up[/]");

        return Task.CompletedTask;
    }

    internal static Task Down()
    {
        AnsiConsole.MarkupLine("[bold]Down[/]");

        return Task.CompletedTask;
    }
}
