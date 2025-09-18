using System.Security.Cryptography;


namespace Unit_Tests.GateKeeper.Cryptography
{
	internal class PasswordHasherTestCaseSources
	{
		public static IEnumerable<TestCaseData> HashPasswordTestCaseSource
		{
			get
			{
				yield return new TestCaseData(0, 3123, 1, HashAlgorithmName.SHA1);
				yield return new TestCaseData(43, 3, 4321, HashAlgorithmName.SHA256);
				yield return new TestCaseData(1, 1, 654, HashAlgorithmName.SHA3_256);
				yield return new TestCaseData(324, 213, 05, HashAlgorithmName.SHA384);
				yield return new TestCaseData(5325, 4312, 99999, HashAlgorithmName.SHA3_384);
				yield return new TestCaseData(4234, 4, 123, HashAlgorithmName.SHA3_512);
				yield return new TestCaseData(5, 532, 2, HashAlgorithmName.SHA512);
			}
		}

		public static IEnumerable<TestCaseData> VerifyPasswordTestCaseSource
		{
			get
			{
				yield return new TestCaseData(string.Empty, 0, 3123, 1, HashAlgorithmName.SHA1);
				yield return new TestCaseData("test", 43, 3, 4321, HashAlgorithmName.SHA256);
				yield return new TestCaseData("reallyreallyreallyreallyreallyreallylongpassword", 1, 1, 654, HashAlgorithmName.SHA3_256);
				yield return new TestCaseData("%^#&@*(#@&*#", 324, 213, 05, HashAlgorithmName.SHA384);
				yield return new TestCaseData("12313621783", 5325, 4312, 99999, HashAlgorithmName.SHA3_384);
				yield return new TestCaseData(",.,'[.;[123;1.", 4234, 4, 123, HashAlgorithmName.SHA3_512);
				yield return new TestCaseData("password", 5, 532, 2, HashAlgorithmName.SHA512);
			}
		}
	}
}
