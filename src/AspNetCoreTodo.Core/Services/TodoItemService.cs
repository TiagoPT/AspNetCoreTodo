﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Core.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            if (newItem == null)
            {
                return false;
            }

            newItem.Id = new Guid();
            newItem.IsDone = false;
            newItem.DueAt = newItem.DueAt ?? DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(string userId)
        {
            return await _context.Items
                .Where(x => !x.IsDone)
                .ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }

            var todoItem = _context
                .Items
                .SingleOrDefault(i => i.Id == id);

            if (todoItem == null)
            {
                return false;
            }

            todoItem.IsDone = true;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
