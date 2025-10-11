// 代码生成时间: 2025-10-11 20:38:51
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeBaseApp
{
    // Exception class for knowledge base specific errors
    public class KnowledgeBaseException : Exception
    {
        public KnowledgeBaseException(string message) : base(message)
        {
        }
    }

    // KnowledgeBaseItem represents a single item in the knowledge base
    public class KnowledgeBaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Constructor
        public KnowledgeBaseItem(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }

    // KnowledgeBaseManager manages the knowledge base
    public class KnowledgeBaseManager
    {
        private List<KnowledgeBaseItem> _knowledgeBase;

        // Constructor
        public KnowledgeBaseManager()
        {
            _knowledgeBase = new List<KnowledgeBaseItem>();
        }

        // Add a new item to the knowledge base
        public void AddItem(int id, string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                throw new KnowledgeBaseException("Title and content cannot be empty.");
            }

            _knowledgeBase.Add(new KnowledgeBaseItem(id, title, content));
        }

        // Retrieve an item by its id
        public KnowledgeBaseItem GetItemById(int id)
        {
            var item = _knowledgeBase.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KnowledgeBaseException($"Item with id {id} not found.");
            }

            return item;
        }

        // Update an existing item in the knowledge base
        public void UpdateItem(int id, string title, string content)
        {
            var item = GetItemById(id);
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                throw new KnowledgeBaseException("Title and content cannot be empty.");
            }

            item.Title = title;
            item.Content = content;
        }

        // Delete an item from the knowledge base
        public void DeleteItem(int id)
        {
            var item = GetItemById(id);
            _knowledgeBase.Remove(item);
        }

        // List all items in the knowledge base
        public List<KnowledgeBaseItem> ListItems()
        {
            return _knowledgeBase.ToList();
        }
    }
}
