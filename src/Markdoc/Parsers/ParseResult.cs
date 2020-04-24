using Markdoc.Diagnostics;
using Markdoc.Documents;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Markdoc.Parsers
{
    public static class ParseResult
    {
        public static ParseResult<T> Success<T>(Range range, T result) where T : DocumentObject => new ParseResult<T>(true, result, range);

        public static ParseResult<T> Fail<T>() where T : DocumentObject => new ParseResult<T>(false, null, Range.All);
    }

    public sealed class ParseResult<T> where T : DocumentObject
    {
        T? _result = null;

        public ParseResult(bool isSuccess, T? result, Range range)
        {
            if (isSuccess)
                Assert.ArgumentNotNull(result, nameof(result));

            Range = range;
            IsSuccess = isSuccess;
            _result = result;
        }

        public Range Range { get; }

        public bool IsSuccess { get; }

        public T GetResult()
        {
            if (IsSuccess)
            {
                return _result!;
            }
            else
            {
                throw new Exception("Parse failed.");
            }
        }

        public bool TryGetResult([NotNullWhen(true)] out T? result)
        {
            if (IsSuccess)
            {
                result = _result!;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }
}
