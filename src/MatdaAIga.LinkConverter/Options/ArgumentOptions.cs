namespace MatdaAIga.LinkConverter.Options;

/// <summary>
/// This represents the options entity for command line arguments
/// </summary>
public class ArgumentOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to display help or not.
    /// </summary>
    public bool Help { get; set; } = false;

    /// <summary>
    /// Gets or sets the YAML filepath of the data source.
    /// </summary>
    public string YamlFilepath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the markdown filepath to save markdown text.
    /// </summary>
    public string MarkdownFilePath { get; set; } = string.Empty;

    /// <summary>
    /// Parses the command line arguments to <see cref="ArgumentOptions" /> object
    /// </summary>
    /// <param name="args">List of command line arguments</param>
    /// <returns>Returns the <see cref="ArgumentOptions"/> object</returns>
    public static ArgumentOptions Parse(string[] args)
    {
        var options = new ArgumentOptions();
        if (args.Length < 2)
        {
            options.Help = true;
            return options;
        }
        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            switch (arg)
            {
                case "-f":
                case "--filepath":
                    if (i < args.Length - 1)
                    {
                        options.YamlFilepath = args[++i];
                    }
                    break;

                case "-m":
                case "--markdown":
                    if (i < args.Length - 1)
                    {
                        options.MarkdownFilePath = args[++i];
                    }
                    break;

                case "-h":
                case "--help":
                default: 
                    options.Help = true;
                    break;
            }
        }
        return options;
    }
}