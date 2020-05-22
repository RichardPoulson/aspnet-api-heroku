using System;
namespace aspnet_api_heroku.Models
{
    /// <summary>
    /// A ToDo item.
    /// </summary>
    public class TodoItem
    {
        /// <summary>Unique ID</summary>
        public long Id { get; set; }
        /// <summary>Name</summary>
        public string Name { get; set; }
        /// <summary>Is the ToDo item complete or not.</summary>
        public bool IsComplete { get; set; }
    }
}
