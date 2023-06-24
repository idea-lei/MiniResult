using MiniResult;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void ResultOk_ReturnsSuccessfulResultWithCorrectMessage()
        {
            var message = "Success";
            var result = Result.Ok(message);

            Assert.True(result.IsSuccess);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public void ResultFailed_ReturnsUnsuccessfulResultWithCorrectMessage()
        {
            var message = "Failure";
            var result = Result.Failed(message);

            Assert.False(result.IsSuccess);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public void ResultOfTOk_ReturnsSuccessfulResultWithCorrectObjectAndMessage()
        {
            var message = "Success";
            var obj = "TestObject";
            var result = Result<string>.Ok(obj, message);

            Assert.True(result.IsSuccess);
            Assert.Equal(message, result.Message);
            Assert.Equal(obj, result.Object);
        }

        [Fact]
        public void ResultOfTFailed_ReturnsUnsuccessfulResultWithCorrectMessage()
        {
            var message = "Failure";
            var result = Result<string>.Failed(message);

            Assert.False(result.IsSuccess);
            Assert.Equal(message, result.Message);
            Assert.Null(result.Object);
        }

        [Fact]
        public void ToNonGenericResult_ReturnsNonGenericResultWithSameStatusAndMessage()
        {
            var message = "Failure";
            var resultT = Result<string>.Failed(message);
            var result = resultT.ToNonGenericResult();

            Assert.Equal(resultT.IsSuccess, result.IsSuccess);
            Assert.Equal(resultT.Message, result.Message);
        }

        [Fact]
        public void ImplicitOperator_ReturnsSuccessfulResultWithCorrectObject()
        {
            var obj = "TestObject";
            Result<string> result = obj;

            Assert.True(result.IsSuccess);
            Assert.Equal(obj, result.Object);
        }
    }
}