using System;
using Aspose.Pdf;

namespace Examples.Core.AsposePDF.Miscellaneous;

/// <summary>
/// Demonstrates retrieving Aspose.Pdf build information.
/// </summary>
public class GetBuildInformation
{
    /// <summary>
    /// Executes the example.
    /// </summary>
    public static void Run()
    {
        try
        {
            // ExStart:GetBuildInformation
            // Get version information
            Console.WriteLine("Product : {0}", BuildVersionInfo.Product);
            Console.WriteLine("File Version : {0}", BuildVersionInfo.FileVersion);
            Console.WriteLine("Assembly Version : {0}", BuildVersionInfo.AssemblyVersion);
            // ExEnd:GetBuildInformation
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error retrieving build information: {ex.Message}");
        }
    }
}