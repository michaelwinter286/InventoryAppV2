using System;
using FluentValidation;
using InventorySystem.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Validators
{
    public class ItemValidation : AbstractValidator <Item>
    {
        public ItemValidation()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty()
                .Length(1);
            RuleFor(x => x.ItemAmount)
                .NotEmpty();
        }
    }
}
