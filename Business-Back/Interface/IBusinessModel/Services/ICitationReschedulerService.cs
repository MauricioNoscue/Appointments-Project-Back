using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back;

namespace Business_Back.Interface.IBusinessModel.Services
{
    public interface ICitationReschedulerService
    {   
        Task<Citation?> TryRescheduleAsync(Citation original, CancellationToken ct);
    }
}
