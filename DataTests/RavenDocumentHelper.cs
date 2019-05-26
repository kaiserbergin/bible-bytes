using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTests
{
    public class RavenDocumentHelper
    {
        public static BibleByte GetBibleByte(string insight = "insight", Passage passage = null, List<string> tags = null)
        {
            return new BibleByte()
            {
                Insight = insight,
                Passage = passage ?? GetPassage(),
                Tags = tags ?? new List<string>()
            };
        }

        public static Passage GetPassage(string text = "text", string reference = "reference", Uri link = null)
        {
            return new Passage()
            {
                Text = text,
                Reference = reference,
                Link = link
            };
        }
    }
}
