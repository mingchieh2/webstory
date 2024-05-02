using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ImageData
{
    public string Src { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public string Layout { get; set; }
}

public class HtmlParser
{
    public static List<ImageData> GetAmpImages(string html)
    {
        var list = new List<ImageData>();
        var regex = new Regex("<amp-img.*?src=\\\"(.*?)\\\".*width=\\\"(.*?)\\\".*height=\\\"(.*?)\\\".*layout=\\\"(.*?)\\\".*?></amp-img>", RegexOptions.IgnoreCase);
        var matches = regex.Matches(html);

        foreach (Match match in matches)
        {
            var imgData = new ImageData()
            {
                Src = match.Groups[1].Value,
                Width = match.Groups[2].Value,
                Height = match.Groups[3].Value,
                Layout = match.Groups[4].Value
            };
            list.Add(imgData);
        }

        return list;
    }

    public static void Main(string[] args)
    {
        var html = args[0];
        var ampImages = GetAmpImages(html);

        foreach (var img in ampImages)
        {
            Console.WriteLine($"Src: {img.Src}, Width: {img.Width}, Height: {img.Height}, Layout: {img.Layout}");
        }
    }
}
