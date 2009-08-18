namespace Korzh.EasyQuery
{
    using System;

    public class DisplayFormatParser
    {
        private int exprNum = 0;
        private string formatStr = "";
        private int pos;
        private TokenType token = TokenType.Text;
        private string tokenText;

        public bool Next()
        {
            this.SkipSpaces();
            if (this.pos >= this.formatStr.Length)
            {
                return false;
            }
            if (this.formatStr[this.pos] == '{')
            {
                int index = this.formatStr.IndexOf("}", this.pos);
                if (index < 0)
                {
                    return false;
                }
                this.tokenText = this.formatStr.Substring(this.pos, (index - this.pos) + 1);
                if (this.tokenText.StartsWith("{expr"))
                {
                    this.token = TokenType.Expression;
                    this.exprNum = int.Parse(this.tokenText.Substring(5, this.tokenText.Length - 6));
                }
                this.pos = index + 1;
            }
            else if (((this.formatStr[this.pos] == '[') && (this.pos < (this.formatStr.Length - 1))) && (this.formatStr[this.pos + 1] == '['))
            {
                this.pos += 2;
                int num2 = this.formatStr.IndexOf("]]", this.pos);
                this.token = TokenType.Operator;
                this.tokenText = this.formatStr.Substring(this.pos, num2 - this.pos);
                this.pos = num2 + 2;
            }
            else
            {
                this.token = TokenType.Text;
                int length = this.formatStr.IndexOf("{", this.pos);
                if (length < 0)
                {
                    length = this.formatStr.Length;
                }
                int num4 = this.formatStr.IndexOf("[[", this.pos);
                if (num4 < 0)
                {
                    num4 = this.formatStr.Length;
                }
                int num5 = Math.Min(length, num4);
                this.tokenText = this.formatStr.Substring(this.pos, num5 - this.pos).Trim();
                this.pos = num5;
            }
            return true;
        }

        private void SkipSpaces()
        {
            while ((this.pos < this.formatStr.Length) && (this.formatStr[this.pos] == ' '))
            {
                this.pos++;
            }
        }

        public void Start(string s)
        {
            this.formatStr = s;
            this.pos = 0;
            this.exprNum = 0;
            this.tokenText = "";
        }

        public int ExprNum
        {
            get
            {
                return this.exprNum;
            }
        }

        public TokenType Token
        {
            get
            {
                return this.token;
            }
        }

        public string TokenText
        {
            get
            {
                return this.tokenText;
            }
        }

        public enum TokenType
        {
            Text,
            Operator,
            Expression
        }
    }
}

