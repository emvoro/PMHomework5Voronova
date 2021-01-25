using System;
using NotesApp.Services.Abstractions;
using NotesApp.Services.Models;
using NotesApp.Services.Services;
using Moq;
using Xunit;

namespace NotesApp.Tests
{
    public class ServicesTests
    {
        [Fact]
        public void AddNote_Throws_ArgumentNullException()
        {
            var storage = new Mock<INotesStorage>();
            var events = new Mock<INoteEvents>();
            var service = new NotesService(storage.Object, events.Object);
            Assert.Throws<ArgumentNullException>(() => service.AddNote(null, It.IsAny<int>()));
        }

        [Fact]
        public void AddNote_Notifies_Added_If_Note_Is_Added()
        {
            Note note = new Note();
            var storage = new Mock<INotesStorage>();
            var events = new Mock<INoteEvents>();
            storage.Setup(s => s.AddNote(note, It.IsAny<int>()));
            events.Setup(e => e.NotifyAdded(note, It.IsAny<int>()));
            var service = new NotesService(storage.Object, events.Object);
            service.AddNote(note, It.IsAny<int>());
            events.Verify(e => e.NotifyAdded(note, It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AddNote_Does_Not_Notify_Added_If_Note_Is_Not_Added()
        {
            Note note = new Note();
            var storage = new Mock<INotesStorage>();
            var events = new Mock<INoteEvents>();
            storage.Setup(s => s.AddNote(note, It.IsAny<int>()));
            events.Setup(e => e.NotifyAdded(note, It.IsAny<int>()));
            var service = new NotesService(storage.Object, events.Object);
            service.AddNote(note, It.IsAny<int>());
            events.Verify(e => e.NotifyAdded(note, It.Is<int>(id => id > 0)), Times.Never);
        }

        [Fact]
        public void DeleteNote_Notifies_Deleted_If_Note_Is_Deleted()
        {
            Guid id = new Guid();
            var storage = new Mock<INotesStorage>();
            var events = new Mock<INoteEvents>();
            storage.Setup(s => s.DeleteNote(id)).Returns(true);
            events.Setup(e => e.NotifyDeleted(id, It.IsAny<int>()));
            var service = new NotesService(storage.Object, events.Object);
            service.DeleteNote(id, It.Is<int>(i => i >= 0));
            events.Verify(e => e.NotifyDeleted(id, It.Is<int>(id => id >= 0)), Times.Once);
        }

        [Fact]
        public void DeleteNote_Does_Not_Notify_Deleted_If_Note_Is_Not_Deleted()
        {
            Guid id = new Guid();
            var storage = new Mock<INotesStorage>();
            var events = new Mock<INoteEvents>();
            storage.Setup(s => s.DeleteNote(id)).Returns(false);
            events.Setup(e => e.NotifyDeleted(id, It.IsAny<int>()));
            var service = new NotesService(storage.Object, events.Object);
            service.DeleteNote(id, It.Is<int>(i => i >= 0));
            events.Verify(e => e.NotifyDeleted(id, It.Is<int>(id => id >= 0)), Times.Never);
        }
    }
}
