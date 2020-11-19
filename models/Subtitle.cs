using System;

namespace parse_subtitle.models
{
    class Subtitle
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Text { get; set; }
    }
}