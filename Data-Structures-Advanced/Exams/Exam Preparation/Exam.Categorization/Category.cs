namespace Exam.Categorization
{
    using System.Collections.Generic;

    public class Category
    {
        public Category(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Children = new HashSet<Category>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Depth { get; set; }

        public Category Parent { get; set; }

        public ISet<Category> Children { get; }
    }
}
