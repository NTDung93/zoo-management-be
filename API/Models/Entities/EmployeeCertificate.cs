using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class EmployeeCertificate
{
    public int No { get; set; }

    public string EmpId { get; set; }

    public string CerfCode { get; set; }

    public string Description { get; set; }

    public virtual Certificate CerfCodeNavigation { get; set; }

    public virtual Employee Emp { get; set; }
}
