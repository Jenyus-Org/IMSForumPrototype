using System;
using System.Collections.Generic;

namespace IMSForumPrototype.Models
{
    public class Tutorial : Post, Taggable
    {
        public int Id { get; }
        public DateTime CreatedAt { get; }
        public User CreatedBy { get; }
        public string Title { get; }
        public string Body { get; set; }
        public User Author { get; }
        public bool Removed { get => this.RemovedBy != null; }
        public User RemovedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool Deleted { get => this.DeletedAt != null; }
        public CommentForest Comments { get; set; }

        public List<Tag> Tags = new List<Tag>();

        public Tutorial(int id, DateTime createdAt, User createdBy, string body, User author)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.CreatedBy = createdBy;
            this.Body = body;
            this.Author = author;
        }

        public void AddTag(Tag tag) => this.Tags.Add(tag);

        public bool RemoveTag(Tag tag)
        {
            int tagCountOriginal = this.Tags.Count;
            this.Tags = this.Tags.FindAll(t => t.Id != tag.Id);
            return tagCountOriginal != this.Tags.Count;
        }
    }
}
