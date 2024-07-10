using System.Threading.Tasks;

using $xxxMODULExxx$$xxxNAMESPACExxx$.Domain;

using VNC.Core.DomainServices;

namespace $xxxMODULExxx$$xxxNAMESPACExxx$.DomainServices
{
    public interface I$xxxITEMxxx$DataService : IGenericRepository<$xxxITEMxxx$>
    {
        Task<bool> IsReferencedBy$xxxTYPExxx$Async(int id);
    }
}
