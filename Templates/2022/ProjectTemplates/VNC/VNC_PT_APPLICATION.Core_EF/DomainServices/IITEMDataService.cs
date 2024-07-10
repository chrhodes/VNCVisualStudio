using System.Threading.Tasks;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;

using VNC.Core.DomainServices;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices
{
    public interface I$xxxITEMxxx$DataService : IGenericRepository<$xxxITEMxxx$>
    {
        Task<bool> IsReferencedBy$xxxTYPExxx$Async(int id);
    }
}
