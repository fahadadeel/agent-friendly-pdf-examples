# Aspose.Pdf for .NET Examples

This repository contains a large collection of runnable examples for **Aspose.Pdf for .NET**, covering document creation, conversion, forms, annotations, security, facades, and more.

## 🏗️ Project Structure

```
agent-friendly-pdf-examples/         # Repository root
├── AsposeExamples.sln               # Visual Studio solution
├── README.md                        # This file
├── README-Aspose.BarCode-for-.NET-Examples.md
├── data/                            # Sample assets and outputs
│   ├── inputs/                      # Source PDFs and supporting files
│   └── outputs/                     # Generated files saved by examples
├── Examples.Console/                # Console runner for examples
│   ├── Examples.Console.csproj
│   ├── Program.cs                   # Switch-based router for categories
│   └── appsettings.json             # Logging config
├── Examples.Core/                   # Example implementations
│   ├── Examples.Core.csproj         # References Aspose.Pdf 23.8.0
│   ├── AsposePDF/                   # Core API samples (annotations, forms, etc.)
│   └── AsposePdfFacades/            # Facades API samples
└── Examples.Tests/                  # xUnit test project
    └── Examples.Tests.csproj
```

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK (8.0.x)
- Visual Studio 2022 or VS Code
- Aspose.Pdf license (recommended; without it examples run in evaluation mode)

### 1) Clone
```bash
git clone <repository-url>
cd agent-friendly-pdf-examples
```

### 2) Build
```bash
dotnet build AsposeExamples.sln
```

### 3) Run examples
Use the console runner from the repo root:
```bash
dotnet run --project Examples.Console -- <CategoryKey>
```
- `CategoryKey` values are defined in `Examples.Console/Program.cs` and mirror the folder structure under `Examples.Core` (e.g., `asposepdffacades/attachments.run`).
- You can also open any example class (e.g., `Examples.Core/AsposePDF/Attachments/AddAttachment.cs`) and call its `Run()` method directly from your IDE for quicker iteration.

### 4) Outputs
Generated files are written to `data/outputs/`. Many examples create this folder automatically if missing.

## 🔑 License Setup
- Several examples include `Aspose.Pdf.License` calls with placeholder paths (e.g., `E:\Aspose.Pdf.lic`). Update those to your actual `.lic` location.
- QuickStart samples under `Examples.Core/AsposePDF/QuickStart/` demonstrate loading licenses from file, stream, or embedded resource.
- If no license is provided, Aspose.Pdf runs in evaluation mode with limitations.

## 🎯 Example Coverage

### Aspose.Pdf (core API)
- Annotations, Attachments, Bookmarks
- Document Conversion (HTML, images, PDF/A, tagged PDF, etc.)
- Forms (AcroForm/XFA), Graphs, Headings, Images
- Links & Actions, Operators, Pages, Tables
- Security & Signatures, Stamps & Watermarks
- Text processing, Technical Articles, Working with Tagged PDFs and XML/XSLT

### Aspose.Pdf.Facades API
- Annotations, Attachments, Bookmarks
- Forms, Images, Links & Actions
- Pages (split, append, concatenate, N-Up, booklet)
- Printing helpers, Security & Signatures, Stamps & Watermarks
- Technical articles, Text, Working-Document utilities

## 🧪 Tests
```bash
dotnet test
```
Tests are in `Examples.Tests/` (xUnit).

## 🛠️ Development Notes
- Target framework: `net8.0` (all projects)
- Dependencies: `Aspose.Pdf` 23.8.0 in `Examples.Core`; console uses `Microsoft.Extensions.Hosting` 8.0.0; tests use xUnit + Moq.
- Data paths: most examples resolve `AppContext.BaseDirectory` then `data/inputs` and `data/outputs`; ensure input assets exist before running.
- Adding a new example: place it in the relevant folder under `Examples.Core/AsposePDF` or `Examples.Core/AsposePdfFacades`, expose a `Run()` method, and (optionally) wire a new case into `Examples.Console/Program.cs`.

## ❓ Troubleshooting
- **License not found / evaluation mode**: point `Aspose.Pdf.License.SetLicense` to your `.lic` file in each example that uses it; keep a copy in the repo root or a known path.
- **Missing input files**: check `data/inputs/` subfolders (e.g., `AsposePDF/Annotations`, `AsposePdfFacades/Forms`).
- **Build errors**: verify .NET 8 is installed, run `dotnet restore`, then `dotnet clean` and `dotnet build`.
- **Unknown CategoryKey**: open `Examples.Console/Program.cs` to see the current switch keys; some entries may be duplicated and may need cleanup.

## 📚 Resources
- [Home](https://www.aspose.com/)
- [Product Page](https://products.aspose.com/pdf/net)
- [Docs](https://docs.aspose.com/pdf/net/)
- [Demos](https://products.aspose.app/pdf/family)
- [API Reference](https://reference.aspose.com/pdf/net/)
- [Blog](https://blog.aspose.com/category/pdf/)
- [Search](https://search.aspose.com/)
- [Free Support](https://forum.aspose.com/c/pdf/10)
- [Temporary License](https://purchase.aspose.com/temporary-license)
- [Support & Licensing](https://purchase.aspose.com/buy)

## 🤝 Contributing
- Fork the repo and create a branch: `git checkout -b feature/new-example`
- Follow existing folder patterns and naming; add XML comments where useful
- Add or update tests when possible (`Examples.Tests`)
- Submit a pull request with a clear description of changes
