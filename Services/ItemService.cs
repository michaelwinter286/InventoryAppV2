using InventorySystem.Entities;
using InventorySystem.Repositories;
using InventorySystem.Validators;
using InventorySystem.DataTransferObject;
using System.Globalization;
using Serilog;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;


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
        public async Task AddItemServiceAsync(ItemDto itemDto)
        {
            var itemName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(itemDto.ItemName!.ToLower());
            var result = await _itemRepository.GetItemByNameAsync(itemDto.ItemName!);
            if (result != null)
            {
                Log.Error($"Unable to Add New Item: Item Exists - {itemDto.ItemName}");
                throw new ArgumentException("That item already exists. Please double check Inventory.");
            }
            var validator = new ItemValidator();
            ValidationResult results = validator.Validate(itemDto);

            if (!results.IsValid)
            {
                Log.Error($"Creation failed. Validation Error: {string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            Log.Information(itemDto.ItemName + " has been added into Inventory.");

            var item = _mapper.Map<Item>(itemDto);
            item.ItemName = itemName;
            
            await _itemRepository.AddItemAsync(item);
        }


        public async Task UpdateItemServiceAsync(ItemDto itemDto)
        {
            itemDto.ItemName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(itemDto.ItemName!.ToLower());

            var currentItem = await _itemRepository.GetItemByIdAsync(itemDto.ItemId);

            if (currentItem == null)
            {
                Log.Error($"Unable to Update: Item Not Found");
                throw new ArgumentException("Item Name cannot be found");
            }


            var validator = new ItemValidator();
            ValidationResult results = validator.Validate(itemDto);

            if (!results.IsValid)
            {
                Log.Error($"Unable to Update: Validation Error: {string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            currentItem.ItemName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(itemDto.ItemName.ToLower());
            currentItem.ItemName = itemDto.ItemName;
            currentItem.ItemAmount = itemDto.ItemAmount;
            currentItem.ItemPar = itemDto.ItemPar;


            Log.Information($"Inventory has been updated: {itemDto.ItemName}");

            var item = _mapper.Map<Item>(itemDto);

            await _itemRepository.UpdateItemAsync(item);
        }

        public async Task DeleteItemServiceAsync(ItemDto deleteItem)
        {
            var currentItem = await _itemRepository.GetItemByNameAsync(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deleteItem.ItemName!.ToLower()));

            if (currentItem == null)
            {
                Log.Error($"Unable to Delete: Item was not found.");
                throw new ArgumentException("Item name cannot be found.");
            }

            Log.Information($"Item was deleted from Inventory: {deleteItem.ItemName}");

            var item = _mapper.Map<Item>(deleteItem);
            await _itemRepository.DeleteItemAsync(item);
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
