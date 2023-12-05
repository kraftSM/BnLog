﻿using BnLog.DAL.Models.Entity;
using Microsoft.EntityFrameworkCore;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Items;

namespace BnLog.DAL.Repository.Items
{
    public class ItemsRepository0 : IItemsRepository0
    {
        private BlogDbContext _context;
        public ItemsRepository0(BlogDbContext context)
        {
            _context = context;
        }
        public async Task AddItem(Item? item)
        {
            _context.Items.Add(item);
            await SaveChangesAsync();
        }
        public List<Item> GetAllItems()
        {
            return _context.Items.Include(p => p.ItemType).ToList();
        }
        public List<Item> GetAllItemsOfTypes( itType pItemType )
        {
            return _context.Items.Include(p => p.ItemType == pItemType).ToList();
        }

        public Item GetItem(Guid id)
        {
            return _context.Items.Include(p => p.ItemType).FirstOrDefault(p => p.Id == id);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}