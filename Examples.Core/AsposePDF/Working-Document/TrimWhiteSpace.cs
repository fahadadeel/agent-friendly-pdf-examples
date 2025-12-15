using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
using Aspose.Pdf.Text;

namespace Examples.Core.AsposePDF.WorkingDocument;

public class TrimWhiteSpace
{
    /// <summary>
    /// Trims white space around the first page of a PDF document.
    /// </summary>
    public static void Run()
    {
        // Resolve input and output paths relative to the application base directory.
        string baseDir = AppContext.BaseDirectory;
        string inputPath = Path.Combine(baseDir, "data", "inputs", "input.pdf");
        string outputDir = Path.Combine(baseDir, "data", "outputs");
        string outputPath = Path.Combine(outputDir, "TrimWhiteSpace_out.pdf");

        try
        {
            // Ensure the output directory exists.
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the existing PDF file.
            Document doc = new Document(inputPath);

            // Render the first page to an image with 72 DPI.
            PngDevice device = new PngDevice(new Resolution(72));

            using MemoryStream imageStr = new MemoryStream();
            device.Process(doc.Pages[1], imageStr);
            using Bitmap bmp = (Bitmap)Bitmap.FromStream(imageStr);

            BitmapData? imageBitmapData = null;

            try
            {
                // Lock the bitmap data for read‑only access.
                imageBitmapData = bmp.LockBits(
                    new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), // AUTOFIX
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppRgb);

                Aspose.Pdf.Rectangle prevCropBox = doc.Pages[1].CropBox;

                int toHeight = bmp.Height;
                int toWidth = bmp.Width;

                int? leftNonWhite = null;
                int? rightNonWhite = null;
                int? topNonWhite = null;
                int? bottomNonWhite = null;

                for (int y = 0; y < toHeight; y++)
                {
                    byte[] imageRowBytes = new byte[imageBitmapData.Stride];

                    // Copy the row data to a byte array.
                    IntPtr rowPtr = IntPtr.Size == 4
                        ? new IntPtr(imageBitmapData.Scan0.ToInt32() + y * imageBitmapData.Stride)
                        : new IntPtr(imageBitmapData.Scan0.ToInt64() + y * imageBitmapData.Stride);

                    Marshal.Copy(rowPtr, imageRowBytes, 0, imageBitmapData.Stride);

                    int? leftNonWhite_row = null;
                    int? rightNonWhite_row = null;

                    for (int x = 0; x < toWidth; x++)
                    {
                        // Each pixel occupies 4 bytes (B, G, R, A) in Format32bppRgb.
                        if (imageRowBytes[x * 4] != 255 ||
                            imageRowBytes[x * 4 + 1] != 255 ||
                            imageRowBytes[x * 4 + 2] != 255)
                        {
                            leftNonWhite_row ??= x;
                            rightNonWhite_row = x;
                        }
                    }

                    if (leftNonWhite_row != null || rightNonWhite_row != null)
                    {
                        topNonWhite ??= y;
                        bottomNonWhite = y;
                    }

                    if (leftNonWhite_row != null && (leftNonWhite == null || leftNonWhite > leftNonWhite_row))
                    {
                        leftNonWhite = leftNonWhite_row;
                    }

                    if (rightNonWhite_row != null && (rightNonWhite == null || rightNonWhite < rightNonWhite_row))
                    {
                        rightNonWhite = rightNonWhite_row;
                    }
                }

                leftNonWhite ??= 0;
                rightNonWhite ??= toWidth;
                topNonWhite ??= 0;
                bottomNonWhite ??= toHeight;

                // Adjust the crop box based on detected non‑white bounds.
                doc.Pages[1].CropBox = new Aspose.Pdf.Rectangle(
                    leftNonWhite.Value + prevCropBox.LLX,
                    (toHeight + prevCropBox.LLY) - bottomNonWhite.Value,
                    rightNonWhite.Value + doc.Pages[1].CropBox.LLX,
                    (toHeight + prevCropBox.LLY) - topNonWhite.Value);
            }
            finally
            {
                // Ensure bitmap data is unlocked.
                if (imageBitmapData != null)
                {
                    bmp.UnlockBits(imageBitmapData);
                }
            }

            // Save the updated document.
            doc.Save(outputPath);
            Console.WriteLine($"\nWhite-space trimmed successfully around a page.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing PDF: {ex.Message}");
        }
    }
}