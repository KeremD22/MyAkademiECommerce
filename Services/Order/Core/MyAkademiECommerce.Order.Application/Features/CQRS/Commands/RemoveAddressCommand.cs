﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademiECommerce.Order.Application.Features.CQRS.Commands
{
    public class RemoveAddressCommand
    {
        public RemoveAddressCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
