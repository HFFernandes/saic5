namespace Korzh.EasyQuery
{
    using System;
    using System.Text;

    public class StringTokenizer
    {
        private int position;
        private string separators;
        private StringBuilder source;
        private string spaces;

        public StringTokenizer(string s) : this(new StringBuilder(s), null)
        {
        }

        public StringTokenizer(StringBuilder source, string separators) : this(source, separators, null)
        {
        }

        public StringTokenizer(StringBuilder source, string separators, string spaces)
        {
            this.spaces = " \t";
            this.separators = "()[]{}.,;+-*/";
            this.source = source;
            if (separators != null)
            {
                this.separators = separators;
            }
            if (spaces != null)
            {
                this.spaces = spaces;
            }
        }

        public string FirstToken()
        {
            this.position = 0;
            return this.NextToken();
        }

        private bool IsQuote(char c)
        {
            return (c == '"');
        }

        private bool IsSeparator(char c)
        {
            return (this.separators.IndexOf(c) >= 0);
        }

        private bool IsSpace(char c)
        {
            return (this.spaces.IndexOf(c) >= 0);
        }

        public string NextToken()
        {
            string str = null;
            this.SkipSpaces();
            if (this.position >= this.source.Length)
            {
                return str;
            }
            int position = this.position;
            if (this.IsQuote(this.source[this.position]))
            {
                return this.RunCString();
            }
            if (!this.IsSeparator(this.source[this.position]))
            {
                while (this.position < this.source.Length)
                {
                    if ((this.IsSpace(this.source[this.position]) || this.IsSeparator(this.source[this.position])) || this.IsQuote(this.source[this.position]))
                    {
                        break;
                    }
                    this.position++;
                }
            }
            else
            {
                this.position++;
                return this.source.ToString(position, this.position - position);
            }
            return this.source.ToString(position, this.position - position);
        }

        private string RunCString()
        {
            StringBuilder builder = new StringBuilder(100);
            if (this.IsQuote(this.source[this.position]))
            {
                this.position++;
                while (this.position < this.source.Length)
                {
                    if (this.IsQuote(this.source[this.position]))
                    {
                        if ((this.position < (this.source.Length - 1)) && this.IsQuote(this.source[this.position + 1]))
                        {
                            builder.Append(this.source[this.position]);
                            this.position += 2;
                            continue;
                        }
                        this.position++;
                        break;
                    }
                    builder.Append(this.source[this.position]);
                    this.position++;
                }
            }
            return builder.ToString();
        }

        private void SkipSpaces()
        {
            while ((this.position < this.source.Length) && this.IsSpace(this.source[this.position]))
            {
                this.position++;
            }
        }
    }
}

