using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Services
{
    public class RefreshModelService : IRefreshModelService
    {
        public event Action RefreshRequested;
        public event Action<string> RefreshRequested1;

        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
        public void Refresh(string foo)
        {
            RefreshRequested1?.Invoke(foo);
        }
    }
}
