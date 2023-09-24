using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Certificate
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Level { get; set; }

    public string TrainingInstitution { get; set; }

    public virtual ICollection<EmployeeCertificate> EmployeeCertificates { get; set; } = new List<EmployeeCertificate>();
}
