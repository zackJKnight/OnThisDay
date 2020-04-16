using System;
using System.Collections.Generic;
using System.Text;

namespace OnThisDay.TodayEventData.Models
{
    public class NYTDocs
    {
        public string Copyright { get; set; }
        public Response Response { get; set; }

    }
    public class Headline
    {
        public string Main { get; set; }
        public string PubDate { get; set; }
    }

    public class Response
    {
        public List<Doc> Docs { get; set; }
    }

    public class Doc
    {
        public string Abstract { get; set; }
        public Headline Headline { get; set; }
    }
}
