using System;
using FluentValidation;
using InventorySystem.Entities;
using InventorySystem.DataTransferObject;


namespace InventorySystem.Validators
{
    public class ItemValidator : AbstractValidator <ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty()
                .Length(1);
            RuleFor(x => x.ItemAmount)
                .NotEmpty();
        }
    }
}
