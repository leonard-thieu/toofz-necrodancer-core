using System;

namespace toofz.NecroDancer.Data
{
    public sealed class DisplayString
    {
        public DisplayString(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public DisplayString(int id, string text) : this(text)
        {
            Id = id;
        }

        public int? Id { get; }
        public string Text { get; }
    }
}
