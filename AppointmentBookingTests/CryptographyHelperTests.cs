using AppointmentBooking.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class CryptographyHelperTests
    {
        [Test]
        public void GenerateHash_ValidSaltAndPassword_ExpectedHashIsReturned()
        {
            //Arrange
            CryptographyHelper cryptoHelper = new CryptographyHelper();
            string salt = "/3Pfhl6cxR28WuOtn2IDrLi5F2eJwpLOfGTvG65wbUnbAHSBdPpIbV/CXu03KLfgQh8ruS30B+KUlhoLUOJhBQ==";
            string password = "password";
            string expectedHash = "IBXJ6OEItl05rn1Fk2ex0frVEFO5udRPE/kZ5jPHGEw=";

            //Act
            var result = cryptoHelper.GenerateHash(password, salt);

            //Assert
            Assert.That(result, Is.EqualTo(expectedHash));
        }

        [Test]
        public void GenerateHash_ValidSaltAndIncorrectPassword_HashIsNotequal()
        {
            //Arrange
            CryptographyHelper cryptoHelper = new CryptographyHelper();
            string salt = "/3Pfhl6cxR28WuOtn2IDrLi5F2eJwpLOfGTvG65wbUnbAHSBdPpIbV/CXu03KLfgQh8ruS30B+KUlhoLUOJhBQ==";
            string password = "incorrectPassword";
            string expectedHash = "IBXJ6OEItl05rn1Fk2ex0frVEFO5udRPE/kZ5jPHGEw=";

            //Act
            var result = cryptoHelper.GenerateHash(password, salt);

            //Assert
            Assert.AreNotEqual(result, expectedHash);
        }

        [Test]
        public void AreEqual_PasswordAndHashAreEqual_ReturnsTrue()
        {
            //Arrange
            CryptographyHelper cryptoHelper = new CryptographyHelper();
            string salt = "/3Pfhl6cxR28WuOtn2IDrLi5F2eJwpLOfGTvG65wbUnbAHSBdPpIbV/CXu03KLfgQh8ruS30B+KUlhoLUOJhBQ==";
            string password = "password";
            string hash = "IBXJ6OEItl05rn1Fk2ex0frVEFO5udRPE/kZ5jPHGEw=";

            //Act
            var result = cryptoHelper.AreEqual(password, hash, salt);

            //Assert
            Assert.That(result);
        }

        [Test]
        public void AreEqual_IncorrectHash_ReturnsTrue()
        {
            //Arrange
            CryptographyHelper cryptoHelper = new CryptographyHelper();
            string salt = "/3Pfhl6cxR28WuOtn2IDrLi5F2eJwpLOfGTvG65wbUnbAHSBdPpIbV/CXu03KLfgQh8ruS30B+KUlhoLUOJhBQ==";
            string password = "password";
            string hash = "IBXJ6OEItl05rn1wronghashFk2ex0frVEFO5udRPE/kZ5jPHGEw=";

            //Act
            var result = cryptoHelper.AreEqual(password, hash, salt);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AreEqual_IncorrectSalt_ReturnsTrue()
        {
            //Arrange
            CryptographyHelper cryptoHelper = new CryptographyHelper();
            string salt = "/3Pfhl6cxR28WuOtn2IDrLi5F2wrongOfGTvG65wbUnbAHSBdPpIbV/CXu03KLfgQh8ruS30B+KUlhoLUOJhBQ==";
            string password = "password";
            string hash = "IBXJ6OEItl05rn1Fk2ex0frVEFO5udRPE/kZ5jPHGEw=";

            //Act
            var result = cryptoHelper.AreEqual(password, hash, salt);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AreEqual_IncorrectPassword_ReturnsTrue()
        {
            //Arrange
            CryptographyHelper cryptoHelper = new CryptographyHelper();
            string salt = "/3Pfhl6cxR28WuOtn2IDrLi5F2eJwpLOfGTvG65wbUnbAHSBdPpIbV/CXu03KLfgQh8ruS30B+KUlhoLUOJhBQ==";
            string password = "incorrectpassword";
            string hash = "IBXJ6OEItl05rn1Fk2ex0frVEFO5udRPE/kZ5jPHGEw=";

            //Act
            var result = cryptoHelper.AreEqual(password, hash, salt);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
