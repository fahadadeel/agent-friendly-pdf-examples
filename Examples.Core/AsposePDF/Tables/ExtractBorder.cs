using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;

// AUTOFIX: Alias conflicting types to resolve ambiguity
using Matrix = System.Drawing.Drawing2D.Matrix;
using Color = System.Drawing.Color;

namespace Examples.Core.AsposePDF.Tables;

public class ExtractBorder
{
    /// <summary>
    /// Extracts the border graphics from the first page of a PDF and saves it as a PNG image.
    /// </summary>
    public static void Run()
    {
        // ExStart:ExtractBorder
        try
        {
            // Resolve input and output directories relative to the application base directory.
            string baseDir = AppContext.BaseDirectory;
            string inputDir = Path.Combine(baseDir, "data", "inputs");
            string outputDir = Path.Combine(baseDir, "data", "outputs");
            Directory.CreateDirectory(outputDir);

            // Input PDF file.
            string inputPath = Path.Combine(inputDir, "input.pdf");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the PDF document.
            Document doc = new Document(inputPath);

            Stack graphicsState = new Stack();
            Bitmap bitmap = new Bitmap((int)doc.Pages[1].PageInfo.Width, (int)doc.Pages[1].PageInfo.Height);
            GraphicsPath graphicsPath = new GraphicsPath();

            // Default CTM matrix value is 1,0,0,1,0,0
            Matrix lastCTM = new Matrix(1, 0, 0, -1, 0, 0);
            // System.Drawing coordinate system is top‑left based, while PDF coordinate system is bottom‑left based,
            // so we have to apply the inversion matrix.
            Matrix inversionMatrix = new Matrix(1, 0, 0, -1, 0, (float)doc.Pages[1].PageInfo.Height);
            PointF lastPoint = new PointF(0, 0);
            Color fillColor = Color.FromArgb(0, 0, 0);
            Color strokeColor = Color.FromArgb(0, 0, 0);

            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                graphicsState.Push(new Matrix(1, 0, 0, 1, 0, 0));

                // Process all the content operators of the first page.
                foreach (Operator op in doc.Pages[1].Contents)
                {
                    Aspose.Pdf.Operators.GSave opSaveState = op as Aspose.Pdf.Operators.GSave;
                    Aspose.Pdf.Operators.GRestore opRestoreState = op as Aspose.Pdf.Operators.GRestore;
                    Aspose.Pdf.Operators.ConcatenateMatrix opCtm = op as Aspose.Pdf.Operators.ConcatenateMatrix;
                    Aspose.Pdf.Operators.MoveTo opMoveTo = op as Aspose.Pdf.Operators.MoveTo;
                    Aspose.Pdf.Operators.LineTo opLineTo = op as Aspose.Pdf.Operators.LineTo;
                    Aspose.Pdf.Operators.Re opRe = op as Aspose.Pdf.Operators.Re;
                    Aspose.Pdf.Operators.EndPath opEndPath = op as Aspose.Pdf.Operators.EndPath;
                    Aspose.Pdf.Operators.Stroke opStroke = op as Aspose.Pdf.Operators.Stroke;
                    Aspose.Pdf.Operators.Fill opFill = op as Aspose.Pdf.Operators.Fill;
                    Aspose.Pdf.Operators.EOFill opEOFill = op as Aspose.Pdf.Operators.EOFill;
                    Aspose.Pdf.Operators.SetRGBColor opRGBFillColor = op as Aspose.Pdf.Operators.SetRGBColor;
                    Aspose.Pdf.Operators.SetRGBColorStroke opRGBStrokeColor = op as Aspose.Pdf.Operators.SetRGBColorStroke;

                    if (opSaveState != null)
                    {
                        // Save previous state and push current state to the top of the stack
                        graphicsState.Push(((Matrix)graphicsState.Peek()).Clone());
                        lastCTM = (Matrix)graphicsState.Peek();
                    }
                    else if (opRestoreState != null)
                    {
                        // Throw away current state and restore previous one
                        graphicsState.Pop();
                        lastCTM = (Matrix)graphicsState.Peek();
                    }
                    else if (opCtm != null)
                    {
                        Matrix cm = new Matrix(
                            (float)opCtm.Matrix.A,
                            (float)opCtm.Matrix.B,
                            (float)opCtm.Matrix.C,
                            (float)opCtm.Matrix.D,
                            (float)opCtm.Matrix.E,
                            (float)opCtm.Matrix.F);

                        // Multiply current matrix with the state matrix
                        ((Matrix)graphicsState.Peek()).Multiply(cm);
                        lastCTM = (Matrix)graphicsState.Peek();
                    }
                    else if (opMoveTo != null)
                    {
                        lastPoint = new PointF((float)opMoveTo.X, (float)opMoveTo.Y);
                    }
                    else if (opLineTo != null)
                    {
                        PointF linePoint = new PointF((float)opLineTo.X, (float)opLineTo.Y);
                        graphicsPath.AddLine(lastPoint, linePoint);
                        lastPoint = linePoint;
                    }
                    else if (opRe != null)
                    {
                        RectangleF re = new RectangleF((float)opRe.X, (float)opRe.Y, (float)opRe.Width, (float)opRe.Height);
                        graphicsPath.AddRectangle(re);
                    }
                    else if (opEndPath != null)
                    {
                        graphicsPath = new GraphicsPath();
                    }
                    else if (opRGBFillColor != null)
                    {
                        fillColor = opRGBFillColor.getColor();
                    }
                    else if (opRGBStrokeColor != null)
                    {
                        strokeColor = opRGBStrokeColor.getColor();
                    }
                    else if (opStroke != null)
                    {
                        graphicsPath.Transform(lastCTM);
                        graphicsPath.Transform(inversionMatrix);
                        using var pen = new Pen(strokeColor);
                        gr.DrawPath(pen, graphicsPath);
                        graphicsPath = new GraphicsPath();
                    }
                    else if (opFill != null)
                    {
                        graphicsPath.FillMode = FillMode.Winding;
                        graphicsPath.Transform(lastCTM);
                        graphicsPath.Transform(inversionMatrix);
                        using var brush = new SolidBrush(fillColor);
                        gr.FillPath(brush, graphicsPath);
                        graphicsPath = new GraphicsPath();
                    }
                    else if (opEOFill != null)
                    {
                        graphicsPath.FillMode = FillMode.Alternate;
                        graphicsPath.Transform(lastCTM);
                        graphicsPath.Transform(inversionMatrix);
                        using var brush = new SolidBrush(fillColor);
                        gr.FillPath(brush, graphicsPath);
                        graphicsPath = new GraphicsPath();
                    }
                }
            }

            string outputPath = Path.Combine(outputDir, "ExtractBorder_out.png");
            bitmap.Save(outputPath, ImageFormat.Png);
            Console.WriteLine($"\nBorder extracted successfully as image.\nFile saved at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while extracting the border: {ex.Message}");
        }
        // ExEnd:ExtractBorder
    }
}

// TODO: import or include helper class RunExamples from original source if needed.