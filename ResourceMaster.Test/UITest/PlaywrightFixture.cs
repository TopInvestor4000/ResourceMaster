using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.Test.UITest
{
    public class PlaywrightFixture : IAsyncLifetime
    {
        /// <summary>
        /// Initialize the Playwright fixture.
        /// </summary>
        public async Task InitializeAsync()
        {
            /* Setup Playwright module and the Browsers */
        }
        /// <summary>
        /// Dispose all fixture resources.
        /// </summary>
        public async Task DisposeAsync()
        {
            /* Dispose Playwright module and its resources. */
        }
    }
}
