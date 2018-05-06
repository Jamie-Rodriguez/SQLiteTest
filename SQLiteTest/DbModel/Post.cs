using System.ComponentModel.DataAnnotations;

namespace SQLiteTest
{
    class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        public byte[] Data { get; set; }

        // Creates foreign key (BlogId, Published) from primary key of Blog table
        public int BlogId { get; set; }
        public bool Published { get; set; }
        public Blog Blog { get; set; }
    }
}
