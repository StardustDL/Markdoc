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

## Test

```sh
dotnet test
```

## Benchmark

1. Use the following command to run benchmark

```sh
dotnet run --project ./test/Benchmark.Base -c Release
```

2. The results and logs will also be saved at directory `BenchmarkDotNet.Artifacts`.

## Depedencies

- [.NET Core 3.1](https://dotnet.microsoft.com/)
- [BenchmarkDotnet](https://github.com/dotnet/BenchmarkDotNet)
