﻿using LinqToDB.SqlProvider;

namespace LinqToDB.DataProvider.SqlServer
{
	sealed class SqlServer2017SqlOptimizer : SqlServer2012SqlOptimizer
	{
		public SqlServer2017SqlOptimizer(SqlProviderFlags sqlProviderFlags) : base(sqlProviderFlags, SqlServerVersion.v2017)
		{
		}
	}
}
