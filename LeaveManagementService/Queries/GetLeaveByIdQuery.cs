﻿using LeaveManagementService.Models;
using MediatR;

namespace LeaveManagementService.Queries
{
    public class GetAllLeaveCategoryQuery : IRequest<IEnumerable<LeaveCategory>>
    { 
    }

}
