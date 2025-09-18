using GateKeeper.Cryptography;
using System.Security.Cryptography;


namespace Unit_Tests.GateKeeper.Cryptography
{
	internal class PaswordHasherTests
	{
		[TestCaseSource(typeof(PasswordHasherTestCaseSources), nameof(PasswordHasherTestCaseSources.HashedPasswordTestCaseSource))]
		public void HashedPasswordTests(string password)
		{
			// Arrange
			var hashedPassword = PasswordHasher.HashPassword(password);

			// Act
			var str = hashedPassword.ToString();
			var hashedStr = new HashedPassword(str);

			// Assert
			Assert.That(hashedStr, Is.Not.Null);
			Assert.That(hashedStr.ToString(), Is.EqualTo(str));
		}

		[TestCaseSource(typeof(PasswordHasherTestCaseSources), nameof(PasswordHasherTestCaseSources.HashPasswordTestCaseSource))]
		public void HashPasswordTests(int saltSize, int hashSize, int iterations, HashAlgorithmName algorithmName)
		{
			// Act
			var result = PasswordHasher.HashPassword("test", algorithmName, saltSize, hashSize, iterations);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(Convert.FromBase64String(result.Salt).Length, Is.EqualTo(saltSize));
			Assert.That(result.HashSize, Is.EqualTo(hashSize));
			Assert.That(result.Iterations, Is.EqualTo(iterations));
			Assert.That(result.Algorithm, Is.EqualTo(algorithmName));
		}

		[TestCaseSource(typeof(PasswordHasherTestCaseSources), nameof(PasswordHasherTestCaseSources.HashPasswordNoAlgorithmTestCaseSource))]
		public void HashPasswordNoAlgorithmnNameTests(int saltSize, int hashSize, int iterations)
		{
			// Act
			var result = PasswordHasher.HashPassword("test", saltSize, hashSize, iterations);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(Convert.FromBase64String(result.Salt).Length, Is.EqualTo(saltSize));
			Assert.That(result.HashSize, Is.EqualTo(hashSize));
			Assert.That(result.Iterations, Is.EqualTo(iterations));
			Assert.That(result.Algorithm, Is.EqualTo(HashAlgorithmName.SHA512));
		}

		[TestCaseSource(typeof(PasswordHasherTestCaseSources), nameof(PasswordHasherTestCaseSources.VerifyPasswordTestCaseSource))]
		public void VerifyPasswordTests(string password, int saltSize, int hashSize, int iterations, HashAlgorithmName algorithmName)
		{
			// Arrange
			var hashedPassword = PasswordHasher.HashPassword(password, algorithmName, saltSize, hashSize, iterations);

			// Act
			var result = PasswordHasher.VerifyPassword(password, hashedPassword);

			// Assert
			Assert.That(result);
		}
	}
}
