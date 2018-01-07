using System;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DisplayString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public DisplayString(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        public DisplayString(int id, string text) : this(text)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; }
    }
}
