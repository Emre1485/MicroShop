﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Cargo.DTOLayer.DTOs.CargoProgressDTOs
{
    public class UpdateCargoProgressDTO
    {
        public int CargoProgressId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
