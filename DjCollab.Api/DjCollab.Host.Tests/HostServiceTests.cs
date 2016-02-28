using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DjCollab.Host.Tests
{
    [TestClass]
    public class HostServiceTests
    {
        public IDictionary<int, HostWebSocketHandler> TestDict()
        {
            var dict = new Dictionary<int, HostWebSocketHandler>();

            var h1 = new HostWebSocketHandler(5);
            h1.HostId = 0;
            dict[0] = h1;

            var h2 = new HostWebSocketHandler(6);
            h2.HostId = 3;
            dict[3] = h2;

            var h3 = new HostWebSocketHandler(7);
            h3.HostId = 5;
            dict[5] = h3;

            return dict;
        }

        [TestMethod]
        public void CanGetHostByPartyId()
        {
            var hostService = new HostService(TestDict());
            Assert.AreEqual(0, hostService.GetHostByPartyId(5).HostId);
            Assert.AreEqual(3, hostService.GetHostByPartyId(6).HostId);
            Assert.AreEqual(5, hostService.GetHostByPartyId(7).HostId);
        }
    }
}
