using InventorySystem.Entities;
using InventorySystem.Repositories;
using InventorySystem.Validators;
using InventorySystem.DataTransferObject;
using Serilog;
using AutoMapper;
using FluentValidation.Results;
using System.Collections.Generic;

namespace InventorySystem.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemDto>();
                cfg.CreateMap<ItemDto, Item>();
            });

            _mapper = config.CreateMapper();
            _itemRepository = new ItemRepository();
        }
        public async Task AddItemServiceAsync(Item addItem)
        {
            var currentItem = await _itemRepository.GetItemByNameAsync(addItem.ItemName!);
            if (currentItem?.ItemName != null)
            {
                Log.Error($"Unable to Add New Item: Item Exists - {addItem.ItemName}");
                throw new ArgumentException("That item already exists. Please double check Inventory.");
            }
            //var validation = new ItemValidation();
            //ValidationResult results = validation.Validate(addItem);

            await _itemRepository.AddItemAsync(addItem);
        }


        public async Task UpdateItemServiceAsync(Item updateItem)
        {
            var currentItem = await _itemRepository.GetItemByIdAsync(updateItem.ItemId);

            if (currentItem == null)
            {
                Log.Error($"Unable to Update: Item Not Found");
                throw new ArgumentException("Item Name cannot be found");
            }


            var validation = new ItemValidation();
            ValidationResult results = validation.Validate(updateItem);

            if (!results.IsValid)
            {
                Log.Error($"Unable to Update: Validation Error: {string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            currentItem.ItemName = updateItem.ItemName;
            currentItem.ItemAmount = updateItem.ItemAmount;
            currentItem.ItemPar = updateItem.ItemPar;


            Log.Information($"Inventory has been updated: {updateItem.ItemName}");

            await _itemRepository.UpdateItemAsync(updateItem);
        }

        public async Task DeleteItemServiceAsync(Item deleteItem)
        {
            var currentItem = await _itemRepository.GetItemByNameAsync(deleteItem.ItemName!);

            if (currentItem == null)
            {
                Log.Error($"Unable to Delete: Item was not found.");
                throw new ArgumentException("Item name cannot be found.");
            }

            Log.Information($"Item was deleted from Inventory: {deleteItem.ItemName}");
            await _itemRepository.DeleteItemAsync(deleteItem);
        }
       public async Task<Item?> GetItemByNameServiceAsync(string itemName)
        {
            var result = await _itemRepository.GetItemByNameAsync(itemName);

            if (result == null)
            {
                Log.Error($"Item was not found in Inventory.");
                throw new ArgumentException($"Item was not found. Please verify spelling and current inventory.");
            }

            return result;
        }

        // Calls repository method to get a list of all peppers in the database
        public async Task<List<Item>> GetAllItemsServiceAsync()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return items;
        }







    }
}
