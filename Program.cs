using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using parse_subtitle.models;

namespace parse_subtitle
{
    class Program
    {
        private static readonly Regex subtitle_pattern = new Regex(@"(?<order>\d+)\n(?<start>[\d:,]+)\s+-{2}\>\s+(?<end>[\d:,]+)\n(?<text>[\s\S]*?(?=\n{2}|$))", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            var subtitles = new List<Subtitle>();
            var input = File.ReadAllText("data.srt");
            var result = subtitle_pattern.Matches(input);
            foreach (Match item in result)
            {
                subtitles.Add(new Subtitle
                {
                    Start = TimeSpan.ParseExact(item.Groups["start"].ToString(), @"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture),
                    End = TimeSpan.ParseExact(item.Groups["end"].ToString(), @"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture),
                    Text = item.Groups["text"].ToString(),
                });
            }
            Console.Write(subtitles.Count);
        }
    }
}
