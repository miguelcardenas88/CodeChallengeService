using System;

namespace CodeChallengeService.Model
{
    public class Publicaciones
    {
        public int Codigo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime PublishedAt { get; set; }

    }
}
