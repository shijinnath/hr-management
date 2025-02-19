﻿using MediatR;

namespace LeaveManagementService.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
    }

}
