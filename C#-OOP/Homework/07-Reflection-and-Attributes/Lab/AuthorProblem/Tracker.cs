namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var sb = new StringBuilder();

            foreach (MethodInfo methodInfo in typeof(StartUp)
                         .GetMethods((BindingFlags)60)
                         .Where(m => m.GetCustomAttribute(typeof(AuthorAttribute)) != null))
            {
                foreach (AuthorAttribute attribute in methodInfo.GetCustomAttributes(false).Cast<AuthorAttribute>())
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}