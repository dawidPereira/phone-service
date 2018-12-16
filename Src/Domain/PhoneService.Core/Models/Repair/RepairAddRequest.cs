﻿using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Repair
{
    public class RepairAddRequest
    {
        public string Description { get; set; }
        public DateTime CreateTime { get => DateTime.Now; } 
        public int StatusId { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public ICollection<RepairItemAddRequest> RepairItems { get; set; }
    }
}