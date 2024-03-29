﻿using SMS.Dtos.Users;
using SMS.Dtos.Products;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateProduct(CreateProductFormModel model);

    }
}
