﻿using Domain.Model.SeedWork;

namespace Domain.Model.Addresses
{
    public class Address : IEntity
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string NumExt { get; set; }

        public bool Validate()
        {
            var isValid = false;

            if (!string.IsNullOrEmpty(Street)) isValid = true;

            return isValid;
        }
    }
}
