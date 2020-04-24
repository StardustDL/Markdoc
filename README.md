# Markdoc

![CI](https://github.com/StardustDL/Markdoc/workflows/CI/badge.svg)

A Markdown-like document parser.

## Features

- [ ] Paragraph
- [ ] Header
- [ ] Code Block
- [ ] Code Span
- [ ] List
  - [ ] Sub list
- [ ] Text
  - [ ] Normal
  - [ ] Emphasized
  - [ ] Strong
- [ ] Break
- [ ] Link
- [ ] Image

## Test & Benchmark

```sh
dotnet test

dotnet run --project ./test/Benchmark.Base -c Release
```

## Depedencies

- [.NET Core 3.1](https://dotnet.microsoft.com/)
- [BenchmarkDotnet](https://github.com/dotnet/BenchmarkDotNet)
