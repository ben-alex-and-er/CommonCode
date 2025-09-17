namespace Unit_Tests.DataAccessors
{
	public static class CRUDExtensionTestCaseSources
	{
		public static IEnumerable<TestCaseData> UpsertTest_2TypesCaseSource
		{
			get
			{
				yield return new TestCaseData(0, 0, true);
				yield return new TestCaseData(0, 1, true);
				yield return new TestCaseData(1, 0, true);
				yield return new TestCaseData(1, 1, false);
			}
		}

		public static IEnumerable<TestCaseData> UpsertTest_3TypesCaseSource
		{
			get
			{
				yield return new TestCaseData(0, 0, 0, true);
				yield return new TestCaseData(0, 0, 1, true);
				yield return new TestCaseData(0, 1, 0, true);
				yield return new TestCaseData(1, 0, 0, false);
				yield return new TestCaseData(0, 1, 1, true);
				yield return new TestCaseData(1, 0, 1, false);
				yield return new TestCaseData(1, 1, 0, true);
				yield return new TestCaseData(1, 1, 1, false);
			}
		}
	}
}
