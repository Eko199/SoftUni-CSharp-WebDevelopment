using System.Collections.Generic;

namespace Exam.Categorization
{
    using System;
    using System.Linq;

    public class Categorizator : ICategorizator
    {
        private readonly IDictionary<string, Category> categories = new Dictionary<string, Category>();

        public void AddCategory(Category category)
        {
            if (Contains(category))
            {
                throw new ArgumentException();
            }

            category.Depth = 0;
            categories[category.Id] = category;
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!categories.ContainsKey(childCategoryId) || !categories.ContainsKey(parentCategoryId)
                || categories[childCategoryId].Parent == categories[parentCategoryId]
                || categories[parentCategoryId].Children.Contains(categories[childCategoryId]))
            {
                throw new ArgumentException();
            }

            categories[childCategoryId].Parent = categories[parentCategoryId];
            categories[parentCategoryId].Children.Add(categories[childCategoryId]);
            
            UpdateParentsDepth(categories[parentCategoryId]);
        }

        public bool Contains(Category category) => categories.ContainsKey(category.Id);

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var result = new List<Category>();

            foreach (Category child in categories[categoryId].Children)
            {
                result.Add(child);
                result.AddRange(GetChildren(child.Id));
            }

            return result;
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = categories[categoryId];
            var result = new Stack<Category>();

            while (category != null)
            {
                result.Push(category);
                category = category.Parent;
            }

            return result;
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
            => categories.Values.OrderByDescending(c => c.Depth)
                .ThenBy(c => c.Name)
                .Take(3);

        public void RemoveCategory(string categoryId)
        {
            if (!categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Category category = categories[categoryId];
            RemoveWithAllChildren(category);
            category.Parent?.Children.Remove(category);

            if (category.Parent != null)
            {
                UpdateParentsDepth(category.Parent);
            }
        }

        public int Size() => categories.Count;

        private void RemoveWithAllChildren(Category category)
        {
            foreach (Category child in category.Children)
            {
                RemoveWithAllChildren(child);
            }

            categories.Remove(category.Id);
        }

        private static void UpdateParentsDepth(Category category)
        {
            while (category != null)
            {
                category.Depth = !category.Children.Any() ? 1 : category.Children.Max(c => c.Depth) + 1;
                category = category.Parent;
            }
        }
    }
}
