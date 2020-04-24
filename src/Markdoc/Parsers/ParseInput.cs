using System;
using System.Collections.Generic;
using System.Text;

namespace Markdoc.Parsers
{
    public class ParseInput
    {
        readonly ReadOnlyMemory<string> _lines;
        private int _currentRow = 0;
        private int _currentColumn = 0;

        public int CurrentRow
        {
            get => _currentRow; private set
            {
                _currentRow = value;
                CurrentLine = _currentRow >= _lines.Length ? null : _lines.Span[_currentRow];
                CurrentColumn = CurrentColumn;
            }
        }

        public int CurrentColumn
        {
            get => _currentColumn; private set
            {
                _currentColumn = value;
                if (CurrentLine == null)
                    CurrentChar = null;
                else
                    CurrentChar = _currentColumn >= CurrentLine.Length ? null : (char?)CurrentLine[_currentColumn];
            }
        }

        public bool Move(int? row = null, int? column = null)
        {
            int _row = row ?? CurrentRow;
            int _column = column ?? CurrentColumn;
            if (_row < 0 || _row > _lines.Length)
                return false;
            if (_column < 0 || _row < _lines.Length && _column > _lines.Span[_row].Length || _row == _lines.Length && _column > 0)
                return false;
            CurrentRow = _row;
            CurrentColumn = _column;
            return true;
        }

        public string? CurrentLine { get; private set; }

        public char? CurrentChar { get; private set; }

        public string? NextLine()
        {
            if (Move(CurrentRow + 1, 0))
                return CurrentLine;
            else
                return null;
        }

        public char? NextChar()
        {
            bool success = IsLineEnd() ? Move(CurrentRow + 1, 0) : Move(CurrentRow, CurrentColumn + 1);
            if (success)
                return CurrentChar;
            else
                return null;
        }

        public bool IsEnd()
        {
            if (CurrentRow >= _lines.Length)
                return true;
            if (CurrentRow == _lines.Length - 1)
                return IsLineEnd();
            return false;
        }

        public bool IsLineEnd()
        {
            if (CurrentLine == null)
                return true;
            if (CurrentColumn >= CurrentLine!.Length)
                return true;
            if (CurrentColumn == CurrentLine!.Length - 1)
                return true;
            return false;
        }

        public ParseInput(string raw)
        {
            _lines = raw.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
            CurrentRow = 0;
            CurrentColumn = 0;
        }
    }
}
