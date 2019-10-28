﻿using System;

namespace HsrTech.Domain.Entities
{
    public class BankAccount
    {
        public int NumberAccount { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal Balance{ get; set; }
        public int ClientId { get; set; }
        public int Limit { get; set; }
    }
}
