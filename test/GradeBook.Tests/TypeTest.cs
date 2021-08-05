using System;
using Xunit;


namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void writeLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void test1()
        {
            var x = getInt();
            SetInt(x);
            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int getInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "George";
            var uppername = MakeUppercase(name);
            Assert.Equal("GEORGE", uppername);
            Assert.Equal("George", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void PassByRef()
        {
            var book1 = GetBook("Book 1");
            RefGetBookSetName(ref book1, "New Name");


            Assert.Equal("New Name", book1.Name);

        }
        private void RefGetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }




        [Fact]
        public void CSharpPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");


            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            
        }









        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");


            Assert.Equal("New Name", book1.Name);
          
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReferencesDifferentObjects()
        {
            var book1 = GetBook("book1");
            var book2 = GetBook("book2");

            Assert.Equal("book1", book1.Name);
            Assert.Equal("book2", book2.Name);
            Assert.NotSame(book1, book2);
           
            
            


        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("book1");
            var book2 = book1;

            //Assert.Equal("book1", book1.Name);
            //Assert.Equal("book1", book2.Name);
            Assert.Same(book1, book2);





        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
