using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL
{
    public class CustomerGroupBL : BaseBL<CustomerGroup>
    {
        protected override void Validate(CustomerGroup entity)
        {
            throw new GuardException<CustomerGroup>("O zê", entity as CustomerGroup);
        }


    }
}
