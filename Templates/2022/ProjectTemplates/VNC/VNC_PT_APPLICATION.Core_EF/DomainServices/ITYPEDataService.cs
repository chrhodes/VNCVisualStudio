using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;

using VNC.Core.DomainServices;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices
{
    public interface I$xxxTYPExxx$DataService : IGenericRepository<$xxxTYPExxx$>
    {
        void RemovePhoneNumber($xxxTYPExxx$PhoneNumber model);
    }
}
