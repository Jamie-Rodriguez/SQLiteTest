using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteTest
{
    [Table("InternalBlogs")]
    class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public bool Published { get; set; }

        public List<Post> Posts { get; set; }
    }
}
