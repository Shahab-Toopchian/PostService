using System;

namespace PostService.Dtos {
    public class PostReadDto {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}