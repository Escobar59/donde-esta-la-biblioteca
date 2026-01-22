using System.Collections.Generic;
using Moq;
using Xunit;

public class CatalogManagerTest
{
    private readonly Mock<IGenericRepository<Book>> _mockRepo;
    private readonly CatalogManager _catalogManager;

    public CatalogManagerTest()
    {
        _mockRepo = new Mock<IGenericRepository<Book>>();
        _catalogManager = new CatalogManager(_mockRepo.Object);
    }

    [Fact]
    public void GetCatalog_ReturnsAllBooks()
    {
        // Arrange
        var books = new List<Book>
        {
            new Book { Id = 1, Name = "Book1", Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Book2", Type = TypeBook.Fantaisie }
        };
        _mockRepo.Setup(repo => repo.GetAll()).Returns(books);

        // Act
        var result = _catalogManager.GetCatalog();

        // Assert
        Assert.Equal(books, result);
        _mockRepo.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Fact]
    public void GetCatalog_WithType_ReturnsFilteredBooks()
    {
        // Arrange
        var books = new List<Book>
        {
            new Book { Id = 1, Name = "Book1", Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Book2", Type = TypeBook.Fantaisie },
            new Book { Id = 3, Name = "Book3", Type = TypeBook.Aventure }
        };
        _mockRepo.Setup(repo => repo.GetAll()).Returns(books);

        // Act
        var result = _catalogManager.GetCatalog(TypeBook.Aventure);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, book => Assert.Equal(TypeBook.Aventure, book.Type));
        _mockRepo.Verify(repo => repo.GetAll(), Times.Once);
    }

    [Fact]
    public void FindBook_ReturnsBookById()
    {
        // Arrange
        var book = new Book { Id = 1, Name = "Book1" };
        _mockRepo.Setup(repo => repo.Get(1)).Returns(book);

        // Act
        var result = _catalogManager.FindBook(1);

        // Assert
        Assert.Equal(book, result);
        _mockRepo.Verify(repo => repo.Get(1), Times.Once);
    }

    [Fact]
    public void FindBook_ReturnsNull_WhenBookNotFound()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.Get(1)).Returns((Book)null);

        // Act
        var result = _catalogManager.FindBook(1);

        // Assert
        Assert.Null(result);
        _mockRepo.Verify(repo => repo.Get(1), Times.Once);
    }
}