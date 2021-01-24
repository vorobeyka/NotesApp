using System;
using Xunit;
using NSubstitute;
using NSubstitute.Callbacks;
using NSubstitute.ClearExtensions;
using NSubstitute.Compatibility;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReceivedExtensions;
using NSubstitute.ReturnsExtensions;
using NSubstitute.Routing;
using NotesApp.Services.Models;
using NotesApp.Services.Abstractions;
using NotesApp.Services.Services;

namespace NotesApp.Services.Test
{
    public class NotesServiceTests
    {
        [Fact]
        public void AddEvent_Should_Return_Null_Exception_If_Note_Null()
        {
            var notesStorage = Substitute.For<INotesStorage>();
            var noteEvents = Substitute.For<INoteEvents>();
            var sut = new NotesService(notesStorage, noteEvents);

            Assert.Throws<ArgumentNullException>(() => sut.AddNote(null, 1));
        }

        [Fact]
        public void NotifyAdded_If_AddNote()
        {
            var notesStorage = Substitute.For<INotesStorage>();
            var noteEvents = Substitute.For<INoteEvents>();
            var sut = new NotesService(notesStorage, noteEvents);
            sut.AddNote(new Note(), 1);

            notesStorage.Received().AddNote(Arg.Any<Note>(), 1);
            noteEvents.Received().NotifyAdded(Arg.Any<Note>(), 1);
        }

        [Fact]
        public void Not_NotifyAdded_If_Not_AddNote()
        {
            var notesStorage = Substitute.For<INotesStorage>();
            var noteEvents = Substitute.For<INoteEvents>();
            var sut = new NotesService(notesStorage, noteEvents);
            
            notesStorage.DidNotReceive().AddNote(Arg.Any<Note>(), Arg.Any<int>());
            noteEvents.DidNotReceive().NotifyAdded(Arg.Any<Note>(), Arg.Any<int>());

            sut.AddNote(new Note(), 1);
            notesStorage.DidNotReceive().AddNote(Arg.Any<Note>(), 2);
            noteEvents.DidNotReceive().NotifyAdded(Arg.Any<Note>(), 2);
        }
        
        [Fact]
        public void NotifyDeleted_If_DeleteNote()
        {
            var notesStorage = Substitute.For<INotesStorage>();
            var noteEvents = Substitute.For<INoteEvents>();
            var sut = new NotesService(notesStorage, noteEvents);

            notesStorage.DeleteNote(Arg.Any<Guid>()).Returns(true);
            sut.DeleteNote(Guid.NewGuid(), 1);
            notesStorage.Received().DeleteNote(Arg.Any<Guid>());
            noteEvents.Received().NotifyDeleted(Arg.Any<Guid>(), Arg.Any<int>());
        }

        [Fact]
        public void Not_NotifyDeleted_IfDeleteNote()
        {
            var notesStorage = Substitute.For<INotesStorage>();
            var noteEvents = Substitute.For<INoteEvents>();
            var sut = new NotesService(notesStorage, noteEvents);

            notesStorage.DeleteNote(Arg.Any<Guid>()).Returns(false);
            sut.DeleteNote(Guid.NewGuid(), 1);
            notesStorage.Received().DeleteNote(Arg.Any<Guid>());
            noteEvents.DidNotReceive().NotifyDeleted(Arg.Any<Guid>(), Arg.Any<int>());
        }
    }
}
