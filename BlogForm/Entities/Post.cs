using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogForm.Entities
{
    [Table("tblPosts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }

        [Required, StringLength(4000)]
        public string Text { get; set; }

        [ForeignKey("Category")]
        public int ? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public virtual ICollection<TagPost> TagPosts { get; set; }
    }
}
