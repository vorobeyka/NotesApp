using System;
using Xunit;
using NSubstitute;
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
            var noteEvent = Substitute.For<INoteEvents>();

            // Arrage
            var sut = new NotesService(notesStorage, noteEvent);

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => sut.AddNote(null, 1));
        }

        
    }
}
