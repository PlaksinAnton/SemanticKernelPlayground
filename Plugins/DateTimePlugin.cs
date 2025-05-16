using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SemanticKernelPlayground.Plugins;

public class DateTimePlugin
{
    [KernelFunction, Description("Determines the current datetime in UTC")]
    public DateTime GetCurrentDateTime() => DateTime.UtcNow;
}
