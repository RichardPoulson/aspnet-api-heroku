using System;
namespace aspnet_api_heroku.Models
{
    /// <summary>
    /// An article.
    /// </summary>
    public class ArticleItem
    {
        /// <summary>Unique ID</summary>
        public long Id { get; set; }

        /// <summary>Section heading level 1</summary>
        public string H1 { get; set; }

        /// <summary>Section heading level 2</summary>
        public string H2 { get; set; }

        /// <summary>Section heading level 3</summary>
        public string H3 { get; set; }

        /// <summary>Section heading level 4</summary>
        public string H4 { get; set; }

        /// <summary>Section heading level 5</summary>
        public string H5 { get; set; }

        /// <summary>Section heading level 6</summary>
        public string H6 { get; set; }

        /// <summary>Paragraph about the article.</summary>
        public string P { get; set; }
    }
}
