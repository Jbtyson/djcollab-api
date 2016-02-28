using System;
using System.Collections.Generic;
using DjCollab.Party.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DjCollab.Party.Tests
{
    [TestClass]
    public class PartyServiceTests
    {
        [TestMethod]
        public void CanCreateParty()
        {
            FakePartyDb.Reset();
            var partyService = new PartyService();
            var createdParty = partyService.CreateParty("test");

            var party = partyService.GetParty(createdParty.Id);
            Assert.AreEqual(-1, party.HostId);
            Assert.AreEqual("test", party.Name);
        }

        [TestMethod]
        public void CanAddSongToParty()
        {
            FakePartyDb.Reset();
            var partyService = new PartyService();
            var createdParty = partyService.CreateParty("test");
            partyService.AddSongToParty(createdParty.Id, "abc");
            partyService.AddSongToParty(createdParty.Id, "def");
            partyService.AddSongToParty(createdParty.Id, "hij");

            var party = partyService.GetParty(createdParty.Id);
            Assert.AreEqual("abc", party.SongList[0]);
            Assert.AreEqual("def", party.SongList[1]);
            Assert.AreEqual("hij", party.SongList[2]);
        }
    }
}
