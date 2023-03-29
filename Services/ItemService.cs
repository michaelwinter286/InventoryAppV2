using InventorySystem.Entities;
using InventorySystem.Repositories;
using InventorySystem.Validators;
using Serilog;
using AutoMapper;
using FluentValidation.Results;


namespace InventorySystem.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _itemRepository;

        public ItemService()
        {
            _itemRepository = new ItemRepository();
        }
        public async Task AddItemService(Item addItem)
        {
            var currentItem = await _itemRepository.GetItemByName(addItem.ItemName!);
            if (currentItem?.ItemName != null)
            {
                Log.Error($"Unable to Add New Item: Item Exists - {addItem.ItemName}");
                throw new ArgumentException("That item already exists. Please double check Inventory.");
            }
            var validation = new ItemValidation();
            ValidationResult results = validation.Validate(addItem);

            await _itemRepository.AddItem(addItem);
        }


        public async Task UpdateItemService(Item updateItem)
        {
            var currentItem = await _itemRepository.GetItemById(updateItem.ItemId);

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

            await _itemRepository.UpdateItem(updateItem);
        }

        public async Task DeleteItemService(Item deleteItem)
        {
            var currentItem = await _itemRepository.GetItemByName(deleteItem.ItemName!);

            if (currentItem == null)
            {
                Log.Error($"Unable to Delete: Item was not found.");
                throw new ArgumentException("Item name cannot be found.");
            }

            Log.Information($"Item was deleted from Inventory: {deleteItem.ItemName}");
            await _itemRepository.DeleteItem(deleteItem);
        }
       public async Task<Item?> GetItemByNameService(string itemName)
        {
            var result = await _itemRepository.GetItemByName(itemName);

            if (result == null)
            {
                Log.Error($"Item was not found in Inventory.");
                throw new ArgumentException($"Item was not found. Please verify spelling and current inventory.");
            }

            return result;
        }







        
    }
}
