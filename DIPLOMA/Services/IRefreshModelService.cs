using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Services
{
    public interface IRefreshModelService
    {
        event Action RefreshRequested;
        event Action<string> RefreshRequested1;

        void CallRequestRefresh();
        void Refresh(string foo);

    }
}
