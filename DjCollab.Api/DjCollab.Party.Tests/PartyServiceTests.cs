using System;
using System.Collections.Generic;
using DjCollab.Party.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DjCollab.Party.Tests
{
    [TestClass]
    public class PartyServiceTests
    {
        private Model.Party TestParty()
        {
            return new Model.Party
            {
                Name = "Name",
                Description = "Description",
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                SongList = new List<int>()
            };
        }

        [TestMethod]
        public void CanCreateParty()
        {
            FakePartyDb.Reset();
            var partyService = new PartyService();
            var testParty = TestParty();
            var createdParty = partyService.CreateParty(420, testParty);

            var party = partyService.GetParty(createdParty.Id);
            Assert.AreEqual(420, party.HostId);
            Assert.AreEqual("Name", party.Name);
            Assert.AreEqual("Description", party.Description);
        }

        [TestMethod]
        public void CanAddSongToParty()
        {
            FakePartyDb.Reset();
            var partyService = new PartyService();
            var testParty = TestParty();
            var createdParty = partyService.CreateParty(420, testParty);
            partyService.AddSongToParty(69, createdParty.Id, 40);
            partyService.AddSongToParty(69, createdParty.Id, 41);
            partyService.AddSongToParty(69, createdParty.Id, 42);

            var party = partyService.GetParty(createdParty.Id);
            Assert.AreEqual(40, party.SongList[0]);
            Assert.AreEqual(41, party.SongList[1]);
            Assert.AreEqual(42, party.SongList[2]);
        }
    }
}
